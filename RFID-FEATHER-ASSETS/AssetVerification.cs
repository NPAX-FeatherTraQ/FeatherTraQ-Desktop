using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UHFDemo;
using System.IO;
using RestSharp;
using System.Net;
using RestSharp.Deserializers;
using System.Threading;
using Microsoft.Win32;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Media;

namespace RFID_FEATHER_ASSETS
{
    public partial class Verification : Form
    {
        //string connectionString = "server=128.199.83.107;port=3306;uid=root;pwd=aws123;database=feather_assets;";
        public static int AssetIdValue = 0;
        public int companyId;
        string readerInfo;

        private Reader.ReaderMethod reader;
        private ReaderSetting m_curSetting = new ReaderSetting();
        private InventoryBuffer m_curInventoryBuffer = new InventoryBuffer();
        private List<RealTimeTagData> RealTimeTagDataList = new List<RealTimeTagData>();
        private bool m_bDisplayLog = false;
        private int m_nTotal = 0;
        string portname; //= "COM3";
        string baudrate = "115200";
        //bool IsPortError = false;
        string tokenvalue;
        string language;
        bool IsCallingMainMenu = false;
        string roleValue;
        int userId;
        //int companyId;
        bool IsRFIDTagExist = false;
        int totalAssetRead = 0;
        //string updatedImgFileNames;
        //string assetName;
        bool IsStopComparing = false;
        int startRowComparing;

        public Verification()//string tokenvaluesource, string roleSource) //(string tokenvaluesource, string portnamesource, string roleSource)
        {
            InitializeComponent();

            getLanguage();
            languageHandler();
            GetAssetSystemInfo();
            //tokenvalue = tokenvaluesource;
            //roleValue = roleSource;
            try { ReadLoopTimer.Start(); }
            catch (Exception) { }
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
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.AssetVerification", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                lblOwnerPic.Text = rm.GetString("lblOwnerPic");
                lblOwnerPhoto.Text = rm.GetString("lblOwnerPhoto");
                lblValidIDPhoto.Text = rm.GetString("lblValidIDPhoto");
                lblTag.Text = rm.GetString("lblTag");
                lblDesc.Text = rm.GetString("lblDesc");
                lblMemo.Text = rm.GetString("lblMemo");
                btnSubmit.Text = rm.GetString("btnSubmit");
                btnReport.Text = rm.GetString("btnReport");
                btnBack.Text = rm.GetString("btnBack");
                lblSubmittingInformation.Text = rm.GetString("lblSubmittingInformation");
                lblLoadingInformation.Text = rm.GetString("lblLoadingInformation");
                lblAssetPic.Text = rm.GetString("lblAssetPic");
                lblAssetPhoto1.Text = rm.GetString("lblAssetPhoto1");
                lblAssetPhoto2.Text = rm.GetString("lblAssetPhoto2");
                lblAssetPhoto3.Text = rm.GetString("lblAssetPhoto3");
                lblValidUntil.Text = rm.GetString("lblValidUntil");
                groupBox2.Text = rm.GetString("groupBox2");
                this.Text = rm.GetString("Verification");
            }
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
                    roleValue = (string)(key.GetValue("roles"));
                    portname = (string)(key.GetValue("DefaultPortName"));
                    companyId = (int)(key.GetValue("companyId"));
                    userId = (int)(key.GetValue("UserId"));
                    lblLoginUserName.Text = "Username: " + (string)(key.GetValue("UserName")).ToString();//.ToUpper();
                    readerInfo = (string)(key.GetValue("readerInfo"));
                    key.Close();

