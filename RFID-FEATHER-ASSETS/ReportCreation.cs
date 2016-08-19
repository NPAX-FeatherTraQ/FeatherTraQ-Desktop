using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class ReportCreation : Form
    {
        public Image PersonPhoto { get; set; }
        public string ExplanationNote { get; set; }

        string tokenvalue;
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        bool IsCameraConnected = false;
        string newImgFileNames;
        string language;
        string ImgFileName;
        int companyId;
        string readerInfo;
        bool isCameraChanged = false;
        string cameraDeviceName;
        int assetId;

        public ReportCreation(int srcAssetId)
        {
            InitializeComponent();

            //label1.Text = Form1.SetValueForText1;
            getLanguage();
            languageHandler();
            GetAssetSystemInfo();
            InitializeCamera();
            InitializePhotoLabel();
            assetId = srcAssetId;
            
        }
        private void getLanguage()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    language = (string)(key.GetValue("Language"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void languageHandler()
        {
            if (language == "Japanese")
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.ReportCreation", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");

                grpInformation.Text = rm.GetString("grpInformation");
                lblPersonPhoto.Text = rm.GetString("lblPersonPhoto");
                lblValidIDPhoto.Text = rm.GetString("lblValidIDPhoto");
                btnCapturePhoto.Text = "個人的な写真は取り込む";
                lblNotes.Text = rm.GetString("lblNotes");
                btnSubmit.Text = rm.GetString("btnSubmit");
                btnCancel.Text = rm.GetString("btnCancel");
                lblSubmittingInformation.Text = rm.GetString("lblSubmittingInformation");
                lblNoCameraAvailable.Text = rm.GetString("lblNoCameraAvailable");
                this.Text = rm.GetString("title");
            }
        }
        private void InitializePhotoLabel()
        {
            if(language.ToLower() == "japanese")
            {
                lblPersonPhoto.Text = "第一ステップ" + "\n" + lblPersonPhoto.Text;
                lblValidIDPhoto.Text = "第二ステップ" + "\n" + lblValidIDPhoto.Text;
            }
            else
            {
            lblPersonPhoto.Text = "Step 1" + "\n" + lblPersonPhoto.Text;
            lblValidIDPhoto.Text = "Step 2" + "\n" + lblValidIDPhoto.Text;
            }
        }

        private void InitializeCamera()
        {
            try
            {
                ////Checking the camera status
                //comVideoDeviceBox.Items.Clear();
                //cameraBox.Image = null;

                //webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //foreach (FilterInfo VideoCaptureDevice in webcam)
                //{
                //    comVideoDeviceBox.Items.Add(VideoCaptureDevice.Name);
                //}
                if (!isCameraChanged) getAvailableCamera();

                if (comVideoDeviceBox.Items.Count < 1)
                {
                    if (cam != null) cam.Stop();
                    IsCameraConnected = false;
                    cameraBox.BackColor = Color.Black;
                    lblNoCameraAvailable.Visible = true;
                    if (language.ToUpper() == "JAPANESE") btnCapturePhoto.Text = "リフレッシュカメラ";
                    else btnCapturePhoto.Text = "Refresh Camera";
                }
                else
                {
                    if (!isCameraChanged)
                    {
                        //isCameraChanged = false;
                        comVideoDeviceBox.SelectedIndex = 0;
                    }
                    StartCamera();

                    IsCameraConnected = true;
                    cameraBox.BackColor = Color.White;
                    lblNoCameraAvailable.Visible = false;

                    getCaptureButtonText();
                    /*if (language.ToLower() == "japanese") btnCapturePhoto.Text = "個人的な写真は取り込む";
                    else btnCapturePhoto.Text = "Capture Personal Photo";*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartCamera()
        {
            try
            {
                cam = new VideoCaptureDevice(webcam[comVideoDeviceBox.SelectedIndex].MonikerString);
                cameraDeviceName = comVideoDeviceBox.SelectedItem.ToString();
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            cameraBox.Image = bit;
        }

        private void GetAssetSystemInfo()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    tokenvalue = (string)(key.GetValue("authenticationToken"));
                    //txtSaveImageDir.Text = (string)(key.GetValue("PersonImagePath"));
                    companyId = (int)(key.GetValue("companyId"));
                    readerInfo = (string)(key.GetValue("readerInfo"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgCapture1.Image == null || imgCapture2.Image == null || txtExplanationNotes.Text.Length == 0)
                {
                    if (language.ToLower() == "japanese") MessageBox.Show("完全な情報は必要です.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else MessageBox.Show("Complete information is required.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtExplanationNotes.Focus();
                    return;
                }
               
                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                transactDet.companyId = companyId;//1;
                transactDet.readerInfo = readerInfo;
                //transactDet.readerId = 1;
                transactDet.assetId = assetId;//Verification.AssetIdValue;
                transactDet.notes = txtExplanationNotes.Text.Trim();
                transactDet.imageUrls = newImgFileNames;//txtCapturedImagePath.Text;//txtImagePath.Text;
                transactDet.type = "CREATE-Report";


                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://feather-assets.herokuapp.com/");
                RestRequest transact = new RestRequest("/api/asset/transact", Method.POST);

                var authToken = tokenvalue;
                transact.AddHeader("X-Auth-Token", authToken);
                transact.AddHeader("Content-Type", "application/json; charset=utf-8");
                transact.RequestFormat = DataFormat.Json;
                transact.AddBody(transactDet);

                lblSubmittingInformation.Visible = true;
                this.Refresh();


                IRestResponse response = client.Execute(transact);
                lblSubmittingInformation.Visible = false;

                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)//if (response.IsSuccessStatusCode)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                    if (restResult.result == "OK")
                    {
                        if (language.ToLower() == "japanese") MessageBox.Show("レポートが正常に保存され", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Report successfully saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (IsCameraConnected) cam.Stop();
                        DialogResult = DialogResult.OK;
                        this.Dispose(); //ClearFields();
                    }
                    else
                    {
                        MessageBox.Show(restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Error Code " +
                    response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    return;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ReportCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnCapturePhoto_Click(object sender, EventArgs e)
        {
            try
            {
               /* if (string.IsNullOrEmpty(txtSaveImageDir.Text))
                {
                    MessageBox.Show("Please select Image Path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnBrowseImagePath.Focus();
                    return;
                }
                else
                {*/
                    //btnGetRFIDTag.PerformClick();
                    //reader.CloseCom();
                    if (cam == null || btnCapturePhoto.Text == "Refresh Camera" || btnCapturePhoto.Text=="リフレシュカメラ")
                    {
                        InitializeCamera();                        
                    }
                    else if (IsCameraConnected)
                    {
                        /*if (language.ToLower() == "japanese") btnCapturePhoto.Text = "個人的な写真は取り込む";
                        else btnCapturePhoto.Text = "Capture Personal Photo";*/

                        if (imgCapture2.Image == null)
                        {
                            if (language.ToLower() == "japanese") btnCapturePhoto.Text = "処理. お待ちください...";
                            else btnCapturePhoto.Text = "Processing. Please wait...";
                            btnCapturePhoto.Refresh();
                        }                        
                        //Assigned captured image in each picture box
                        if (imgCapture1.Image == null)
                        {
                            imgCapture1.Image = cameraBox.Image;
                            lblPersonPhoto.Visible = false;
                            //btnCapturePhoto.Text = "Capture Valid ID Photo";
                        }
                        else if (imgCapture2.Image == null)
                        {
                            imgCapture2.Image = cameraBox.Image;
                            lblValidIDPhoto.Visible = false;
                            //btnCapturePhoto.Text = "Captured Completed";
                        }
                        else
                        {
                            if (language.ToLower() == "japanese") MessageBox.Show("写真は、制限を超えます", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else MessageBox.Show("Captured Images exceeds the maximum limit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SubmitImage();

                        //if (string.IsNullOrEmpty(newImgFileNames))
                        //    newImgFileNames = ImgFileName;
                        //else
                            newImgFileNames = newImgFileNames + "," + ImgFileName;

                        ////Saving for captured images
                        //string dirPath = txtSaveImageDir.Text.Trim() + @"\";//@"C:\Users\USER\Pictures\";
                        //string fileName = "Image";
                        //string[] files = Directory.GetFiles(dirPath);
                        //int count = files.Count(file => { return file.Contains(fileName); });

                        //string newFileName = (count == 0) ? "ReportedImage.jpg" : String.Format("{0}{1}.jpg", fileName, count + 1);

                        //cameraBox.Image.Save(dirPath + newFileName);
                        //txtCapturedImagePath.Text = txtCapturedImagePath.Text + "," + dirPath + newFileName;

                        cam.Stop();
                        InitializeCamera();
                    }
                }
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getCaptureButtonText()
        {
            if (language == "English")
            {
                if (imgCapture1.Image == null) btnCapturePhoto.Text = "Capture Owner Photo";
                else if (imgCapture2.Image == null) btnCapturePhoto.Text = "Capture Valid ID Photo";
                else btnCapturePhoto.Text = "Captured Completed";
            }
            else
            {
                if (imgCapture1.Image == null) btnCapturePhoto.Text = "個人的な写真は取り込む";
                else if (imgCapture2.Image == null) btnCapturePhoto.Text = "有効な証明ID写真を取り込みます";
                else btnCapturePhoto.Text = "撮影し完成";
            }
        }

        private void SubmitImage()
        {
            Bitmap Image = (Bitmap)cameraBox.Image;
            Image.Save("img.jpg", ImageFormat.Jpeg);

            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
            RestRequest upload = new RestRequest("/api/upload/image", Method.POST);

            upload.AddHeader("X-Auth-Token", tokenvalue);
            upload.AddHeader("Content-Type", "multipart/form-data");
            upload.AlwaysMultipartFormData = true;
            upload.AddFile("file", "img.jpg", "image/jpg");
            upload.AddParameter("companyId", 1);
            upload.AddParameter("type", "asset");


            IRestResponse response = client.Execute(upload);
            /*if (language.ToUpper() == "JAPANESE")
            {
                if (imgCapture2.Image == null) btnCapturePhoto.Text = "有効な証明ID写真を取り込みます";
                else btnCapturePhoto.Text = "取り込み官僚";
            }
            else
            {
                if (imgCapture2.Image == null) btnCapturePhoto.Text = "Capture Valid ID Photo";
                else btnCapturePhoto.Text = "Capture Completed";
            }*/
            getCaptureButtonText();

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)//if (response.IsSuccessStatusCode)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                GlobalClass.GetSetClass imageResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                ImgFileName = imageResult.message;
            }
            else
            {
                MessageBox.Show("Error Code " +
                response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                return;
            }
        }

        private void btnBrowseImagePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagePathDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSaveImageDir.Text = imagePathDialog.SelectedPath;

                    //accessing the CurrentUser root element  
                    //and adding "PersonImagePath" subkey to the "SOFTWARE" subkey  
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

                    //storing the values  
                    key.SetValue("PersonImagePath", txtSaveImageDir.Text);
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (language.ToLower() == "japanese")
                {
                    if (imgCapture1.Image != null || !string.IsNullOrEmpty(txtExplanationNotes.Text))
                    {
                        DialogResult result = MessageBox.Show("レポートをキャンセルしてもよろしいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            if (IsCameraConnected) cam.Stop();
                            DialogResult = DialogResult.Cancel;
                            this.Dispose();
                        }
                        else
                        {
                            //btnGetRFIDTag.Focus();
                            //this.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        if (IsCameraConnected) cam.Stop();
                        this.Dispose();
                        //return;
                    }
                }
                else
                {
                    if (imgCapture1.Image != null || !string.IsNullOrEmpty(txtExplanationNotes.Text))
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to cancel the report creation?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            if (IsCameraConnected) cam.Stop();
                            DialogResult = DialogResult.Cancel;
                            this.Dispose();
                        }
                        else
                        {
                            //btnGetRFIDTag.Focus();
                            //this.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        if (IsCameraConnected) cam.Stop();
                        this.Dispose();
                        //return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkBoxChangeCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxChangeCamera.Checked)
            {
                comVideoDeviceBox.Visible = true;
                comVideoDeviceBox.Text = cameraDeviceName;

                isCameraChanged = true;
                //getAvailableCamera();
            }
            else
                comVideoDeviceBox.Visible = false;
        }

        private void comVideoDeviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cam != null) cam.Stop();

            if (isCameraChanged)
            {
                //isCameraChanged = true;
                InitializeCamera();
            }
        }

        private void comVideoDeviceBox_DropDown(object sender, EventArgs e)
        {
            getAvailableCamera();
        }

        private void getAvailableCamera()
        {
            //comVideoDeviceBox.SelectedIndex = 0;
            //Checking the camera status
            comVideoDeviceBox.Items.Clear();
            cameraBox.Image = null;

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comVideoDeviceBox.Items.Add(VideoCaptureDevice.Name);
            }
        }
    }

    //public class Transaction
    //{
    //    public int companyId { get; set; }
    //    public int readerId { get; set; }
    //    public int assetId { get; set; }
    //    public string notes { get; set; }
    //    public string imageUrl { get; set; }
    //    public string readerInfo { get; set; }
    //}
}
