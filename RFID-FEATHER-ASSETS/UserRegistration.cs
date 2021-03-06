using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RestSharp.Deserializers;
using RestSharp;
using System.Net;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using Microsoft.Win32;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;
using System.Drawing.Imaging;
using UHFDemo;

namespace RFID_FEATHER_ASSETS
{

    public partial class RegisterUser : Form
    {
        public static Reader.ReaderMethod reader;
        private ReaderSetting m_curSetting = new ReaderSetting();
        private InventoryBuffer m_curInventoryBuffer = new InventoryBuffer();
        private List<RealTimeTagData> RealTimeTagDataList = new List<RealTimeTagData>();
        string readerInfo;
        int assetId;
        //int idCard;
        private bool m_bDisplayLog = false;
        private int m_nTotal = 0;
        public static string portname;// = "COM3";
        string baudrate = "115200";
        string tokenvalue;
        string ImgFileName;
        string newImgFileNames;
        string language;
        string roleValue;
        int companyId;
        int userId;
        private FilterInfoCollection webcam;
        public static VideoCaptureDevice cam;
        public static bool IsCameraConnected = false;
        string cameraDeviceName;
        string validUntilValue;
        string startDateValue;
        bool isCameraChanged = false;
        bool btnEditInfoWasClicked = false;
        public static bool regOwnerCon = false;
        bool isStartDateTimeChanged = false;
        string userName;
        string ownerPhotoFileName;
        string validIDPhotoFileName;

        public RegisterUser(string tokenvaluesource)
        {
            InitializeComponent();
            getLanguage();
            //languageHandler();
            GetCompanyPath();
            //tokenvalue = tokenvaluesource;
            InitializeCamera();
            InitializePhotoLabel();
            GetRegDefaultImagePath();            
            //CCT.Completed += new EventHandler<PhotoResult>(capture_completed);
            regOwnerCon = true;

            List<GlobalClass.GetSetClass> roles = new List<GlobalClass.GetSetClass>();
            if (language == "Japanese")
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                roles.Add(new GlobalClass.GetSetClass() { roleName = rm.GetString("Administrator"), value = "ROLE_ADMIN" });
                roles.Add(new GlobalClass.GetSetClass() { roleName = rm.GetString("Security"), value = "ROLE_GUARD" });
                //roles.Add(new Role() { roleName = "User", value = "ROLE_USER" });
            }
            else
            {
                roles.Add(new GlobalClass.GetSetClass() { roleName = "Owner", value = "ROLE_OWNER" });
                roles.Add(new GlobalClass.GetSetClass() { roleName = "Administrator", value = "ROLE_ADMIN" });
                roles.Add(new GlobalClass.GetSetClass() { roleName = "Security", value = "ROLE_GUARD" });
                //roles.Add(new Role() { roleName = "User", value = "ROLE_USER" });
            }
            this.cmbauthorities.DataSource = roles;
            this.cmbauthorities.ValueMember = "value";
            this.cmbauthorities.DisplayMember = "roleName";
            
        }

        private void InitializePhotoLabel()
        {
            lblOwnerPhoto.Text = "Step 1" + "\n" + lblOwnerPhoto.Text;
            lblValidIDPhoto.Text = "Step 2" + "\n" + lblValidIDPhoto.Text;
        }