                    if (roleValue == "ROLE_GUARD")
                    {
                        if (language == "English") btnBack.Text = "Log Out";
                        else btnBack.Text = "ログアウト";
                        btnBack.BackColor = Color.Red;
                        btnBack.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            try
            {
                btnBack.Focus();

                //BackgroundTimer.Interval = 1000;

                CurrentDateTimer.Enabled = true;
                CurrentDateTimer.Interval = 1000;

                VerifyTimer.Interval = 2000;
                VerifyTimer.Tick += new EventHandler(VerifyTimer_Tick);

                //ClearGridTimer.Interval = 30000;
                //ClearGridTimer.Tick += new EventHandler(ClearGridTimer_Tick);

                reader = new Reader.ReaderMethod();
                ////Callback
                //reader.AnalyCallback = AnalyData;
                //reader.ReceiveCallback = ReceiveData;
                //reader.SendCallback = SendData;
                //auto_connect();
                ReaderMethodProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region btnVerifyAsset
        private void btnVerifyAsset_Click(object sender, EventArgs e)
        {
            //try
            //{ 
            //    int nReturnValue = 0;
            //    string tagInfo = "";

            //    nReturnValue = realTimeInventory(255, 255, 1);  //Public address reader , fast inventory mode , 5 seconds timeout control

            //    if (nReturnValue == 1)
            //    {
            //        for (int i = 0; i < RealTimeTagDataList.Count; i++)
            //        {
            //            tagInfo = RealTimeTagDataList[i].strEpc;//tagInfo = RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    ";// tagInfo = "antenna" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    " + RealTimeTagDataList[i].strCarrierFrequency + "    " + RealTimeTagDataList[i].strRssi;
            //            //listBox1.Items.Add(tagInfo);
            //            txtRFIDTag.Text = tagInfo.ToString();
            //        }

            //        CheckRFIDTag();
            //    }
            //    //else if (nReturnValue == 0)
            //    //{
            //    //    MessageBox.Show("Successful execution of the command but no inventory to tag");
            //    //}
            //    else if (nReturnValue == -1)
            //    {
            //        MessageBox.Show("Reader Com Port Error.", "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        IsPortError = true;
            //        return;

            //        //LoopVerification();
            //        //MessageBox.Show("Reader Com Port Error");
            //    }
            //    else if (nReturnValue == -2)
            //    {
            //        //MessageBox.Show("Reader Com Port Error");
            //        MessageBox.Show("Reader Com Port Error.", "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        IsPortError = true;
            //        return;

            //        //LoopVerification();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion
        private void CheckRFIDTag()
        {
            try
            {
                //if (this.InvokeRequired)
                //{
                //    this.Invoke(new MethodInvoker(delegate
                //    {
                        //grdViewRFIDTag.Refresh();

                        //Validate if RFID Tag exist on the table
                        if (/*IsStopComparing ||*/ grdViewRFIDTag.Rows.Count > 0)
                        {
                            for (int i = startRowComparing; i < grdViewRFIDTag.Rows.Count; i++)
                            {
                                if (grdViewRFIDTag.Rows[i].Cells["colRFIDTag"].Value.ToString() == txtRFIDTag.Text /*&& grdViewRFIDTag.Rows[i].Cells["colIsCompared"].Value == null*/)
                                {
                                    IsRFIDTagExist = true;
                                    //txtRFIDTag.Text = string.Empty;
                                    return;
                                }
                                else
                                {
                                    IsRFIDTagExist = false;
                                }
                            }
                        }
                        //else if (grdViewRFIDTag.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < grdViewRFIDTag.Rows.Count; i++)
                        //    {
                        //        if (grdViewRFIDTag.Rows[i].Cells["colRFIDTag"].Value.ToString() == txtRFIDTag.Text)
                        //        {
                        //            IsRFIDTagExist = true;
                        //            //txtRFIDTag.Text = string.Empty;
                        //            return;
                        //        }
                        //        else
                        //            IsRFIDTagExist = false;
                        //    }
                        //}

                        //btnVerifyAsset.Text = "Verifying Tag. Please wait ...";
                        //btnVerifyAsset.BackColor = Color.GreenYellow;
                        //btnVerifyAsset.Refresh();
                        //lblLoadingInformation.Visible = true;
                        //lblLoadingInformation.Refresh();

                        GlobalClass.GetSetClass verifyRequest = new GlobalClass.GetSetClass();
                        verifyRequest.tag = txtRFIDTag.Text;
                        verifyRequest.companyId = companyId;//1;
                        verifyRequest.tagType = 1;

                        //initialize web service
                        RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                        RestRequest verify = new RestRequest("/api/asset/company-tag"/*"/api/asset/verify"*/, Method.POST);
                        var authToken = tokenvalue;

                        verify.AddHeader("X-Auth-Token", authToken);
                        verify.AddHeader("Content-Type", "application/json; charset=utf-8");
                        verify.RequestFormat = DataFormat.Json;
                        verify.AddBody(verifyRequest);

                        //retrieve response
                        IRestResponse response = client.Execute(verify);
                        var content = response.Content;

                        //btnVerifyAsset.Text = "Click to verify RFID Tag";
                        //btnVerifyAsset.BackColor = Color.Orange;
                        //lblLoadingInformation.Visible = false;

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            //deserialize JSON -> Object
                            JsonDeserializer deserial = new JsonDeserializer();
                            GlobalClass.GetSetClass verifyResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                            //if (verifyResult.result == "OK")
                            //{

                                if (grdViewRFIDTag.Rows.Count == 0 || !IsRFIDTagExist)
                                {
                                    //displayDataOnTable(verifyResult.validUntil, verifyResult.description, verifyResult.ownerUserId);

                                    if (!grdViewRFIDTag.ColumnHeadersVisible) grdViewRFIDTag.ColumnHeadersVisible = true;

                                    int idx = grdViewRFIDTag.Rows.Add();
                                    DataGridViewRow row = grdViewRFIDTag.Rows[idx];

                                    row.Cells["colDate"].Value = DateTime.Now.ToString();
                                    row.Cells["colViewerIcon"].ToolTipText = "Double click to view the details.";
                                    row.Cells["colViewerIcon"].Value = Properties.Resources.ViewDetailsIcon;
                                    row.Cells["colAssetID"].Value = verifyResult.assetId;
                                    row.Cells["colAssetDescription"].Value = verifyResult.description;
                                    //row.Cells["colTakeOutNote"].Value = verifyResult.takeOutInfo;

                                    if (verifyResult.description == "ID_CARD")
                                    {
                                        //row.Cells["colIDTag"].Value = txtRFIDTag.Text;
                                        row.Cells["colIDOwner"].Value = verifyResult.ownerUserId;
                                        row.Cells["colOwnerName"].Value = verifyResult.name;
                                        row.Cells["colValidityPeriod"].Value = verifyResult.validUntil == null ? "Start " + verifyResult.startDate.Value.ToString("g") + " - No End Date" : "Start " + verifyResult.startDate.Value.ToString("g") + " Until " + verifyResult.validUntil.Value.ToString("g");
                                        //row.Cells["colAssetID"].Value = verifyResult.assetId;

                                        //Check Validity Expiration
                                        if (verifyResult.startDate > Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.startDate != DateTime.MinValue)
                                        {
                                            row.Cells["colStatus"].Value = "INVALID";
                                            row.DefaultCellStyle.BackColor = Color.Black;
                                            row.DefaultCellStyle.ForeColor = Color.White;
                                            playAlarmSound("Expired");
                                        }
                                        else if (verifyResult.validUntil < Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.validUntil != DateTime.MinValue)
                                        {
                                            row.Cells["colStatus"].Value = "EXPIRED";
                                            row.DefaultCellStyle.BackColor = Color.Orange;
                                            row.DefaultCellStyle.ForeColor = Color.White;
                                            playAlarmSound("Expired");
                                        }
                                        else
                                        {
                                            row.Cells["colStatus"].Value = "OK";
                                            row.DefaultCellStyle.BackColor = Color.Green;
                                            row.DefaultCellStyle.ForeColor = Color.White;
                                            playAlarmSound("Ok");
                                        }
                                    }
                                    else
                                    {
                                        //row.Cells["colAssetTag"].Value = txtRFIDTag.Text;
                                        row.Cells["colAssetOwner"].Value = verifyResult.ownerUserId;
                                        //row.Cells["colAssetDescription"].Value = verifyResult.description;
                                        //row.Cells["colTakeOutNote"].Value = verifyResult.takeOutInfo;
                                        row.DefaultCellStyle.BackColor = Color.Yellow;
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                    }

                                    row.Cells["colRFIDTag"].Value = txtRFIDTag.Text;
                                    //row.Cells["colValidityPeriod"].Value = verifyResult.validUntil == null ? "No End Date" : "Start " + verifyResult.validUntil + " Until " + verifyResult.validUntil;

                                    ////Check Validity Expiration
                                    //if (verifyResult.validUntil < Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.validUntil != DateTime.MinValue)
                                    //{
                                    //    row.Cells["colStatus"].Value = "EXPIRED";
                                    //    row.DefaultCellStyle.BackColor = Color.Orange;
                                    //    row.DefaultCellStyle.ForeColor = Color.White;
                                    //    playAlarmSound("Expired");
                                    //}

                                    grdViewRFIDTag.FirstDisplayedScrollingRowIndex = grdViewRFIDTag.RowCount - 1;
                                    grdViewRFIDTag.Refresh();
                                    //ClearGridTimer.Stop();
                                    //IsStopComparing = false;
                                    if (row.Cells["colStatus"].Value == null)
                                        SaveTransaction(verifyResult.assetId, "VERIFY-Asset");
                                    else
                                        SaveTransaction(verifyResult.assetId, "VERIFY-Owner-" + row.Cells["colStatus"].Value.ToString());
                                    //ClearGridTimer.Stop();
                                    //txtRFIDTag.Text = string.Empty;
                                }

                        
                                //AssetIdValue = verifyResult.assetId;
                                ////txtAssetName.Text = verifyResult.name;
                                //txtDescription.Text = verifyResult.description;
                                ////if (Boolean.Parse(verifyResult.takOutAllowed.ToString()))
                                ////{
                                ////    txtTakeOutAvailability.Text = "Allowed to take-out.";
                                ////}
                                ////else
                                ////{
                                ////    txtTakeOutAvailability.Text = "Not allowed to take-out.";
                                ////}
                                //txtTakeOutNote.Text = verifyResult.takeOutInfo;
                                ////if (File.Exists(verifyResult.imageUrls))
                                ////{
                                //    //picOwner.Image = Image.FromFile(verifyResult.imageUrls);

                                //    string Urls = verifyResult.imageUrls;
                                //    string[] ReadUrls = Urls.Split(',');

                                //    if (ReadUrls.Length > 1)
                                //    {
                                //        imgCapture1.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[1]);
                                //        lblOwnerPhoto.Visible = false;
                                //    }
                                //    if (ReadUrls.Length > 2)
                                //    {
                                //        imgCapture2.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[2]);
                                //        lblValidIDPhoto.Visible = false;
                                //    }
                                //    if (ReadUrls.Length > 3)
                                //    {
                                //        imgCapture3.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[3]);
                                //        lblAssetPhoto1.Visible = false;
                                //    }
                                //    if (ReadUrls.Length > 4)
                                //    {
                                //        imgCapture4.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[4]);
                                //        lblAssetPhoto2.Visible = false;
                                //    }
                                //    if (ReadUrls.Length > 5)
                                //    {
                                //        imgCapture5.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[5]);
                                //        lblAssetPhoto3.Visible = false;
                                //    }

                                //    //foreach (string GetUrls in ReadUrls)
                                //    //{
                                //    //    if (ReadUrls.Length > 1 && File.Exists(ReadUrls[1]))
                                //    //    {
                                //    //        imgCapture1.Image = Image.FromFile(ReadUrls[1]);
                                //    //        lblOwnerPhoto.Visible = false;
                                //    //    }
                                //    //    if (ReadUrls.Length > 2 && File.Exists(ReadUrls[2]))
                                //    //    {
                                //    //        imgCapture2.Image = Image.FromFile(ReadUrls[2]);
                                //    //        lblValidIDPhoto.Visible = false;
                                //    //    }
                                //    //    if (ReadUrls.Length > 3 && File.Exists(ReadUrls[3]))
                                //    //    {
                                //    //        imgCapture3.Image = Image.FromFile(ReadUrls[3]);
                                //    //        lblAssetPhoto1.Visible = false;
                                //    //    }
                                //    //    if (ReadUrls.Length > 4 && File.Exists(ReadUrls[4]))
                                //    //    {
                                //    //        imgCapture4.Image = Image.FromFile(ReadUrls[4]);
                                //    //        lblAssetPhoto2.Visible = false;
                                //    //    }
                                //    //    if (ReadUrls.Length > 5 && File.Exists(ReadUrls[5]))
                                //    //    {
                                //    //        imgCapture5.Image = Image.FromFile(ReadUrls[5]);
                                //    //        lblAssetPhoto3.Visible = false;
                                //    //    }
                                //    //}
                                ////}
                                ////else
                                ////{
                                ////    MessageBox.Show("Image not found for this path: " + verifyResult.imageUrls, "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ////    //btnVerifyAsset.Focus();
                                ////    //return;
                                ////}

                                ////Display User's Information
                                ////if (File.Exists(verifyResult.owner.imageUrl)) picOwner.Image =  Image.FromFile(verifyResult.owner.imageUrl);
                                ////txtOwnerName.Text = verifyResult.owner.lastName + " " + verifyResult.owner.firstName;
                                ////txtOwnerPosition.Text = verifyResult.owner.position;
                                ////txtOwnerDescription.Text = verifyResult.owner.description;

                                ////VerifyTimer.Stop();
                                ////VerifyTimer.Start();

                                ////ClearTimer.Stop();
                                ////ClearTimer.Start();

                                //txtValidUntil.Text = verifyResult.validUntil != DateTime.MinValue ? verifyResult.validUntil.Value.ToString("g") : "No Expiration";

                                ////Validate Asset Validity Expiration
                                //if (verifyResult.validUntil < Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.validUntil != DateTime.MinValue)
                                //{
                                //    if (roleValue == "ROLE_ADMIN")
                                //    {
                                //        if (language == "English")
                                //        {
                                //            DialogResult result = MessageBox.Show("Asset is already expired." + "\n" + "Do you want to renew the asset?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                //            if (result == DialogResult.Yes)
                                //            {
                                //                IsCallingMainMenu = true;
                                //                reader.CloseCom();

                                //                using (AssetRenewal RenewalForm = new AssetRenewal())
                                //                {
                                //                    if (RenewalForm.ShowDialog() == DialogResult.OK)
                                //                    {
                                //                        btnSubmit.Text = "Renewed";
                                //                    }

                                //                    IsCallingMainMenu = false;
                                //                    ReaderMethodProc();
                                //                    VerifyAssetProc();
                                //                }
                                //            }
                                //        }
                                //        else
                                //        {
                                //            DialogResult result = MessageBox.Show("アセットはすでに有効期限が切れています." + "\n" + "あなたは資産を更新したいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                //            if (result == DialogResult.Yes)
                                //            {
                                //                IsCallingMainMenu = true;
                                //                reader.CloseCom();

                                //                using (AssetRenewal RenewalForm = new AssetRenewal())
                                //                {
                                //                    if (RenewalForm.ShowDialog() == DialogResult.OK)
                                //                    {
                                //                        btnSubmit.Text = "新たな";
                                //                    }

                                //                    IsCallingMainMenu = false;
                                //                    ReaderMethodProc();
                                //                    VerifyAssetProc();
                                //                }
                                //            }
                                //        }
                                //    }
                                //    else if (roleValue == "ROLE_GUARD")
                                //    {
                                //        if (language == "English") MessageBox.Show("Asset is already expired." + "\n" + "Please go to admin for renewal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //        else MessageBox.Show("アセットはすでに有効期限が切れています." + "\n" + "更新のため、管理者にいきますください.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //    }
                                //}

                                //btnBack.Focus();
                                return;
                            //}
                            //else
                            //{
                            //    MessageBox.Show(verifyResult.result + " " + verifyResult.message);
                            //    //MessageBox.Show("RFID Tag: " + txtRFIDTag.Text + " " + verifyResult.message);
                            //}
                        }
                        else if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            if (language == "English") MessageBox.Show("Error connecting to server.. Please try again later");
                            else MessageBox.Show("サーバーへの接続エラー.. 後でもう一度試してみてください");
                        }
                        else
                        {
                            HttpStatusCode statusCode = response.StatusCode;
                            int numericStatusCode = (int)statusCode;
                            //show error code
                            MessageBox.Show("Error" + numericStatusCode);
                            //SendKeys.Send("{ESC}");
                        }

                        //ClearFields();
                //    }));
                //    return;

                //}
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayDataOnTable(DateTime? expiration, string description, int ownerUserId)
        {
            int idx = grdViewRFIDTag.Rows.Add();
            DataGridViewRow row = grdViewRFIDTag.Rows[idx];

            if (description == "ID_CARD")
            {
                //row.Cells["colIDTag"].Value = txtRFIDTag.Text;
                row.Cells["colIDOwner"].Value = ownerUserId;
                row.Cells["colStatus"].Value = "OK";
                row.DefaultCellStyle.BackColor = Color.Green;
                row.DefaultCellStyle.ForeColor = Color.White;
                playAlarmSound("Ok");
            }
            else
            {
                //row.Cells["colAssetTag"].Value = txtRFIDTag.Text;
                row.Cells["colAssetOwner"].Value = ownerUserId;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            row.Cells["colRFIDTag"].Value = txtRFIDTag.Text;

            //Check Validity Expiration
            if (expiration < Convert.ToDateTime(DateTime.Now.ToString("g")) && expiration != DateTime.MinValue)
            {
                row.Cells["colStatus"].Value = "EXPIRED";
                row.DefaultCellStyle.BackColor = Color.Orange;
                row.DefaultCellStyle.ForeColor = Color.White;
                playAlarmSound("Expired");
            }
            //else if (row.Cells["colIDTag"].Value != null)
            //{
            //    row.Cells["colStatus"].Value = "OK";
            //    row.DefaultCellStyle.BackColor = Color.Green;
            //    row.DefaultCellStyle.ForeColor = Color.White;
            //    playAlarmSound("Ok");
            //}
            //else
            //{
            //    row.DefaultCellStyle.BackColor = Color.Yellow;
            //    row.DefaultCellStyle.ForeColor = Color.Black;
            //}

            grdViewRFIDTag.FirstDisplayedScrollingRowIndex = grdViewRFIDTag.RowCount - 1;
            //ClearGridTimer.Stop();
            //IsStopComparing = false;
        }

        private void SaveTransaction(int assetId, string status)
        {
            //Saving to transaction table
            try
            {
                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                transactDet.companyId = companyId;//1;
                transactDet.readerInfo = readerInfo;
                transactDet.assetId = assetId;
                transactDet.type = status;

                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://feather-assets.herokuapp.com/");
                RestRequest transact = new RestRequest("/api/asset/transact", Method.POST);

                var authToken = tokenvalue;
                transact.AddHeader("X-Auth-Token", authToken);
                transact.AddHeader("Content-Type", "application/json; charset=utf-8");
                transact.RequestFormat = DataFormat.Json;
                transact.AddBody(transactDet);


                IRestResponse response = client.Execute(transact);
                lblSubmittingInformation.Visible = false;

                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                    if (restResult.result != "OK")
                    {
                        if (language == "English") MessageBox.Show("Saving transaction..." + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("取引を保存します。。。" + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (language == "English") MessageBox.Show("Saving transaction..." + "\n" + "Error Code " + response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    else MessageBox.Show("取引を保存します。。。" + "\n" + "Error Code " + response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    return;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void playAlarmSound(string status)
        {
            SoundPlayer alarm;
            switch (status)
            {
                case "Ok":
                    //SoundPlayer audioOk = new SoundPlayer(RFID_FEATHER_ASSETS.Properties.Resources.Ok);
                    alarm = new SoundPlayer(RFID_FEATHER_ASSETS.Properties.Resources.Ok);
                    alarm.Play();
                    break;
                case "Expired":
                    alarm = new SoundPlayer(RFID_FEATHER_ASSETS.Properties.Resources.Expired);
                    alarm.Play();
                    break;
                case "Unauthorized":
                    alarm = new SoundPlayer(RFID_FEATHER_ASSETS.Properties.Resources.Mismatch);
                    alarm.Play();
                    break;
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

        private void ClearFields()
        {
            imgCapture1.Image = null;
            imgCapture2.Image = null;
            imgCapture3.Image = null;
            imgCapture4.Image = null;
            imgCapture5.Image = null;

            //txtValidFrom.Text = string.Empty;
            txtValidityPeriod.Text = string.Empty;
            txtRFIDTag.Text = string.Empty;
            txtAssetName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtOwnerName.Text = string.Empty;
            txtOwnerPosition.Text = string.Empty;
            txtOwnerDescription.Text = string.Empty;
            picOwner.Image = null;
            //txtTakeOutAvailability.Text = string.Empty;
            txtTakeOutNote.Text = string.Empty;
            //picOwner.Image = null;
            //btnVerifyAsset.Focus();

            lblOwnerPhoto.Visible = true;
            lblValidIDPhoto.Visible = true;
            lblAssetPhoto1.Visible = true;
            lblAssetPhoto2.Visible = true;
            lblAssetPhoto3.Visible = true;

            if (language == "English")
            {
                btnSubmit.Text = "Submit";
                btnReport.Text = "Report";
            }
            else
            {
                btnSubmit.Text = "提出する";
                btnReport.Text = "報告する";

            }
            this.Refresh();
        }

        private void Verification_Shown(object sender, EventArgs e)
        {
            //this.Refresh();
            //LoopVerification(); 
        }

        private void LoopVerification()
        {
            //while (IsPortError == false)
            //{
            //    //btnVerifyAsset.PerformClick();
            //    VerifyAssetProc();
            //}
            if (!IsCallingMainMenu)
            {
                //RFID Reader Loop
                //if (IsPortError == false)
                //{
                BackgroundTimer.Stop();
                BackgroundTimer.Start();
                //}
                //else //(IsPortError)
                //{
                //    CallMainMenu();
                //}
            }
        }

        private void VerifyAssetProc()
        {
            try
            {
                if (!IsCallingMainMenu)
                {
                    int nReturnValue = 0;
                    string tagInfo = "";
                    int i = 0;

                    nReturnValue = realTimeInventory(255, 255, 1);  //Public address reader , fast inventory mode , 5 seconds timeout control

                    if (nReturnValue == 1)
                    {
                        //ClearFields();
                        
                        //for (int i = 0; i < RealTimeTagDataList.Count; i++)
                        //{ 
                            tagInfo = RealTimeTagDataList[i].strEpc;//tagInfo = RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    ";// tagInfo = "antenna" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    " + RealTimeTagDataList[i].strCarrierFrequency + "    " + RealTimeTagDataList[i].strRssi;
                            //listBox1.Items.Add(tagInfo);
                            txtRFIDTag.Text = tagInfo.ToString();
                        //}
                            CheckRFIDTag();
                        //thread = new Thread(() => CheckRFIDTag());
                        //thread.Start();
                    }
                    //else if (nReturnValue == 0)
                    //{
                    //    MessageBox.Show("Successful execution of the command but no inventory to tag");
                    //}
                    else if (nReturnValue == -1)
                    {
                        //MessageBox.Show("Reader Com Port Error.", "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CallSerialPortSelection();
                        //IsPortError = true;
                        //return;

                        //LoopVerification();
                    }
                    else if (nReturnValue == -2)
                    {
                        //MessageBox.Show("Reader Com Port Error.", "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CallSerialPortSelection();
                        //IsPortError = true;
                        //return;

                        //LoopVerification();
                    }
                    else
                    {
                        if (totalAssetRead < grdViewRFIDTag.Rows.Count)
                        {
                            VerifyTimer.Start();
                        }
                        return;
                    }
                    ReaderMethodProc();
                    //VerifyAssetProc();

                    //if (!string.IsNullOrEmpty(txtRFIDTag.Text.Trim()) /*!IsRFIDTagExist*/)
                    //{
                    //VerifyTimer.Interval = 100;
                    //VerifyTimer.Tick += new EventHandler(VerifyTimer_Tick);
                    //if (totalAssetRead < grdViewRFIDTag.Rows.Count)
                    //{
                    //    VerifyTimer.Start();
                    //}
                }
            }
            catch (Exception ex)
            {
                if (language == "English") MessageBox.Show(ex.Message + "\n" + "Reader is not connected.");
                else MessageBox.Show(ex.Message + "\n" + "リーダーが接続されていません.");
            }
        }

        private void ReaderMethodProc()
        {
            //reader = new Reader.ReaderMethod();
            //Callback
            reader.AnalyCallback = AnalyData;
            reader.ReceiveCallback = ReceiveData;
            reader.SendCallback = SendData;
            auto_connect();
        }

        private void CallSerialPortSelection()
        {
            try
            {
                IsCallingMainMenu = true;
                SerialPortSelection PortSelectionForm = new SerialPortSelection(tokenvalue, roleValue);

                // Show PortSelectionForm as a modal dialog and determine if DialogResult = OK.
                if (PortSelectionForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of PortSelectionForm's cmbComPortList.
                    portname = PortSelectionForm.cmbComPortList.Text;
                    IsCallingMainMenu = false;
                }
                else ValidateRule();//CallMainMenu();

                PortSelectionForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Verification_FormClosed(object sender, FormClosedEventArgs e)
        {
            ValidateRule();
        }

        private void ValidateRule()
        {
            if (roleValue == "ROLE_ADMIN")
            {
                CallMainMenu();
            }
            else if (roleValue == "ROLE_GUARD")
            {
                //Environment.Exit(0);
                IsCallingMainMenu = true;

                this.Hide();
                reader.CloseCom();
                LoginActivity LoginForm = new LoginActivity();
                LoginForm.Show();
            }
        }

        private void CallMainMenu()
        {
            //Return to Main Menu Form
            IsCallingMainMenu = true;

            this.Hide();
            reader.CloseCom();
            MainMenu MenuForm = new MainMenu(tokenvalue, roleValue);
            MenuForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grdViewRFIDTag.Visible = true; ;//ValidateRule();
            ClearFields();
        }

        #region Timer Procedure
        private void BackgroundTimer_Tick(object sender, EventArgs e)
        {
            ////Always read the RFID Tag if not calling the Main Menu
            //if (!IsCallingMainMenu)
            //{
            //    BackgroundTimer.Stop();
            //    VerifyAssetProc();
            //    LoopVerification();
            //}
        }

        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            //Display the current date and time
            lblCurrentDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");//DateTime.Now.ToString("h:mm:ss tt") + "\n " + DateTime.Now.ToString("MM/dd/yyyy");//DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void VerifyTimer_Tick(object sender, EventArgs e)
        {
            ////ClearFields();
            //LoopVerification();
            VerifyTimer.Stop();
  
            if (!string.IsNullOrEmpty(txtRFIDTag.Text.Trim()) /*&& totalAssetRead < grdViewRFIDTag.Rows.Count*/)
            {
                for (int a = startRowComparing; a < grdViewRFIDTag.Rows.Count; a++)
                {
                    //For Asset Row (aRow)
                    DataGridViewRow aRow = grdViewRFIDTag.Rows[a];
                    if (aRow.Cells["colAssetOwner"].Value != null /*&& Convert.ToString(aRow.Cells["colStatus"].Value).ToString() != "OK" && Convert.ToString(aRow.Cells["colStatus"].Value).ToString() != "EXPIRED"*/)
                    {
                        for (int o = startRowComparing; o < grdViewRFIDTag.Rows.Count; o++)
                        {
                            //For ID Row (iRow)
                            DataGridViewRow iRow = grdViewRFIDTag.Rows[o];
                            if (Convert.ToString(aRow.Cells["colAssetOwner"].Value).ToString() == Convert.ToString(iRow.Cells["colIDOwner"].Value).ToString())
                            {
                                //aRow.Cells["colIDTag"].Value = iRow.Cells["colIDTag"].Value;
                                aRow.Cells["colOwnerName"].Value = iRow.Cells["colOwnerName"].Value;
                                aRow.Cells["colValidityPeriod"].Value = iRow.Cells["colValidityPeriod"].Value;
                                //aRow.Cells["colStatus"].Value = "OK";
                                //aRow.DefaultCellStyle.BackColor = Color.Green;
                                //aRow.DefaultCellStyle.ForeColor = Color.White;
                                iRow.DataGridView.Rows[o].Visible = false;
                                //aRow.Cells["colIsCompared"].Value = "YES";

                                if (Convert.ToString(iRow.Cells["colStatus"].Value).ToString() != "EXPIRED" && Convert.ToString(iRow.Cells["colStatus"].Value).ToString() != "INVALID")
                                {
                                    aRow.Cells["colStatus"].Value = "OK";
                                    aRow.DefaultCellStyle.BackColor = Color.Green;
                                    aRow.DefaultCellStyle.ForeColor = Color.White;
                                }
                                else
                                {
                                    if (Convert.ToString(iRow.Cells["colStatus"].Value).ToString() == "INVALID")
                                    {
                                        aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                                        aRow.Cells["colStatus"].Value = "INVALID";
                                        aRow.DefaultCellStyle.BackColor = Color.Black;
                                        aRow.DefaultCellStyle.ForeColor = Color.White;
                                    }
                                    else
                                    {
                                        aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                                        aRow.Cells["colStatus"].Value = "EXPIRED";
                                        aRow.DefaultCellStyle.BackColor = Color.Orange;
                                        aRow.DefaultCellStyle.ForeColor = Color.White;
                                    }
                                    //aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                                    //aRow.DefaultCellStyle.BackColor = Color.Orange;
                                    //aRow.DefaultCellStyle.ForeColor = Color.White;
                                    aRow.Cells["colStatus"].ToolTipText = aRow.Cells["colValidityPeriod"].Value.ToString();
                                }
                                //playAlarmSound("Ok");
                                break;
                            }
                            else if (o == grdViewRFIDTag.Rows.Count - 1)
                            {
                                aRow.Cells["colStatus"].Value = "UNAUTHORIZED";
                                aRow.DefaultCellStyle.BackColor = Color.Red;
                                aRow.DefaultCellStyle.ForeColor = Color.White;
                                SaveTransaction(Convert.ToInt32(aRow.Cells["colAssetID"].Value.ToString()), "VERIFY-Asset-" + aRow.Cells["colStatus"].Value.ToString());
                                //aRow.Cells["colIsCompared"].Value = "YES";
                                playAlarmSound("Unauthorized");
                                //break;
                            }
                        }
                    }
                   
                    if (a == grdViewRFIDTag.Rows.Count - 1)
                    {
                        txtRFIDTag.Text = string.Empty;
                        totalAssetRead = a + 1;
                        grdViewRFIDTag.ClearSelection();

                        //IsStopComparing = true;
                        startRowComparing = grdViewRFIDTag.Rows.Count;
                        IsRFIDTagExist = false;

                        //ClearGridTimer.Start();
                    }
                }
            }
        }

        private void ClearGridTimer_Tick(object sender, EventArgs e)
        {
            ClearGridTimer.Stop();

            grdViewRFIDTag.Rows.Clear();
            totalAssetRead = 0;
            startRowComparing = 0;
        }
        #endregion

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                //ValidationMessage();
                //if (!IsCallingMainMenu) return;

                //IsCallingMainMenu = true;
                //reader.CloseCom();

                using (ReportCreation ReportCreationForm = new ReportCreation(AssetIdValue))
                {
                    if (ReportCreationForm.ShowDialog() == DialogResult.OK)
                    {
                        //btnSave.Visible = false;
                        if (language == "English") btnReport.Text = "Reported";
                        else btnReport.Text = "報告しました";//btnCreateReport.Visible = false;
                        //grpBoxReportedInfo.Visible = true;

                        //// Read the contents of PortSelectionForm's.
                        //picPersonBroughtOut.Image = ReportCreationForm.PersonPhoto;
                        //txtReportedNote.Text = " " + ReportCreationForm.ExplanationNote;
                        //btnBack.PerformClick();
                    }
                    //else
                    //{
                    //    IsCallingMainMenu = false;
                    //    LoopVerification();
                    //}

                    //IsCallingMainMenu = false;

                    //ReaderMethodProc();
                    //VerifyAssetProc();
                    //ReportCreationForm.Dispose();  
                    btnBack.PerformClick();
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
                if (btnSubmit.Text.Trim().ToUpper() == "SUBMITTED" || btnSubmit.Text.Trim().ToUpper() == "提出" || btnSubmit.Text.Trim().ToUpper() == "RENEWED" || btnSubmit.Text.Trim().ToUpper() == "新たな" || btnReport.Text.Trim().ToUpper() == "REPORTED" || btnReport.Text.Trim().ToUpper() == "報告しました" || txtRFIDTag.Text.Length == 0)
                {
                    ValidationMessage();
                    return;
                }

                IsCallingMainMenu = true;
                //reader.CloseCom();

                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                transactDet.companyId = companyId;//1;
                transactDet.readerInfo = readerInfo;
                //transactDet.readerId = 1;
                transactDet.assetId = AssetIdValue;//Verification.AssetIdValue;
                //transactDet.notes = txtExplanationNotes.Text.Trim();
                //transactDet.imageUrl = newImgFileNames;//txtCapturedImagePath.Text;//txtImagePath.Text;


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
                        if (language == "English")
                        {
                            btnSubmit.Text = "SUBMITTED";
                            MessageBox.Show("Record successfully saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            btnSubmit.Text = "提出";
                            MessageBox.Show("レコードが正常に保存され.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        IsCallingMainMenu = false;
                        ReaderMethodProc();
                        //VerifyAssetProc();
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

        private void ValidationMessage()
        {
            //IsCallingMainMenu = true;
            //reader.CloseCom();
            if (language == "English")
            {
                if (btnSubmit.Text.Trim().ToUpper() == "SUBMITTED")
                {
                    MessageBox.Show("Record is already submitted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnSubmit.Focus();
                    //IsCallingMainMenu = false;
                }

                if (btnSubmit.Text.Trim().ToUpper() == "RENEWED")
                {
                    MessageBox.Show("ID is already renewed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnSubmit.Focus();
                    //IsCallingMainMenu = false;
                }

                if (btnReport.Text.Trim().ToUpper() == "REPORTED")
                {
                    MessageBox.Show("Record is already reported.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnReport.Focus();
                    //IsCallingMainMenu = false;
                }

                //if (txtRFIDTag.Text.Length == 0)
                //{
                //    MessageBox.Show("RFID Tag is required. Please scan...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    btnSubmit.Focus();
                //    IsCallingMainMenu = false;
                //}
            }
            else
            {
                if (btnSubmit.Text.Trim().ToUpper() == "提出")
                {
                    MessageBox.Show("レコードが既に提出されています.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnSubmit.Focus();
                    //IsCallingMainMenu = false;
                }

                if (btnSubmit.Text.Trim().ToUpper() == "新たな")
                {
                    MessageBox.Show("資産はすでに更新されます.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnSubmit.Focus();
                    //IsCallingMainMenu = false;
                }

                if (btnReport.Text.Trim().ToUpper() == "報告しました")
                {
                    MessageBox.Show("レコードが既に報告されています.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnReport.Focus();
                    //IsCallingMainMenu = false;
                }

                if (txtRFIDTag.Text.Length == 0)
                {
                    MessageBox.Show("RFIDタグが必要とされます. スキャンしてください...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnSubmit.Focus();
                    //IsCallingMainMenu = false;
                }
            }
            //ReaderMethodProc();
            //VerifyAssetProc();
            //return;
        }

        private void getownerInfo(int id/*, DateTime? validity*/)
        {
            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
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

                string urls = info.imageUrl;

                if (string.IsNullOrEmpty(urls))
                {
                    lblOwnerPhoto.Text = "NO" + "\n" + "Owner Photo";
                    lblValidIDPhoto.Text = "NO" + "\n" + "Valid ID Photo";
                }

                if (urls != null)
                {
                    string[] ReadUrls = urls.Split(',');

                    if (ReadUrls.Length > 1)
                    {
                        imgCapture1.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[1]);
                        lblOwnerPhoto.Visible = false;
                    }
                    if (ReadUrls.Length > 2)
                    {
                        imgCapture2.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[2]);
                        lblValidIDPhoto.Visible = false;
                    }
                }
                txtOwnerName.Text = info.lastName + ", " + info.firstName;
                //ValidateExpiration(/*validity*/);
            }
            else
            {
                MessageBox.Show("Unable to reach server.. please try again later", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateExpiration(/*DateTime? validity*/)
        {
            //if (validity < Convert.ToDateTime(DateTime.Now.ToString("g")) && validity != DateTime.MinValue)
            //{
                if (roleValue == "ROLE_ADMIN")
                {
                    DialogResult result;
                    if (language == "English")
                    {
                        //if (txtDescription.Text.Trim() == "ID_CARD")
                            result = MessageBox.Show("ID is already expired." + "\n" + "Do you want to renew the ID?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        //else
                        //    result = MessageBox.Show("Asset is already expired." + "\n" + "Do you want to renew the Asset?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        //if (txtDescription.Text.Trim() == "ID_CARD")
                        //    result = MessageBox.Show("ID is already expired." + "\n" + "Do you want to renew the ID?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        //else
                            result = MessageBox.Show("アセットはすでに有効期限が切れています." + "\n" + "あなたは資産を更新したいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }

                    if (result == DialogResult.Yes)
                    {
                        //IsCallingMainMenu = true;
                        //reader.CloseCom();

                        using (AssetRenewal RenewalForm = new AssetRenewal(AssetIdValue))
                        {
                            if (RenewalForm.ShowDialog() == DialogResult.OK)
                            {
                                btnSubmit.Text = "Renewed";
                                //btnBack.PerformClick();
                            }

                            //IsCallingMainMenu = false;
                            //ReaderMethodProc();
                            //VerifyAssetProc();
                        }
                    }
                    btnBack.PerformClick();
                }
                else if (roleValue == "ROLE_GUARD")
                {
                    if (language == "English") MessageBox.Show("ID is already expired." + "\n" + "Please go to admin for the renewal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else MessageBox.Show("アセットはすでに有効期限が切れています." + "\n" + "更新のため、管理者にいきますください.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            //}
            //btnBack.Focus();
            //return;
            //btnBack.PerformClick();
        }

        private void grdViewRFIDTag_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
            
                if (e.ColumnIndex == colViewerIcon.Index)
                {
                    grdViewRFIDTag.Visible = false;
                    if (grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value.ToString() == "UNAUTHORIZED")
                    {
                        btnBack.Width = 145;
                        btnReport.Visible = true;
                        //btnReport.PerformClick();
                    }
                    else
                    {
                        btnBack.Width = 292;
                        btnReport.Visible = false;
                    }
                    //this.Refresh();

                    lblLoadingInformation.Visible = true;
                    this.Refresh();//lblLoadingInformation.Refresh();

                    GlobalClass.GetSetClass getAsset = new GlobalClass.GetSetClass();

                    getAsset.companyId = companyId;
                    getAsset.tagType = 1;
                    getAsset.tag = grdViewRFIDTag.Rows[e.RowIndex].Cells["colRFIDTag"].Value.ToString(); //txtRFIDTag.Text;

                    RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                    RestRequest assetinfo = new RestRequest("/api/asset/company-tag", Method.POST);

                    assetinfo.RequestFormat = DataFormat.Json;
                    assetinfo.AddHeader("Content-Type", "application/json; charset=utf-8");
                    assetinfo.AddHeader("X-Auth-Token", tokenvalue);
                    assetinfo.AddBody(getAsset);

                    IRestResponse response = client.Execute(assetinfo);
                    var content = response.Content;

                    //client.ExecuteAsync(assetinfo, response =>
                    //{
 
                       //var content = response.Content;
                    //   this.Invoke(new MethodInvoker(delegate
                    //{
                       lblLoadingInformation.Visible = false;

                       if (response.StatusCode == HttpStatusCode.OK)
                       {
                           JsonDeserializer deserial = new JsonDeserializer();
                           GlobalClass.GetSetClass assetInfo = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                           string urls = assetInfo.imageUrls;

                           if (string.IsNullOrEmpty(urls))
                           {
                               lblAssetPhoto1.Text = "NO" + "\n" + "Asset Photo 1";
                               lblAssetPhoto2.Text = "NO" + "\n" + "Asset Photo 2";
                               lblAssetPhoto3.Text = "NO" + "\n" + "Asset Photo 3";
                           }

                           if (urls != null && assetInfo.description != "ID_CARD")
                           {
                               string[] ReadUrls = urls.Split(',');

                               if (ReadUrls.Length > 1)
                               {
                                   imgCapture3.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[1]);
                                   lblAssetPhoto1.Visible = false;
                               }
                               if (ReadUrls.Length > 2)
                               {
                                   imgCapture4.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[2]);
                                   lblAssetPhoto2.Visible = false;
                               }
                               if (ReadUrls.Length > 3)
                               {
                                   imgCapture5.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[3]);
                                   lblAssetPhoto3.Visible = false;
                               }
                           }

                           txtValidityPeriod.Text = Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colValidityPeriod"].Value).ToString();
                           txtRFIDTag.Text = getAsset.tag;
                           //AssetIdValue = assetInfo.assetId;
                           //updatedImgFileNames = assetInfo.imageUrls;
                           txtDescription.Text = assetInfo.description;
                           //assetName = assetInfo.name;

                           //if (assetInfo.description == "ID_CARD")
                           //    txtDescription.ReadOnly = true;
                           //else txtDescription.ReadOnly = false;

                           txtTakeOutNote.Text = assetInfo.takeOutInfo;

                           //if (assetInfo.validUntil == null)
                           //{
                           //    txtValidFrom.Text = "No End Date";
                           //    txtValidUntil.Text = "No End Date";
                           //}
                           //else
                           //{
                           //    txtValidFrom.Text = string.Empty;//assetInfo.validUntil.Value.ToString("g");
                           //    txtValidUntil.Text = assetInfo.validUntil.Value.ToString("g");
                           //}

                           getownerInfo(assetInfo.ownerUserId /*, assetInfo.validUntil*/);
                           if (Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value).ToString() == "INVALID")
                           {
                               MessageBox.Show("ID is not yet valid." + "\n" + "Please check the start date of validity.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                               btnBack.PerformClick();
                           }
                           if (Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value).ToString() == "EXPIRED")
                           {
                               AssetIdValue = Convert.ToInt32(grdViewRFIDTag.Rows[e.RowIndex].Cells["colAssetID"].Value.ToString());//assetInfo.assetId;
                               ValidateExpiration();
                           }
                           else AssetIdValue = assetInfo.assetId;
                       }
                       else if (response.StatusCode == HttpStatusCode.NotFound)
                       {
                           if (language == "English") MessageBox.Show("Error connecting to server.. please try again later");
                           else MessageBox.Show("サーバーへの接続エラー.. 後でもう一度試してみてください");
                       }
                       else
                       {
                           HttpStatusCode statusCode = response.StatusCode;
                           int numericStatusCode = (int)statusCode;
                           //show error code
                           MessageBox.Show("Error" + numericStatusCode);
                       }
                    //}));
                    //});
                } 
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ReadLoopTimer_Tick(object sender, EventArgs e)
        {
            if (!IsCallingMainMenu)
                VerifyAssetProc();
        }

    }

    //public class VerifyRequest
    //{
    //    public int companyId {get; set;}
    //    public string tag {get; set;}
    //    public int tagType{get; set;}
    //}

    //public class VerifyResult
    //{
    //    public int assetId { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public string imageUrls { get; set; }
    //    public bool takOutAllowed { get; set; }
    //    public string takeOutInfo { get; set; }
    //    public DateTime validUntil { get; set; }
    //    public string result { get; set; }
    //    public string message { get; set; }
    //    public OwnerList owner { get; set; }
    //}

    //public class OwnerList
    //{
    //    public int userId { get; set; }
    //    public int companyId { get; set; }
    //    public string firstName { get; set; }
    //    public string lastName { get; set; }
    //    public string position { get; set; }
    //    public string description { get; set; }
    //    public string imageUrl { get; set; }
    //    public string email { get; set; }
    //    public string authorities { get; set; }
    //}
}

