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
        bool IsCallingMainMenu = false;
        string roleValue;
        int userId;
        //int companyId;

        public Verification()//string tokenvaluesource, string roleSource) //(string tokenvaluesource, string portnamesource, string roleSource)
        {
            InitializeComponent();

            //portname = portnamesource;
            GetAssetSystemInfo();
            //tokenvalue = tokenvaluesource;
            //roleValue = roleSource;
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
                        btnBack.Text = "Log Out";
                        btnBack.BackColor = Color.Red;
                        btnBack.ForeColor = Color.White;
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
                //ClearTimer.Interval = 7000;
                //VerifyTimer.Interval = 7000;
                btnBack.Focus();

                BackgroundTimer.Interval = 1000;

                CurrentDateTimer.Enabled = true;
                CurrentDateTimer.Interval = 1000;

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
                //btnVerifyAsset.Text = "Verifying Tag. Please wait ...";
                //btnVerifyAsset.BackColor = Color.GreenYellow;
                //btnVerifyAsset.Refresh();
                lblLoadingInformation.Visible = true;
                lblLoadingInformation.Refresh();

                VerifyRequest verifyRequest = new VerifyRequest();
                verifyRequest.tag = txtRFIDTag.Text;
                verifyRequest.companyId = companyId;//1;
                verifyRequest.tagType = 1;

                //initialize web service
                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                RestRequest verify = new RestRequest("/api/asset/verify", Method.POST);
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
                lblLoadingInformation.Visible = false;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize JSON -> Object
                    JsonDeserializer deserial = new JsonDeserializer();
                    VerifyResult verifyResult = deserial.Deserialize<VerifyResult>(response);

                    if (verifyResult.result == "OK")
                    {
                        AssetIdValue = verifyResult.assetId;
                        //txtAssetName.Text = verifyResult.name;
                        txtDescription.Text = verifyResult.description;
                        //if (Boolean.Parse(verifyResult.takOutAllowed.ToString()))
                        //{
                        //    txtTakeOutAvailability.Text = "Allowed to take-out.";
                        //}
                        //else
                        //{
                        //    txtTakeOutAvailability.Text = "Not allowed to take-out.";
                        //}
                        txtTakeOutNote.Text = verifyResult.takeOutInfo;
                        //if (File.Exists(verifyResult.imageUrls))
                        //{
                            //picOwner.Image = Image.FromFile(verifyResult.imageUrls);

                            string Urls = verifyResult.imageUrls;
                            string[] ReadUrls = Urls.Split(',');

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
                            if (ReadUrls.Length > 3)
                            {
                                imgCapture3.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[3]);
                                lblAssetPhoto1.Visible = false;
                            }
                            if (ReadUrls.Length > 4)
                            {
                                imgCapture4.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[4]);
                                lblAssetPhoto2.Visible = false;
                            }
                            if (ReadUrls.Length > 5)
                            {
                                imgCapture5.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[5]);
                                lblAssetPhoto3.Visible = false;
                            }

                            //foreach (string GetUrls in ReadUrls)
                            //{
                            //    if (ReadUrls.Length > 1 && File.Exists(ReadUrls[1]))
                            //    {
                            //        imgCapture1.Image = Image.FromFile(ReadUrls[1]);
                            //        lblOwnerPhoto.Visible = false;
                            //    }
                            //    if (ReadUrls.Length > 2 && File.Exists(ReadUrls[2]))
                            //    {
                            //        imgCapture2.Image = Image.FromFile(ReadUrls[2]);
                            //        lblValidIDPhoto.Visible = false;
                            //    }
                            //    if (ReadUrls.Length > 3 && File.Exists(ReadUrls[3]))
                            //    {
                            //        imgCapture3.Image = Image.FromFile(ReadUrls[3]);
                            //        lblAssetPhoto1.Visible = false;
                            //    }
                            //    if (ReadUrls.Length > 4 && File.Exists(ReadUrls[4]))
                            //    {
                            //        imgCapture4.Image = Image.FromFile(ReadUrls[4]);
                            //        lblAssetPhoto2.Visible = false;
                            //    }
                            //    if (ReadUrls.Length > 5 && File.Exists(ReadUrls[5]))
                            //    {
                            //        imgCapture5.Image = Image.FromFile(ReadUrls[5]);
                            //        lblAssetPhoto3.Visible = false;
                            //    }
                            //}
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Image not found for this path: " + verifyResult.imageUrls, "Asset Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    //btnVerifyAsset.Focus();
                        //    //return;
                        //}

                        //Display User's Information
                        //if (File.Exists(verifyResult.owner.imageUrl)) picOwner.Image =  Image.FromFile(verifyResult.owner.imageUrl);
                        //txtOwnerName.Text = verifyResult.owner.lastName + " " + verifyResult.owner.firstName;
                        //txtOwnerPosition.Text = verifyResult.owner.position;
                        //txtOwnerDescription.Text = verifyResult.owner.description;

                        //VerifyTimer.Stop();
                        //VerifyTimer.Start();

                        //ClearTimer.Stop();
                        //ClearTimer.Start();

                        txtValidUntil.Text = verifyResult.validUntil != DateTime.MinValue ? verifyResult.validUntil.ToString("g") : "No Expiration";

                        //Validate Asset Validity Expiration
                        if (verifyResult.validUntil < Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.validUntil != DateTime.MinValue)
                        {
                            if (roleValue == "ROLE_ADMIN")
                            {
                                DialogResult result = MessageBox.Show("Asset is already expired." + "\n" + "Do you want to renew the asset?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.Yes)
                                {
                                    IsCallingMainMenu = true;
                                    reader.CloseCom();

                                    using (AssetRenewal RenewalForm = new AssetRenewal())
                                    {
                                        if (RenewalForm.ShowDialog() == DialogResult.OK)
                                        {
                                            btnSubmit.Text = "Renewed";
                                        }

                                        IsCallingMainMenu = false;
                                        ReaderMethodProc();
                                        VerifyAssetProc(); 
                                    }
                                }
                            }
                            else if (roleValue == "ROLE_GUARD")
                            {
                                MessageBox.Show("Asset is already expired." + "\n" + "Please go to admin for renewal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        btnBack.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(verifyResult.result + " " + verifyResult.message);
                        //MessageBox.Show("RFID Tag: " + txtRFIDTag.Text + " " + verifyResult.message);
                    }
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Error connecting to server.. please try again later");
                }
                else
                {
                    HttpStatusCode statusCode = response.StatusCode;
                    int numericStatusCode = (int)statusCode;
                    //show error code
                    MessageBox.Show("Error" + numericStatusCode);
                }

                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            txtValidUntil.Text = string.Empty;
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

            btnSubmit.Text = "Submit";
            btnReport.Text = "Report";
            this.Refresh();
        }

        private void Verification_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            LoopVerification(); 
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

                    nReturnValue = realTimeInventory(255, 255, 1);  //Public address reader , fast inventory mode , 5 seconds timeout control

                    if (nReturnValue == 1)
                    {
                        ClearFields();

                        for (int i = 0; i < RealTimeTagDataList.Count; i++)
                        {
                            tagInfo = RealTimeTagDataList[i].strEpc;//tagInfo = RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    ";// tagInfo = "antenna" + RealTimeTagDataList[i].btAntId.ToString() + "    " + RealTimeTagDataList[i].strEpc + "    " + RealTimeTagDataList[i].strCarrierFrequency + "    " + RealTimeTagDataList[i].strRssi;
                            //listBox1.Items.Add(tagInfo);
                            txtRFIDTag.Text = tagInfo.ToString();
                        }
                        CheckRFIDTag();
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
                        return;
                    }
                    ReaderMethodProc();
                    VerifyAssetProc();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Reader is not connected.");
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
                SerialPortSelection PortSelectionForm = new SerialPortSelection(tokenvalue, roleValue);

                // Show PortSelectionForm as a modal dialog and determine if DialogResult = OK.
                if (PortSelectionForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of PortSelectionForm's cmbComPortList.
                    portname = PortSelectionForm.cmbComPortList.Text;
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
            ValidateRule();
        }

        #region Timer Procedure
        private void BackgroundTimer_Tick(object sender, EventArgs e)
        {
            //Always read the RFID Tag if not calling the Main Menu
            if (!IsCallingMainMenu)
            {
                BackgroundTimer.Stop();
                VerifyAssetProc();
                LoopVerification();
            }
        }

        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            //Display the current date and time
            lblCurrentDateTime.Text = DateTime.Now.ToString("h:mm:ss tt") + "\n " + DateTime.Now.ToString("MM/dd/yyyy");//DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void VerifyTimer_Tick(object sender, EventArgs e)
        {
            ////ClearFields();
            //VerifyTimer.Stop();
            //LoopVerification();
        }

        private void ClearTimer_Tick(object sender, EventArgs e)
        {
            //ClearFields();
            //ClearTimer.Stop();
        }
        #endregion

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationMessage();
                if (!IsCallingMainMenu) return;

                IsCallingMainMenu = true;
                reader.CloseCom();

                using (ReportCreation ReportCreationForm = new ReportCreation())
                {
                    if (ReportCreationForm.ShowDialog() == DialogResult.OK)
                    {
                        //btnSave.Visible = false;
                        btnReport.Text = "Reported";//btnCreateReport.Visible = false;
                        //grpBoxReportedInfo.Visible = true;

                        //// Read the contents of PortSelectionForm's.
                        //picPersonBroughtOut.Image = ReportCreationForm.PersonPhoto;
                        //txtReportedNote.Text = " " + ReportCreationForm.ExplanationNote;
                    }
                    //else
                    //{
                    //    IsCallingMainMenu = false;
                    //    LoopVerification();
                    //}

                    IsCallingMainMenu = false;
                    ReaderMethodProc();
                    VerifyAssetProc();
                    //ReportCreationForm.Dispose();   
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
                if (btnSubmit.Text.Trim().ToUpper() == "SUBMITTED" || btnSubmit.Text.Trim().ToUpper() == "RENEWED" || btnReport.Text.Trim().ToUpper() == "REPORTED" || txtRFIDTag.Text.Length == 0)
                {
                    ValidationMessage();
                    return;
                }

                IsCallingMainMenu = true;
                reader.CloseCom();

                //For Web Service
                Transaction transactDet = new Transaction();

                transactDet.companyId = companyId;//1;
                transactDet.readerInfo = readerInfo;
                //transactDet.readerId = 1;
                transactDet.assetId = Verification.AssetIdValue;
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
                    RestResult restResult = deserial.Deserialize<RestResult>(response);

                    if (restResult.result == "OK")
                    {
                        btnSubmit.Text = "SUBMITTED";
                        MessageBox.Show("Record successfully saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        IsCallingMainMenu = false;
                        ReaderMethodProc();
                        VerifyAssetProc();
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
            IsCallingMainMenu = true;
            reader.CloseCom();

            if (btnSubmit.Text.Trim().ToUpper() == "SUBMITTED")
            {
                MessageBox.Show("Record is already submitted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSubmit.Focus();
                IsCallingMainMenu = false;
            }

            if (btnSubmit.Text.Trim().ToUpper() == "RENEWED")
            {
                MessageBox.Show("Asset is already renewed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSubmit.Focus();
                IsCallingMainMenu = false;
            }

            if (btnReport.Text.Trim().ToUpper() == "REPORTED")
            {
                MessageBox.Show("Record is already reported.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnReport.Focus();
                IsCallingMainMenu = false;
            }

            if (txtRFIDTag.Text.Length == 0)
            {
                MessageBox.Show("RFID Tag is required. Please scan...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSubmit.Focus();
                IsCallingMainMenu = false;
            }

            ReaderMethodProc();
            VerifyAssetProc();
            //return;
        }

    }

    public class VerifyRequest
    {
        public int companyId {get; set;}
        public string tag {get; set;}
        public int tagType{get; set;}
    }

    public class VerifyResult
    {
        public int assetId { get; set; }
        public string name {get; set;}
        public string description {get;set;}
        public string imageUrls {get;set;}
        public bool takOutAllowed {get;set;}
        public string takeOutInfo {get;set;}
        public DateTime validUntil { get; set; }
        public string result {get;set;}
        public string message {get;set;}
        public OwnerList owner { get; set; }
    }

    public class OwnerList
    {
        public int userId { get; set; }
        public int companyId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string position { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string email { get; set; }
        public string authorities { get; set; }
    }
}