        private void hidePassword()
        {
            if (cmbauthorities.Text.ToLower() == "owner")
            {
                lblPassword.Visible = false;
                lblCpassword.Visible = false;
                txtpassword.Visible = false;
                txtcpassword.Visible = false;
            }
            else
            {
                lblPassword.Visible = true;
                lblCpassword.Visible = true;
                txtpassword.Visible = true;
                txtcpassword.Visible = true;
            }
        }
        private void GetCompanyPath()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    companyId = (int)(key.GetValue("companyId"));
                    roleValue = (string)(key.GetValue("roles"));
                    portname = (string)(key.GetValue("DefaultPortName"));
                    tokenvalue = (string)(key.GetValue("authenticationToken"));
                    userName = (string)(key.GetValue("UserName")).ToString();
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    language = "English";//(string)(key.GetValue("Language"));
                    readerInfo = (string)(key.GetValue("readerInfo"));
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
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                btnCancel.Text = rm.GetString("btnCancel");
                btnSubmit.Text = rm.GetString("btnSubmit");
                groupBox1.Text = rm.GetString("groupBox1");
                groupBox2.Text = rm.GetString("groupBox2");
                lblAuthorities.Text = rm.GetString("lblAuthorities");
                lblCpassword.Text = rm.GetString("lblCpassword");
                lblDesc.Text = rm.GetString("lblDesc");
                lblEmail.Text = rm.GetString("lblEmail");
                lblFname.Text = rm.GetString("lblFname");
                lblLname.Text = rm.GetString("lblLname");
                lblNoCameraAvailable.Text = rm.GetString("lblNoCameraAvailable");
                lblPassword.Text = rm.GetString("lblPassword");
                lblPosition.Text = rm.GetString("lblPosition");
                chkBoxChangeCamera.Text = rm.GetString("chkBoxChangeCamera");
                rbtnValidToday.Text = rm.GetString("rbtnValidToday");
                lblStart.Text = rm.GetString("rbtnValidUntil");
                rbtnValidUntil.Text = rm.GetString("rbtnValidStart");
                rbtnNoExpiration.Text = rm.GetString("rbtnNoExpiration");
                lblTag.Text = rm.GetString("lblTag");
                btnGetRFIDTag.Text = rm.GetString("btnGetRFIDTag");
                btnEditInfo.Text = rm.GetString("btnEditInfo");
                capturedPhotos.Text = rm.GetString("capturedPhotos");
                lblOwnerPhoto.Text = rm.GetString("lblOwnerPhoto");
                lblValidIDPhoto.Text = rm.GetString("lblValidIDPhoto");
                grpExpiration.Text = rm.GetString("grpExpiration");
                this.Text = rm.GetString("RegisterUser");
            }
        }
        private void SubmitImage()
        {
            Bitmap Image = (Bitmap)cameraBox.Image;
            Image.Save("owner.jpg", ImageFormat.Jpeg);

            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
            RestRequest upload = new RestRequest("/api/upload/image", Method.POST);

            upload.AddHeader("X-Auth-Token", tokenvalue);
            upload.AddHeader("Content-Type", "multipart/form-data");
            upload.AlwaysMultipartFormData = true;
            upload.AddFile("file", "owner.jpg", "image/jpg");
            upload.AddParameter("companyId", companyId);
            upload.AddParameter("type", "asset");


            IRestResponse response = client.Execute(upload);
            getCaptureButtonText();
            if (language == "English") btnCancel.Text = "Cancel";
            else 
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                btnCancel.Text = rm.GetString("btnBack"); 
            }

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
        private void GetRegDefaultImagePath()
        {
            try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SavedImagePath");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    txtSaveImageDir.Text = (string)(key.GetValue("DefaultImagePath"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void StartCamera()
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
        public void InitializeCamera()
        {
            try
            {
                if (!isCameraChanged) getAvailableCamera();

                if (comVideoDeviceBox.Items.Count < 1)
                {
                    if (cam != null) cam.Stop();
                    IsCameraConnected = false;
                    cameraBox.BackColor = Color.Black;
                    lblNoCameraAvailable.Visible = true;
                    if (language == "English") CaptureImg.Text = "Refresh Camera";
                    else
                    {
                        ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                        CaptureImg.Text = rm.GetString("btnCameraRefresh");
                    }
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
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getCaptureButtonText()
        {
            if (language == "English")
            {
                if (imgOwnerPhoto.Image == null || imgOwnerPhotoEmpty.Visible) CaptureImg.Text = "Capture Owner Photo";
                else if (imgValidIDPhoto.Image == null || imgValidIDPhotoEmpty.Visible) CaptureImg.Text = "Capture Valid ID Photo";
                else CaptureImg.Text = "Captured Completed";
            }
            else
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                if (imgOwnerPhoto.Image == null) CaptureImg.Text = rm.GetString("ownerCaptureImg");
                else if (imgValidIDPhoto.Image == null) CaptureImg.Text = rm.GetString("IDCaptureImg");
                else CaptureImg.Text = CaptureImg.Text = rm.GetString("CompleteCaptureImg");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            /*if (btnSubmit.Text == "Update")
            {
                register();
            }
            else
            {*/
                if (txtRFIDTag.Text.Length == 0 || txtfirstName.Text.Length == 0 || txtlastName.Text.Length == 0 || txtposition.Text.Length == 0 || txtemail.Text.Length == 0 /*|| string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(cpassword.Text)*/)
                {
                    if (language == "English") MessageBox.Show("Complete information is required.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                    {
                        ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                        MessageBox.Show(rm.GetString("incompleteInfo"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    return;
                }
                else
                {
                    //Validity Validation
                    if (dtStartTimePicker.Checked) startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd") + dtStartTimePicker.Value.ToString("THH:mm");
                    else startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "17:00";

                    if (isStartDateTimeChanged && Convert.ToDateTime(startDateValue) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd THH:mm")))
                    {
                        MessageBox.Show("Start Date must not be less than to current Date and Time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (rbtnValidToday.Checked)
                    {
                        if (Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd T") + "17:00") < Convert.ToDateTime(DateTime.Now.ToString("g")))
                        {
                            MessageBox.Show("ID Validity Period is already expired.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (rbtnValidUntil.Checked)
                    {
                        //startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";

                        //if (dtStartTimePicker.Checked) startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd") + dtStartTimePicker.Value.ToString("THH:mm");
                        //else startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "17:00";

                        if (dtTimePicker.Checked) validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd") + dtTimePicker.Value.ToString("THH:mm");
                        else validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd T") + "17:00";
                        
                        if (Convert.ToDateTime(startDateValue) > Convert.ToDateTime(validUntilValue))
                        {
                            MessageBox.Show("Start Date must not be greater than Until Date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Convert.ToDateTime(validUntilValue) < Convert.ToDateTime(DateTime.Now.ToString("g")))
                        {
                            MessageBox.Show("Until Date must not be less than to current Date and Time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }//end-Validity Validation                   

                    if (cmbauthorities.Text.ToLower() == "administrator" || cmbauthorities.Text.ToLower() == "security")
                    {
                        if (txtpassword.Text.Length < 5)
                        {
                            MessageBox.Show("Password must have 6 or more characters.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtpassword.Focus();
                            return;
                        }
                        else
                        {
                            if (txtpassword.Text != txtcpassword.Text)
                            {
                                MessageBox.Show("Password does not match.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                txtcpassword.Focus();
                                return;
                            }
                            //else
                            //{
                            //    register();
                            //}
                        }
                    }

                    if (btnSubmit.Text.ToUpper() == "SUBMIT" && (imgOwnerPhoto.Image == null || imgValidIDPhoto.Image == null))
                    {
                        if (language == "English")
                        {
                            DialogResult result = MessageBox.Show("Incomplete Owner Pictures." +"\n" + "Are you sure you want to register the owner?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                register();
                                /*if (password.Text.Length < 5)
                                {
                                    MessageBox.Show("Password must have 6 or more characters");                                    
                                    return;
                                }*/
                                /*else
                                {
                                    if (password.Text != cpassword.Text)
                                    {
                                        MessageBox.Show("Password do not match");
                                        return;
                                    }
                                    else
                                    {
                                        register();
                                    }
                                }*/
                            }
                        }
                        else
                        {
                            ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                            DialogResult result = MessageBox.Show(rm.GetString("noPics"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                if (txtpassword.Text.Length < 5)
                                {
                                    MessageBox.Show(rm.GetString("sixChars"));
                                    return;
                                }
                                else
                                {
                                    if (txtpassword.Text != txtcpassword.Text)
                                    {
                                        MessageBox.Show(rm.GetString("invalidConfirm"));
                                        return;
                                    }
                                    else
                                    {
                                        register();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                    //    if (txtpassword.Text.Length < 5)
                    //    {
                    //        ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                    //        if (language == "English") MessageBox.Show("Password must have 6 or more characters");
                    //        else MessageBox.Show(rm.GetString("sixChars"));
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        if (txtpassword.Text != txtcpassword.Text)
                    //        {
                    //            ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                    //            if (language == "English") MessageBox.Show("Password do not match");
                    //            else MessageBox.Show(rm.GetString("invalidConfirm"));
                    //            return;
                    //        }
                    //        else
                    //        {
                        register();
                    //        }
                    //    }
                    }
                }
            /*}*/
        }

        private void register()
        {
            GlobalClass.GetSetClass userinfo = new GlobalClass.GetSetClass();
            String transType;
            if (btnSubmit.Text.ToLower() == "update")
                transType = "UPDATE-Owner";
            else
                transType = "ADD-Owner";

            //save user Information
            userinfo.companyId = companyId;
            userinfo.imageUrl = newImgFileNames;
            userinfo.password = txtpassword.Text;
            userinfo.confirmPassword = txtcpassword.Text;
            userinfo.authorities = cmbauthorities.SelectedValue.ToString();
            userinfo.firstName = txtfirstName.Text;
            userinfo.lastName = txtlastName.Text;
            userinfo.description = description.Text;
            userinfo.position = txtposition.Text;
            userinfo.email = txtemail.Text;

            //save id card information
            userinfo.assetIdCard.companyId = companyId;
            userinfo.assetIdCard.description = txtlastName.Text + ", " + txtfirstName.Text + " - " + "ID_CARD";
            userinfo.assetIdCard.imageUrls = newImgFileNames;
            userinfo.assetIdCard.name = txtlastName.Text + ", " + txtfirstName.Text;
            userinfo.assetIdCard.tag = txtRFIDTag.Text;
            userinfo.assetIdCard.tagType = 1;
            userinfo.assetIdCard.takeOutAllowed = false;
            userinfo.assetIdCard.takeOutInfo = txtlastName.Text + " only";
            userinfo.assetIdCard.ownerId = 1;
            userinfo.assetIdCard.assetType = "ID_CARD";
            //userinfo.assetIdCard.baseLocation = readerInfo;

            if (btnSubmit.Text.ToLower() == "update")
            {
                userinfo.userId = userId;
                userinfo.assetIdCard.assetId = assetId;
                userinfo.assetIdCard.ownerUserId = userId;
            }

            if (dtStartTimePicker.Checked)
                startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd") + dtStartTimePicker.Value.ToString("THH:mm");
            else
                startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";

            if (rbtnValidToday.Checked)
            {
                //if (btnSubmit.Text.ToLower() == "update")
                //    validUntilValue = DateTime.UtcNow.ToString("yyyy-MM-dd T") + "17:00";
                //else
                //{
                    startDateValue = DateTime.UtcNow.ToString("yyyy-MM-dd");
                    validUntilValue = DateTime.UtcNow.ToString("yyyy-MM-dd T") + "17:00";
                //}
            }
            else if (rbtnValidUntil.Checked)
            {
                //if (dtTimePicker.Checked)
                //{
                //    startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";
                //    validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd") + dtTimePicker.Value.ToString("THH:mm");
                //}
                //else
                //{
                //    startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";
                //    validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd T") + "17:00";
                //}

                //if (dtStartTimePicker.Checked)
                //    startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd") + dtStartTimePicker.Value.ToString("THH:mm");
                //else
                //    startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";

                if (dtTimePicker.Checked)
                    validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd") + dtTimePicker.Value.ToString("THH:mm");
                else
                    validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd T") + "17:00";
            }
            else
            {
                //startDateValue = null;
                validUntilValue = null; 
            }

            DateTime? dt = null;
            userinfo.assetIdCard.startDate = startDateValue != null ? Convert.ToDateTime(startDateValue) : dt;
            userinfo.assetIdCard.validUntil = validUntilValue != null ? Convert.ToDateTime(validUntilValue) : dt;

            //use rest service
            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
            RestRequest user;

            if(btnSubmit.Text.ToLower() == "update")
                user = new RestRequest("/api/user/edit", Method.POST);
            else
                user = new RestRequest("/api/user/add", Method.POST);

            var authToken = tokenvalue;
            user.AddHeader("X-Auth-Token", authToken);
            user.AddHeader("Content-Type", "application/json; charset=utf-8");
            user.RequestFormat = DataFormat.Json;
            user.AddBody(userinfo);

            lblSubmittingInformation.Visible = true;
            this.Refresh();

            IRestResponse response = client.Execute(user);
            lblSubmittingInformation.Visible = false;

            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                if (restResult.result == "OK")
                {
                    if (txtpassword.Text != txtcpassword.Text)
                    {
                        if (language == "English") MessageBox.Show("Password do not match");
                        else MessageBox.Show("パスワードが一致しません");

                        return;
                    }
                    SaveTransaction(userinfo.assetIdCard.startDate, userinfo.assetIdCard.validUntil, transType);
                    if (language == "English") MessageBox.Show("Record successfully saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                        MessageBox.Show(rm.GetString("userSave"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ClearFields();
                    //if (language == "English") btnCancel.Text = "Back";
                    //else
                    //{
                    //    ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                    //    btnCancel.Text = rm.GetString("btnCancel");
                    //}
                    //this.Hide();
                    //MainMenu MenuForm = new MainMenu(tokenvalue, string.Empty);
                    //MenuForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(restResult.message);
                }
            }
            else
            {
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                MessageBox.Show("Error " + numericStatusCode);
                return;
            }
        }

        private void AssetValidUntilDateTime()
        {
            //For Valid Until Date
            if (!rbtnValidUntil.Checked)
            {
                if (language == "English")
                {
                    //dtStartDate.CustomFormat = "'Date'";
                    //dtStartDate.Format = DateTimePickerFormat.Custom;

                    //dtStartTimePicker.CustomFormat = "'Time'";
                    //dtStartTimePicker.Format = DateTimePickerFormat.Custom;
                    //dtStartTimePicker.Checked = false;

                    dtDatePicker.CustomFormat = "'Date'";
                    dtDatePicker.Format = DateTimePickerFormat.Custom;

                    dtTimePicker.CustomFormat = "'Time'";
                    dtTimePicker.Format = DateTimePickerFormat.Custom;
                    dtTimePicker.Checked = false;
                    dtTimePicker.Enabled = false;
                }
                else
                {
                    ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                    //dtStartDate.CustomFormat = rm.GetString("dtDate");
                    //dtStartDate.Format = DateTimePickerFormat.Custom;

                    dtDatePicker.CustomFormat = rm.GetString("dtDate");
                    dtDatePicker.Format = DateTimePickerFormat.Custom;

                    dtTimePicker.CustomFormat = rm.GetString("dtTimePicker");
                    dtTimePicker.Format = DateTimePickerFormat.Custom;
                    dtTimePicker.Checked = false;
                }
            }
            else
            {
                //For Valid Until Date
                //dtStartDate.CustomFormat = "MM/dd/yyyy";
                //dtStartDate.Format = DateTimePickerFormat.Custom;
                //dtStartDate.Value = DateTime.Now;

                dtDatePicker.CustomFormat = "MM/dd/yyyy";
                dtDatePicker.Format = DateTimePickerFormat.Custom;
                dtDatePicker.Value = DateTime.Now;

                //dtStartTimePicker.CustomFormat = "'Time'";
                //dtStartTimePicker.Format = DateTimePickerFormat.Custom;
                //dtStartTimePicker.Checked = false;

                dtTimePicker.CustomFormat = "'Time'";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
                dtTimePicker.Checked = false;
                dtTimePicker.Enabled = true;
            }

            ////For Valid Until Date
            //if (!dtDatePicker.Checked)
            //{
            //    dtDatePicker.CustomFormat = "'Date'";
            //    dtDatePicker.Format = DateTimePickerFormat.Custom;
            //}
            //else
            //{
            //    //dtDatePicker.CustomFormat = "hh:mm tt";
            //    dtDatePicker.CustomFormat = "MM/dd/yyyy";
            //    dtDatePicker.Format = DateTimePickerFormat.Custom;
            //}

            ////For Valid Until Time
            //if (!dtTimePicker.Checked)
            //{
            //    dtTimePicker.CustomFormat = "'Time'";
            //    dtTimePicker.Format = DateTimePickerFormat.Custom;
            //}
            //else
            //{
            //    //dtTimePicker.CustomFormat = "hh:mm tt";
            //    dtTimePicker.CustomFormat = "h:mm tt";
            //    dtTimePicker.Format = DateTimePickerFormat.Custom;
            //}

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
            //if (btnCancel.Text.ToLower() == "back" || btnCancel.Text == rm.GetString("btnCancel"))
            //{
            //    CallMainMenu();
            //    return;
            //}
            //else
            //{
            //    if (btnSubmit.Text.ToLower() == "update")
            //    {
            //        DialogResult result = MessageBox.Show("Are you sure you want to cancel update?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //        if (result == DialogResult.Yes)
            //        {
            //            //CallMainMenu();
            //            ClearFields();
            //        }
            //    }
            //    else if (txtRFIDTag.Text.Length != 0 || imgCapture1.Image != null)
            //    {
            //        DialogResult result = MessageBox.Show("Are you sure you want to exit the user registration?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //        if (result == DialogResult.Yes)
            //        {
            //            //CallMainMenu();
            //            ClearFields();
            //        }
            //    }
            //}
            //cam.Stop();
            if (txtfirstName.Text.Length != 0 || txtRFIDTag.Text.Length != 0 || imgOwnerPhoto.Image != null)
            {
                string cancelMsg;

                if (btnSubmit.Text.ToUpper() == "SUBMIT" || btnSubmit.Text == "提出する")
                {
                    if (language == "English") cancelMsg = "Are you sure you want to cancel the registration?";
                    else cancelMsg = "登録を取り消すにしてもよろしいですか？";
                }
                else
                {
                    if (language == "English") cancelMsg = "Are you sure you want to cancel the update?";
                    else cancelMsg = "更新を取り消すにしてもよろしいですか？";
                }

                DialogResult result = MessageBox.Show(cancelMsg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //CallMainMenu();
                    ClearFields();
                }
                else
                {
                    btnGetRFIDTag.Focus();
                    return;
                }
            }
        }
        private void CallMainMenu()
        {
            try
            {
                //Back to Main Menu 
                if (IsCameraConnected)
                    cam.Stop();

                this.Hide();
                reader.CloseCom();
                //MainMenu MenuForm = new MainMenu(tokenvalue, string.Empty);
                //MenuForm.Show();
                //this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            txtRFIDTag.Text = string.Empty;
            txtfirstName.Text = string.Empty;
            txtlastName.Text = string.Empty;
            txtposition.Text = string.Empty;
            description.Text = string.Empty;
            txtemail.Text = string.Empty;
            imgOwnerPhoto.Image = null;
            imgValidIDPhoto.Image = null;
            txtpassword.Text = string.Empty;
            txtcpassword.Text = string.Empty;
            txtemail.Enabled = true;
            cmbauthorities.Text = "Owner";

            //rbtnValidToday.Checked = true;
            rbtnValidUntil.Checked = true;
            StartValidUntilDateTime();
            AssetValidUntilDateTime();
            //dtStartDate.Enabled = true;

            //btnSubmit.Width = 265;
            if (language == "English")
            {
                CaptureImg.Text = "Capture Owner Photo";
                btnSubmit.Text = "Submit";
                //btnCancel.Text = "Back"; 
            }
            else
            {
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                CaptureImg.Text = rm.GetString("CaptureImg");
                btnSubmit.Text = rm.GetString("btnSubmit");
                btnCancel.Text = rm.GetString("btnCancel");
            }
            btnGetRFIDTag.Focus();
            isStartDateTimeChanged = false;
            imgOwnerPhotoEmpty.Visible = false;
            imgValidIDPhotoEmpty.Visible = false;
            chkUpdateOwnerPhoto.Visible = false;
            chkUpdateOwnerPhoto.Checked = false;
            chkUpdateValidIDPhoto.Visible = false;
            chkUpdateValidIDPhoto.Checked = false;
            ownerPhotoFileName = string.Empty;
            validIDPhotoFileName = string.Empty;
            lblValidIDPhoto.Visible = true;
            lblOwnerPhoto.Visible = true;
            this.Refresh();
        }

        private void StartValidUntilDateTime()
        {
            dtStartDate.CustomFormat = "MM/dd/yyyy";
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.Value = DateTime.Now;

            dtStartTimePicker.CustomFormat = "'Time'";
            dtStartTimePicker.Format = DateTimePickerFormat.Custom;
            dtStartTimePicker.Checked = false;
        }

        private void SaveTransaction(DateTime? startDate, DateTime? validUntil, string type)
        {
            //Saving to transaction table
            try
            {
                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                //transactDet.companyId = companyId;//1;
                //transactDet.readerInfo = readerInfo;
                //transactDet.type = type;
                ////transactDet.readerId = 1;
                ////transactDet.notes = txtExplanationNotes.Text.Trim();
                ////transactDet.imageUrl = newImgFileNames;//txtCapturedImagePath.Text;//txtImagePath.Text;

                transactDet.companyId = companyId;//1;
                transactDet.validityPeriod = validUntil == null ? "Start " + startDate.Value.ToString("g") + " - No End Date" : "Start " + startDate.Value.ToString("g") + " Until " + validUntil.Value.ToString("g");
                transactDet.ownerName = txtlastName.Text + ", " + txtfirstName.Text;
                transactDet.position = txtposition.Text;
                transactDet.email = txtemail.Text;
                transactDet.userType = cmbauthorities.SelectedValue.ToString();//cmbauthorities.Text;
                transactDet.description = transactDet.ownerName + " - " + "ID_CARD";
                transactDet.takeOutNote = txtlastName.Text + " Only";
                transactDet.ownerImageUrl = newImgFileNames;
                //transactDet.assetImageUrl = newImgFileNames;
                transactDet.updatedBy = userName;
                transactDet.readerInfo = readerInfo;
                //transactDet.notes = notes;
                transactDet.type = type;
                //transactDet.assetId = assetId;
                //transactDet.location = readerInfo;
                transactDet.classType = "ID_CARD";

                //Gettting the assetId
                //ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                if (btnSubmit.Text.ToUpper() == "SUBMIT" /*|| btnSubmit.Text == rm.GetString("btnSubmit")*/)
                {
                    GlobalClass.GetSetClass getAsset = new GlobalClass.GetSetClass();

                    getAsset.companyId = companyId;
                    getAsset.tag = txtRFIDTag.Text;
                    getAsset.tagType = 1;

                    RestClient clientinfo = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
                    RestRequest assetinfo = new RestRequest("/api/asset/company-tag", Method.POST);

                    assetinfo.RequestFormat = DataFormat.Json;
                    assetinfo.AddHeader("Content-Type", "application/json; charset=utf-8");
                    assetinfo.AddHeader("X-Auth-Token", tokenvalue);
                    assetinfo.AddBody(getAsset);

                    IRestResponse responseinfo = clientinfo.Execute(assetinfo);
                    var contentinfo = responseinfo.Content;

                    if (responseinfo.StatusCode == HttpStatusCode.OK)
                    {
                        JsonDeserializer deserial = new JsonDeserializer();
                        GlobalClass.GetSetClass assetInfo = deserial.Deserialize<GlobalClass.GetSetClass>(responseinfo);

                        assetId = assetInfo.assetId;
                    }
                }
                transactDet.assetId = assetId;
                //end-Getting assetId

                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
                RestRequest transact = new RestRequest("/api/asset/transact", Method.POST);

                var authToken = tokenvalue;
                transact.AddHeader("X-Auth-Token", authToken);
                transact.AddHeader("Content-Type", "application/json; charset=utf-8");
                transact.RequestFormat = DataFormat.Json;
                transact.AddBody(transactDet);

                //lblSubmittingInformation.Visible = true;
                //this.Refresh();

                IRestResponse response = client.Execute(transact);
                //lblSubmittingInformation.Visible = false;

                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                    if (restResult.result != "OK")
                    {
                        if (language == "English") MessageBox.Show("Saving transaction..." + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       //else MessageBox.Show(rm.GetString("saveTrans") + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (language == "English") MessageBox.Show("Saving transaction..." + "\n" + "Error Code " + response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    //else MessageBox.Show(rm.GetString("saveTrans") + "\n" + "Error Code " + response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    return;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            try
            {
                reader = new Reader.ReaderMethod();
                AssetValidUntilDateTime();
                ////Callback
                //reader.AnalyCallback = AnalyData;
                //reader.ReceiveCallback = ReceiveData;
                //reader.SendCallback = SendData;
                //auto_connect();
                ReaderMethodProc();
                hidePassword();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOwnerInfo(int id, DateTime? validity)
        {
            try
            {
                //var company = 1;             

                //initialize Rest Client
                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
                RestRequest ownerInfo = new RestRequest("/api/user/" + id, Method.GET);

                var authToken = tokenvalue;

                //add needed headers
                ownerInfo.RequestFormat = DataFormat.Json;
                ownerInfo.AddHeader("Content-Type", "application/json; charset=utf-8");
                ownerInfo.AddHeader("X-Auth-Token", authToken);

                //execute request
                var response = client.Execute<GlobalClass.GetSetClass>(ownerInfo);
                var content = response.Content;

               if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize json response into object
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass info = deserial.Deserialize<GlobalClass.GetSetClass>(response);
                    
                    userId = id;
                    txtfirstName.Text = info.firstName;
                    txtlastName.Text = info.lastName;
                    txtposition.Text = info.position;
                    txtemail.Text = info.email;
                    txtpassword.Text = info.password;
                    newImgFileNames = info.imageUrl;
                    
                    string urls = info.imageUrl;
                    if (urls != null)
                    {
                        string[] ReadUrls = urls.Split(',');
                        if (ReadUrls.Length > 0)
                        {
                            imgOwnerPhoto.Load("http://52.163.93.95:8080/FeatherAssets/api/images/" + companyId + "/asset/" + ReadUrls[0]);
                            lblOwnerPhoto.Visible = false;
                            ownerPhotoFileName = ReadUrls[0];
                            //chkUpdateOwnerPhoto.Visible = true;
                            imgOwnerPhotoEmpty.Visible = false;
                        }
                        if (ReadUrls.Length > 1)
                        {
                            imgValidIDPhoto.Load("http://52.163.93.95:8080/FeatherAssets/api/images/" + companyId + "/asset/" + ReadUrls[1]);
                            lblValidIDPhoto.Visible = false;
                            validIDPhotoFileName = ReadUrls[1];
                            //chkUpdateValidIDPhoto.Visible = true;
                            imgValidIDPhotoEmpty.Visible = false;
                        }
                    }
                   getCaptureButtonText();
                   if (validity < Convert.ToDateTime(DateTime.Now.ToString("g")) && validity != DateTime.MinValue)
                   {
                       MessageBox.Show("ID is already expired.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                                     
                    if (info.authorities == "ROLE_ADMIN")
                    {
                        cmbauthorities.Text = "Administrator";
                    }
                    else if (info.authorities == "ROLE_GUARD")
                    {
                        cmbauthorities.Text = "Security";
                    }
                    else
                    {
                        cmbauthorities.Text = "Owner";
                    }

                    //name = info.lastName + " " + info.lastName;

                }
                else
                {
                    HttpStatusCode statusCode = response.StatusCode;
                    int numericStatusCode = (int)statusCode;

                    if (numericStatusCode == 401)
                    {
                        MessageBox.Show("Unauthorized Access");
                    }
                    else if (numericStatusCode == 500)
                    {
                        MessageBox.Show("User is not registered.");
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to server... Please try again later");
                    }

                    //Application.Restart();
                    /*this.Hide();                   
                    LoginActivity loginActivity = new LoginActivity();
                    loginActivity.Show();*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOwnerId()
        {
            lblLoadingInformation.Visible = true;
            lblLoadingInformation.Refresh();

            GlobalClass.GetSetClass getAsset = new GlobalClass.GetSetClass();

            getAsset.companyId = companyId;
            getAsset.tagType = 1;
            getAsset.tag = txtRFIDTag.Text;

            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://127.0.0.1:8080/");
            RestRequest assetinfo = new RestRequest("/api/asset/company-tag", Method.POST);

            assetinfo.RequestFormat = DataFormat.Json;
            assetinfo.AddHeader("Content-Type", "application/json; charset=utf-8");
            assetinfo.AddHeader("X-Auth-Token", tokenvalue);
            assetinfo.AddBody(getAsset);

            IRestResponse response = client.Execute(assetinfo);
            var content = response.Content;

            lblLoadingInformation.Visible = false;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                GlobalClass.GetSetClass assetInfo = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                if (!assetInfo.description.Contains("ID_CARD"))
                {
                    MessageBox.Show("Scanned RFID Tag is Asset. Please scan the ID Tag.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                    return;
                }
                else
                {
                    btnSubmit.Text = "Update";
                    assetId = assetInfo.assetId;
                    
                    startDateValue = assetInfo.startDate.Value.ToString("yyyy-MM-dd");
                    dtStartDate.Value = Convert.ToDateTime(startDateValue);
                    startDateValue = assetInfo.startDate.Value.ToString("HH:mm tt");
                    dtStartTimePicker.Value = Convert.ToDateTime(startDateValue);
                    dtStartTimePicker.Checked = true;

                    if (assetInfo.validUntil == null) 
                        rbtnNoExpiration.Checked = true;
                    else
                    {
                        //dtStartDate.Enabled = false;
                        rbtnValidUntil.Checked = true;
                        //startDateValue = assetInfo.startDate.Value.ToString("yyyy-MM-dd");
                        validUntilValue = assetInfo.validUntil.Value.ToString("yyyy-MM-dd");
                        //dtStartDate.Value = Convert.ToDateTime(startDateValue);
                        dtDatePicker.Value = Convert.ToDateTime(validUntilValue);

                        //if (Convert.ToDateTime(assetInfo.validUntil).ToString("HH:mm") != "00:00")
                        //{
                        //startDateValue = assetInfo.startDate.Value.ToString("HH:mm tt");
                        //dtStartTimePicker.Value = Convert.ToDateTime(startDateValue);
                        //dtStartTimePicker.Checked = true;
                        validUntilValue = assetInfo.validUntil.Value.ToString("HH:mm tt");
                        dtTimePicker.Value = Convert.ToDateTime(validUntilValue);
                        dtTimePicker.Checked = true;
                        //AssetValidUntilTime();
                        //}
                    }
                    AssetValidUntilTime();
                    getOwnerInfo(assetInfo.ownerUserId, assetInfo.validUntil);
                    chkUpdateOwnerPhoto.Visible = true;
                    chkUpdateValidIDPhoto.Visible = true;
                }
            }
            else
            {
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;

                if (numericStatusCode == 401)
                {
                    MessageBox.Show("Unauthorized Access");
                }
                else if (numericStatusCode == 500)
                {
                    MessageBox.Show("User is not registered.");
                }
                else
                {
                    MessageBox.Show("Error connecting to server... Please try again later");
                }

                ClearFields();
                //return;
            }
        }

        private void CaptureImg_Click(object sender, EventArgs e)
        {
            try
            {               
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                if (cam == null || CaptureImg.Text == "Refresh Camera" || CaptureImg.Text == rm.GetString("btnCameraRefresh"))
                {
                    InitializeCamera();
                }

                else if (IsCameraConnected)
                {
                    if (imgValidIDPhoto.Image == null || imgValidIDPhotoEmpty.Visible || chkUpdateOwnerPhoto.Checked)
                    {
                        if (language == "English")
                        {
                            //CaptureImg.Enabled = false;
                            CaptureImg.Text = "Processing. Please wait...";
                        }
                        else
                        {
                            //ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.UserRegistration", Assembly.GetExecutingAssembly());
                            CaptureImg.Text = rm.GetString("processing");
                        }
                        CaptureImg.Refresh();
                    }

                    if (imgOwnerPhoto.Image == null || imgOwnerPhotoEmpty.Visible)
                    {
                        imgOwnerPhoto.Image = cameraBox.Image;
                        lblOwnerPhoto.Visible = false;
                        imgOwnerPhotoEmpty.Visible = false;
                        SubmitImage();
                        ownerPhotoFileName = ImgFileName;
                    }
                    else if (imgValidIDPhoto.Image == null || imgValidIDPhotoEmpty.Visible)
                    {
                        imgValidIDPhoto.Image = cameraBox.Image;
                        lblValidIDPhoto.Visible = false;
                        imgValidIDPhotoEmpty.Visible = false;
                        SubmitImage();
                        validIDPhotoFileName = ImgFileName;
                    }
                    else
                    {
                        if (language == "English") MessageBox.Show("Captured images are already completed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);//("You can save only 2 images.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show(rm.GetString("maxImages"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //SubmitImage();
                    //if (btnSubmit.Text.ToLower() == "submit")
                    //    newImgFileNames = newImgFileNames + "," + ImgFileName;
                    //else
                    newImgFileNames = ownerPhotoFileName + (validIDPhotoFileName != string.Empty ? "," + validIDPhotoFileName : ""); //+ "," + validIDPhotoFileName;//newImgFileNames + "," + ImgFileName;
                    cam.Stop();
                    //CaptureImg.Enabled = true;
                    InitializeCamera();
                    
                }
            }
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnBrowseImageDir_Click(object sender, EventArgs e)
        {
            try
            { 
                if (imagePathDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSaveImageDir.Text = imagePathDialog.SelectedPath;

                    //accessing the CurrentUser root element  
                    //and adding "DefaultImagePath" subkey to the "SOFTWARE" subkey  
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SavedImagePath");

                    //storing the values  
                    key.SetValue("DefaultImagePath", txtSaveImageDir.Text);
                    key.Close();  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }

        private void firstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void lastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void position_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        private void cpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSubmit_Click(sender, e);
            }
        }

        #region Reader Procedure
        //start of the Reader's default codes//
        private void ReceiveData(byte[] btAryReceiveData)
        {
            try
            {
                if (m_bDisplayLog)
                {
                    string strLog = CCommondMethod.ByteArrayToString(btAryReceiveData, 0, btAryReceiveData.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendData(byte[] btArySendData)
        {
            try
            {
                if (m_bDisplayLog)
                {
                    string strLog = CCommondMethod.ByteArrayToString(btArySendData, 0, btArySendData.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AnalyData(Reader.MessageTran msgTran)
        {
            try
            {
                if (msgTran.PacketType != 0xA0)
                {
                    return;
                }
                switch (msgTran.Cmd)
                {
                    case 0x81:
                        ProcessReadTag(msgTran);
                        break;
                    case 0x89:
                        ProcessInventoryReal(msgTran);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessReadTag(Reader.MessageTran msgTran)
        {
            string strCmd = "Reading the label";
            string strErrorCode = string.Empty;
            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "Failure, failure reasons:" + strErrorCode;
                m_curSetting.btRealInventoryFlag = 100; //The reader returns the error message
            }
            else
            {
                RealTimeTagData tagData = new RealTimeTagData();
                int nLen = msgTran.AryData.Length;
                int nDataLen = Convert.ToInt32(msgTran.AryData[nLen - 3]);
                int nEpcLen = Convert.ToInt32(msgTran.AryData[2]) - nDataLen - 4;

                string strPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, 2);
                string strEPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 5, nEpcLen);
                string strCRC = CCommondMethod.ByteArrayToString(msgTran.AryData, 5 + nEpcLen, 2);
                string strData = CCommondMethod.ByteArrayToString(msgTran.AryData, 7 + nEpcLen, nDataLen);

                byte byTemp = msgTran.AryData[nLen - 2];
                byte byAntId = (byte)((byTemp & 0x03) + 1);

                tagData.strEpc = strEPC;
                tagData.strPc = strPC;
                tagData.strTid = strData;
                tagData.btAntId = byAntId;

                RealTimeTagDataList.Add(tagData);

                int nReaddataCount = msgTran.AryData[0] * 255 + msgTran.AryData[1]; //The total number of data
                if (RealTimeTagDataList.Count == nReaddataCount)  //All data received
                {
                    m_curSetting.btRealInventoryFlag = 1; //The reader returns the error message
                }
            }
        }

        private void ProcessInventoryReal(Reader.MessageTran msgTran)
        {
            string strCmd = "";
            strCmd = "Real-time inventory";
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1) //You receive an error message packet
            {
                strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "Failure, failure reasons: " + strErrorCode;
                m_curSetting.btRealInventoryFlag = 100; //The reader return inventory error
                //WriteLog(RecordLogBox, strLog, 1);


            }
            else if (msgTran.AryData.Length == 7) //End packet received command
            {
                m_curInventoryBuffer.nReadRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                m_curInventoryBuffer.nDataCount = Convert.ToInt32(msgTran.AryData[3]) * 256 * 256 * 256 + Convert.ToInt32(msgTran.AryData[4]) * 256 * 256 + Convert.ToInt32(msgTran.AryData[5]) * 256 + Convert.ToInt32(msgTran.AryData[6]);
                m_curSetting.btRealInventoryFlag = 1; //Inventory command ends successfully received packet
                //WriteLog(RecordLogBox, strCmd, 0);
            }
            else //Receive real-time tag data
            {
                m_nTotal++;
                int nLength = msgTran.AryData.Length;
                int nEpcLength = nLength - 4;
                RealTimeTagData tagData = new RealTimeTagData();

                string strEPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                string strPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 2);
                string strRSSI = (msgTran.AryData[nLength - 1] - 129).ToString() + " dBm";
                byte btTemp = msgTran.AryData[0];
                byte btAntId = (byte)((btTemp & 0x03) + 1);
                byte btFreq = (byte)(btTemp >> 2);
                // string strFreq = GetFreqString(btFreq) + " MHz";

                tagData.strEpc = strEPC;
                tagData.strPc = strPC;
                tagData.strRssi = strRSSI;
                //tagData.strCarrierFrequency = strFreq;
                tagData.btAntId = btAntId;

                RealTimeTagDataList.Add(tagData);
            }
        }

        //Note: In the function call in this function and do not update interface, because the UI thread is waiting for this function returns.
        private int realTimeInventory(byte btReaderId, byte btRepeat, byte btTimeOut)
        {
            DateTime startTime;
            TimeSpan timeOutControl;

            //The method used here waiting for data, after all the data has been received for processing
            m_curSetting.btRealInventoryFlag = 0;
            RealTimeTagDataList.Clear();  //Empty tag information table
            reader.InventoryReal(255, 1); // To send real-time inventory command, with 0xFF public address, each command is repeated once inventory
            startTime = DateTime.Now;

            while (m_curSetting.btRealInventoryFlag == 0) //Wait for the reader to return data is completed, if timeout, returning timeout flag
            {
                timeOutControl = DateTime.Now - startTime;
                if (timeOutControl.TotalMilliseconds > btTimeOut * 1000)//Timeout Returns
                {
                    return -2;
                }
            }

            if (m_curSetting.btRealInventoryFlag == 1) //The command completed successfully
            {
                if (RealTimeTagDataList.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (m_curSetting.btRealInventoryFlag == 100) //Command fails
            {
                return -1;
            }
            return 0;
        }

        private void auto_connect()
        {
            try // Await the task in a try block
            {
                string strException = string.Empty; // 

                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AssetSystemInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    portname = (string)(key.GetValue("DefaultPortName"));
                }
                string strComPort = portname;

                int nBaudrate = Convert.ToInt32(baudrate);////Convert.ToInt32(BaudBox.Text);

                int nRet = reader.OpenCom(strComPort, nBaudrate, out strException);

                ////string strLog = "Connection readers" + strComPort + "@" + nBaudrate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void CallSerialPortSelection()
        {
            try
            {
                //if (IsCameraConnected)
                //    cam.Stop();
                //reader.CloseCom();

                SerialPortSelection PortSelectionForm = new SerialPortSelection(tokenvalue, roleValue);

                // Show PortSelectionForm as a modal dialog and determine if DialogResult = OK.
                if (PortSelectionForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of PortSelectionForm's cmbComPortList.
                    portname = PortSelectionForm.cmbComPortList.SelectedItem.ToString();//.Text;
                }
                //else CallMainMenu();

                PortSelectionForm.Dispose();
                //ReaderMethodProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetRFIDTag_Click(object sender, EventArgs e)
        {
            //ReaderMethodProc();
            //ClearFields();
            try
            {
                /*if (btnSubmit.Text.ToLower() == "update" || ((!string.IsNullOrEmpty(firstName.Text) || imgCapture1.Image != null) && btnCancel.Text.ToLower() == "cancel"))
                {
                    btnCancel.PerformClick();
                    return;
                }*/
                if (btnSubmit.Text.ToLower() == "update")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel the update?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        //CallMainMenu();
                        ClearFields();
                    }
                    else return;
                }
                else if (/*txtfirstName.Text.Length != 0 ||*/ (txtRFIDTag.Text.Length != 0 || imgOwnerPhoto.Image != null) && btnEditInfoWasClicked)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel the registration?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        //CallMainMenu();
                        ClearFields();
                    }
                    else return;
                }
                //else if (btnSubmit.Text.ToLower() == "update" || ((!string.IsNullOrEmpty(txtfirstName.Text) || imgOwnerPhoto.Image != null) && btnCancel.Text.ToLower() == "cancel"))
                //{
                //    btnCancel.PerformClick();
                //    return;
                //}

                //string strException = string.Empty;
                //int nRet = reader.OpenCom(portname, Convert.ToInt32(baudrate), out strException); 
                auto_connect();//ReaderMethodProc();

                int nReturnValue = 0;
                string tagInfo = "";
                //listBox1.Items.Clear();

                nReturnValue = realTimeInventory(255, 255, 1);  //Public address reader , fast inventory mode , 5 seconds timeout control

                if (nReturnValue == 1)
                {
                    for (int i = 0; i < RealTimeTagDataList.Count; i++)
                    {
                        tagInfo = RealTimeTagDataList[i].strEpc.Replace(" ", string.Empty); //RealTimeTagDataList[i].strEpc;//tagInfo = RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    ";// tagInfo = "antenna" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    " + RealTimeTagDataList[i].strCarrierFrequency + "    " + RealTimeTagDataList[i].strRssi;
                        //listBox1.Items.Add(tagInfo);
                        txtRFIDTag.Text = tagInfo.ToString();
                        txtfirstName.Focus();//txtAssetName.Focus();
                        if (language == "English")
                        {
                            //btnCancel.Text = "Cancel";
                            //btnSubmit.Width = 136;
                        }
                        else btnCancel.Text = "キャンセル";
                        if (btnEditInfoWasClicked)
                        {
                            //btnSubmit.Text = "Update";
                            getOwnerId();
                            //getCaptureButtonText();
                            //email.Enabled = false;
                            //btnCancel.Text = "Cancel";
                            //btnSubmit.Text = "Update";
                            //txtemail.Enabled = false;
                            //chkUpdateOwnerPhoto.Visible = true;
                            //chkUpdateValidIDPhoto.Visible = true;
                        }
                    }
                }
                //else if (nReturnValue == 0)
                //{
                //    MessageBox.Show("Successful execution of the command but no inventory to tag");
                //}
                else if (nReturnValue == -1)
                {
                    //MessageBox.Show("Reader Com Port Error", "Asset Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //cam.Stop();
                    //CallMainMenu();
                    CallSerialPortSelection();
                }
                else if (nReturnValue == -2)
                {
                    //MessageBox.Show("Reader Com Port Error", "Asset Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //cam.Stop();
                    //CallMainMenu();
                    CallSerialPortSelection();
                }
                else
                {
                    MessageBox.Show("No ID tag scan.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //ReaderMethodProc();
            }
            catch (Exception ex)
            {
                if (language == "English") MessageBox.Show(ex.Message + "\n" + "Reader is not connected.");
                else MessageBox.Show(ex.Message + "\n" + "リーダーが接続されていません.");
            }

            if(language.ToLower() == "english") btnCancel.Text = "Cancel";
            else btnCancel.Text = "キャンセル";
        }

        public void ReaderMethodProc()
        {
            reader.AnalyCallback = AnalyData;
            reader.ReceiveCallback = ReceiveData;
            reader.SendCallback = SendData;
            auto_connect();
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

        private void rbtnValidUntil_CheckedChanged(object sender, EventArgs e)
        {
            AssetValidUntilDateTime();
        }

        private void RegisterUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            CallMainMenu();
        }

        private void dtTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AssetValidUntilTime();
        }

        private void AssetValidUntilTime()
        {
            //For Valid Until Time
            if (!dtTimePicker.Checked)
            {
                dtTimePicker.CustomFormat = "'Time'";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                //dtTimePicker.CustomFormat = "hh:mm tt";
                dtTimePicker.CustomFormat = "h:mm tt";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
                //dtTimePicker.Value = DateTime.Now;
            }

            if (!dtStartTimePicker.Checked)
            {
                dtStartTimePicker.CustomFormat = "'Time'";
                dtStartTimePicker.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                //dtTimePicker.CustomFormat = "hh:mm tt";
                dtStartTimePicker.CustomFormat = "h:mm tt";
                dtStartTimePicker.Format = DateTimePickerFormat.Custom;
                //dtTimePicker.Value = DateTime.Now;
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            //if (btnSubmit.Text.ToLower() == "update" || ((!string.IsNullOrEmpty(txtfirstName.Text) || imgOwnerPhoto.Image != null) && btnCancel.Text.ToLower() == "cancel"))
            //{
            //    btnCancel.PerformClick();
            //    return;
            //}

            btnEditInfoWasClicked = true;

            btnGetRFIDTag.PerformClick();
            //if (!string.IsNullOrEmpty(txtRFIDTag.Text))
            //{
            //    getOwnerId();
            //    getCaptureButtonText();
            //    //email.Enabled = false;
            //    btnCancel.Text = "Cancel";
            //    btnSubmit.Text = "Update";
            //}
            //else
            //{
            //    MessageBox.Show("ID not found");
            //}
            btnEditInfoWasClicked = false;
        }

        private void dtStartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AssetValidUntilTime();
        }

        private void authorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidePassword();
            txtpassword.Text = string.Empty;
            txtcpassword.Text = string.Empty;
        }

        private void RegisterUser_Leave(object sender, EventArgs e)
        {
            //if (IsCameraConnected)
            //    cam.Stop();

            ////this.Hide();
            //reader.CloseCom();
            //if (AssetRegistration.IsCameraConnected && !RegisterUser.IsCameraConnected)
            //    AssetRegistration.cam.Stop();

            //StartCamera();
        }

        private void dtStartDate_MouseDown(object sender, MouseEventArgs e)
        {
            isStartDateTimeChanged = true;
        }

        private void dtStartTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            isStartDateTimeChanged = true;
        }

        private void chkUpdateOwnerPhoto_MouseHover(object sender, EventArgs e)
        {
            toolTipUpdatePhoto.SetToolTip(chkUpdateOwnerPhoto, "Check to update the Owner Photo");
        }

        private void chkUpdateValidIDPhoto_MouseHover(object sender, EventArgs e)
        {
            toolTipUpdatePhoto.SetToolTip(chkUpdateValidIDPhoto, "Check to update the Valid ID Photo");
        }

        private void chkUpdateOwnerPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateOwnerPhoto.Checked)
            {
                imgOwnerPhotoEmpty.Visible = true;
                lblOwnerPhoto.Visible = true;
            }
            else
            {
                imgOwnerPhotoEmpty.Visible = false;
                lblOwnerPhoto.Visible = false;
            }
            getCaptureButtonText();
        }

        private void chkUpdateValidIDPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateValidIDPhoto.Checked)
            {
                imgValidIDPhotoEmpty.Visible = true;
                lblValidIDPhoto.Visible = true;
            }
            else
            {
                imgValidIDPhotoEmpty.Visible = false;
                lblValidIDPhoto.Visible = false;
            }
            getCaptureButtonText();
        }
    }

    
    


    //public class userInfo
    //{
    //    AssetDto assetDto = new AssetDto();
    //    public string firstName { get; set; }
    //    public int companyId { get; set; }
    //    public string confirmPassword { get; set; }
    //    public string authorities { get; set; }
    //    public string lastName { get; set; }
    //    public string imageUrl { get; set; }
    //    public string position { get; set; }
    //    public string description {get; set; }
    //    public string password { get; set; }
    //    public string email { get; set; }
    //    public AssetDto assetIdCard = new AssetDto();
    //}

    //public class AssetDto
    //{
    //    public int companyId { get; set; }
    //    public int ownerId { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public string tag { get; set; }
    //    public int tagType { get; set; }
    //    public string imageUrls { get; set; }
    //    public bool takeOutAllowed { get; set; }
    //    public string takeOutInfo { get; set; }
    //    public DateTime? validUntil { get; set; }

    //}

    //public class Role
    //{
    //    public string roleName { get; set; }
    //    public string value { get; set; }
    //}
}