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
using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;

namespace RFID_FEATHER_ASSETS
{
    public delegate void AddTagT(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew);      // 更新标签信息invoke
    public delegate void FlushStateT();                                                       // 更新实时状态invoke

    public partial class Tracking : Form, IAsynchronousMessage
    {
        //string connectionString = "server=128.199.83.107;port=3306;uid=root;pwd=aws123;database=feather_assets;";
        public static int AssetIdValue = 0;
        public int companyId;
        string readerInfo;

        public static Reader.ReaderMethod reader;
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
        string displaySystemInfo;
        string ownerName;
        string userName;
        bool getOwnerNameOnly = false;

        //Clou
        public string ConnID = "";
        private bool IsStartRead = false;
        private bool IsFlush = false;
        Dictionary<String, DataGridViewRow> dic_Rows = new Dictionary<string, DataGridViewRow>(); // 在DataGridView中显示标签数据
        //public String readVarParam_6C = "";      
        string antReadLocation;
        string AntLocationInfo;
        bool save;
        string ant1Location;
        string ant2Location;
        string ant3Location;
        string ant4Location;

        #region 读写器能力

        private int minDB = 0;                                            // 最小功率
        private int maxDB = 36;                                           // 最大功率
        private int antCount = 2;                                         // 天线数目
        private List<Int32> bandList = new List<Int32>();                 // 频段列表
        private List<Int32> RFIDProtocolList = new List<Int32>();         // RFID协议列表

        #endregion


        public Tracking()//string tokenvaluesource, string roleSource) //(string tokenvaluesource, string portnamesource, string roleSource)
        {
            InitializeComponent();

            getLanguage();
            //languageHandler();
            GetAssetSystemInfo();
            //tokenvalue = tokenvaluesource;
            //roleValue = roleSource;
            //try { ReadLoopTimer.Start(); }
            //catch (Exception) { }

            if (AntLocationInfo != null) populateLocation();
        }

        private void populateLocation()
        {
            List<Ant1Location> loc1 = new List<Ant1Location>();
            List<Ant2Location> loc2 = new List<Ant2Location>();
            List<Ant3Location> loc3 = new List<Ant3Location>();
            List<Ant4Location> loc4 = new List<Ant4Location>();

            if (AntLocationInfo != null)
            {
                string[] locInfo = AntLocationInfo.Split(',');

                /*if (language == "Japanese")
                {
                    roles.Add(new GlobalClass.GetSetClass() { roleName = rm.GetString("Administrator"), value = "ROLE_ADMIN" });
                    roles.Add(new GlobalClass.GetSetClass() { roleName = rm.GetString("Security"), value = "ROLE_GUARD" });
                    //roles.Add(new Role() { roleName = "User", value = "ROLE_USER" });
                }
                else
                {*/

                for (int i = 0; i < locInfo.Length; i++)
                {

                    loc1.Add(new Ant1Location() { location = locInfo[i], value = "location_" + locInfo[i] });
                    loc2.Add(new Ant2Location() { location = locInfo[i], value = "location_" + locInfo[i] });
                    loc3.Add(new Ant3Location() { location = locInfo[i], value = "location_" + locInfo[i] });
                    loc4.Add(new Ant4Location() { location = locInfo[i], value = "location_" + locInfo[i] });
                }
                //roles.Add(new Role() { roleName = "User", value = "ROLE_USER" });
                /*}*/
                this.cmbLocationAnt1.DataSource = loc1;
                this.cmbLocationAnt1.ValueMember = "value";
                this.cmbLocationAnt1.DisplayMember = "location";

                this.cmbLocationAnt2.DataSource = loc2;
                this.cmbLocationAnt2.ValueMember = "value";
                this.cmbLocationAnt2.DisplayMember = "location";

                this.cmbLocationAnt3.DataSource = loc3;
                this.cmbLocationAnt3.ValueMember = "value";
                this.cmbLocationAnt3.DisplayMember = "location";

                this.cmbLocationAnt4.DataSource = loc4;
                this.cmbLocationAnt4.ValueMember = "value";
                this.cmbLocationAnt4.DisplayMember = "location";

                cmbLocationAnt1.Text = string.Empty;
                cmbLocationAnt2.Text = string.Empty;
                cmbLocationAnt3.Text = string.Empty;
                cmbLocationAnt4.Text = string.Empty;

                //this.cmbLocation.Text = readerInfo;
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
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.AssetTracking", Assembly.GetExecutingAssembly());
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
                this.Text = rm.GetString("Tracking");
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
                    displaySystemInfo = "User ID: " + (string)(key.GetValue("UserName")).ToString().ToUpper() + " | Company: " + (string)(key.GetValue("companyName").ToString().ToUpper()) + " | PC Location: " + (string)(key.GetValue("readerInfo")).ToString().ToUpper(); //+ " | " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
                    userName = (string)(key.GetValue("UserName")).ToString();
                    AntLocationInfo = (string)(key.GetValue("LocInfo"));
                    key.Close();

                    //if (roleValue == "ROLE_GUARD")
                    //{
                    //    if (language == "English") btnBack.Text = "Log Out";
                    //    else btnBack.Text = "ログアウト";
                    //    btnBack.BackColor = Color.Red;
                    //    btnBack.BackColor = Color.White;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tracking_Load(object sender, EventArgs e)
        {
            try
            {
                btnBack.Focus();

                //BackgroundTimer.Interval = 1000;

                CurrentDateTimer.Enabled = true;
                CurrentDateTimer.Interval = 1000;

                VerifyTimer.Interval = 3000;
                VerifyTimer.Tick += new EventHandler(VerifyTimer_Tick);

                //ClearGridTimer.Interval = 30000;
                //ClearGridTimer.Tick += new EventHandler(ClearGridTimer_Tick);

                //reader = new Reader.ReaderMethod();
                //////Callback
                ////reader.AnalyCallback = AnalyData;
                ////reader.ReceiveCallback = ReceiveData;
                ////reader.SendCallback = SendData;
                ////auto_connect();
                //ReaderMethodProc();

                //Clou  
                //clouReaderSetup();
                ////CheckConnID();
                clearAntLocBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearAntLocBox()
        {
            cmbLocationAnt1.Text = string.Empty;
            cmbLocationAnt2.Text = string.Empty;
            cmbLocationAnt3.Text = string.Empty;
            cmbLocationAnt4.Text = string.Empty;
        }

        private void CheckConnID()
        {
            //#region 还原控制状态

            //foreach (ToolStripItem item in menuStrip.Items)
            //{
            //    item.Enabled = true;
            //}
            //foreach (ToolStripItem item in tsm_Main.Items)
            //{
            //    item.Enabled = true;
            //}

            //#endregion

            if (String.IsNullOrEmpty(ConnID))
            {
                //foreach (ToolStripItem item in menuStrip.Items)
                //{
                //    item.Enabled = false;
                //}
                //tsmi_Connect.Enabled = true;
                //tsmi_SearchDevice.Enabled = true;
                //tsmi_Language.Enabled = true;
                //foreach (ToolStripItem item in tsm_Main.Items)
                //{
                //    item.Enabled = false;
                //}

                gb_ReadControl.Visible = true;
                //btnStartReading.Enabled = true;
            }
            else
            {
                if (IsStartRead)
                {
                    //foreach (ToolStripItem item in menuStrip.Items)
                    //{
                    //    item.Enabled = false;
                    //}
                    //tsmi_Connect.Enabled = true;
                    //tsmi_Helper.Enabled = true;
                    //tsb_Read_Epc.Enabled = false;
                    //tsb_Read_EPCTID.Enabled = false;
                    //tsb_Read_Global.Enabled = false;
                    //tsb_Write_EPC.Enabled = false;
                    //tsb_Write_UserData.Enabled = false;
                    //tsb_WriteGlobal.Enabled = false;

                    gb_ReadControl.Visible = false;
                    //btnStartReading.Enabled = false;
                }
            }
        }

        private void clouReaderSetup()
        {
            bool isConnect = false;
            ConnID = "COM1:115200";
            isConnect = CLReader.CreateSerialConn(ConnID, this);
            CLReader.CreateSerialConn(ConnID, new Verification());

            String rt = "";
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
            rt = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, GetReadTagParam(""));
            //if (!rt.StartsWith("0")) { MessageBox.Show("Read failed，Controller/Antenna is off or not connected!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!rt.StartsWith("0"))
            {
                MessageBox.Show("Read failed, Controller is off or Antenna not selected!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*connectDeviceSetup();*/
                return;
            }
            else
                tsb_Read_Enable();

            CLReader.DIC_CONNECT[ConnID].ProcessCount = 0;

            //StartFlush();                                  
            IsStartRead = true;
        }

        public String GetReadTagParam(String varParam)
        {
            //String rt = "1|1";

            String rt = "";

            #region 获取天线号 & 单次读取/循环读取

            Int32 antNUM = 0;
            Int32 singleOrWhile = -1;
            //antNUM += 1;
            //singleOrWhile = 1;
            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox control = item as CheckBox;
                if (control != null && control.Checked)
                {
                    antNUM += Int32.Parse(control.Tag.ToString());
                }
            }
            //foreach (var item in gb_ReadType.Controls)
            //{
            //    RadioButton control = item as RadioButton;
            //    if (control != null && control.Checked)
            //    {
                      singleOrWhile = 1;//Byte.Parse(control.Tag.ToString());
            //    }
            //}
            rt += (Byte)antNUM + "|" + singleOrWhile + "|";

            #endregion

            #region 可选参数

            if (!String.IsNullOrEmpty(varParam))
            {
                rt += varParam;
            }

            #endregion

            rt = rt.TrimEnd('|');
            return rt;
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
            //        MessageBox.Show("Reader Com Port Error.", "Asset Tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        IsPortError = true;
            //        return;

            //        //LoopTracking();
            //        //MessageBox.Show("Reader Com Port Error");
            //    }
            //    else if (nReturnValue == -2)
            //    {
            //        //MessageBox.Show("Reader Com Port Error");
            //        MessageBox.Show("Reader Com Port Error.", "Asset Tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        IsPortError = true;
            //        return;

            //        //LoopTracking();
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
                        if (!IsStopComparing && grdViewRFIDTag.Rows.Count > 0)
                        {
                            for (int i = startRowComparing; i < grdViewRFIDTag.Rows.Count; i++)
                            {
                                if (grdViewRFIDTag.Rows[i].Cells["colRFIDTag"].Value.ToString() == txtRFIDTag.Text /*&& grdViewRFIDTag.Rows[i].Cells["colIsCompared"].Value == null*/)
                                {
                                    IsRFIDTagExist = true;
                                    //txtRFIDTag.Text = string.Empty;
                                    if (totalAssetRead < grdViewRFIDTag.Rows.Count)
                                    {
                                        VerifyTimer.Start();
                                    }

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
                        if (grdViewRFIDTag.Rows.Count == 0 || !IsRFIDTagExist)
                        {
                            GlobalClass.GetSetClass verifyRequest = new GlobalClass.GetSetClass();
                            verifyRequest.tag = txtRFIDTag.Text;
                            verifyRequest.companyId = companyId;//1;
                            verifyRequest.tagType = 1;

                            //initialize web service
                            RestClient client =  new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                            RestRequest verify = new RestRequest("/api/asset/company-tag"/*"/api/asset/verify"*/, Method.POST);
                            var authToken = tokenvalue;

                            verify.AddHeader("X-Auth-Token", authToken);
                            verify.AddHeader("Content-Type", "application/json; charset=utf-8");
                            verify.RequestFormat = DataFormat.Json;
                            verify.AddBody(verifyRequest);

                            //execute response
                            IRestResponse response = client.Execute(verify);
                            var content = response.Content;

                            //btnVerifyAsset.Text = "Click to verify RFID Tag";
                            //btnVerifyAsset.BackColor = Color.Orange;
                            //lblLoadingInformation.Visible = false;
                            //client.ExecuteAsync(verify, response =>
                            //{
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    lblMsgAssetNotRegister.Visible = false;

                                    //deserialize JSON -> Object
                                    JsonDeserializer deserial = new JsonDeserializer();
                                    GlobalClass.GetSetClass verifyResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                                    //if (verifyResult.result == "OK")
                                    //{
                                    //this.Invoke(new MethodInvoker(delegate
                                    //{
                                        //if (grdViewRFIDTag.Rows.Count == 0 || !IsRFIDTagExist)
                                        //{
                                            //displayDataOnTable(verifyResult.validUntil, verifyResult.description, verifyResult.ownerUserId);

                                            if (!grdViewRFIDTag.ColumnHeadersVisible) grdViewRFIDTag.ColumnHeadersVisible = true;

                                            int idx = grdViewRFIDTag.Rows.Add();
                                            DataGridViewRow row = grdViewRFIDTag.Rows[idx];

                                            row.Cells["colDate"].Value = DateTime.Now.ToString();
                                            row.Cells["colViewerIcon"].ToolTipText = "Double click to view the details.";
                                            row.Cells["colViewerIcon"].Value = Properties.Resources.viewdetailsicon;
                                            row.Cells["colAssetID"].Value = verifyResult.assetId;
                                            row.Cells["colAssetDescription"].Value = verifyResult.description;
                                            //row.Cells["colTakeOutNote"].Value = verifyResult.takeOutInfo;
                                            row.Cells["colLocation"].Value = antReadLocation;//readerInfo;
                                            row.Cells["colClassification"].Value = verifyResult.assetType;
                                            //getownerInfo(verifyResult.ownerUserId);

                                            if (verifyResult.description.Contains("ID_CARD"))
                                            {
                                                //row.Cells["colIDTag"].Value = txtRFIDTag.Text;
                                                //row.Cells["colIDOwner"].Value = verifyResult.ownerUserId;
                                                //row.Cells["colOwnerName"].Value = verifyResult.name;
                                                row.Cells["colValidityPeriod"].Value = verifyResult.validUntil == null ? "Start " + verifyResult.startDate.Value.ToString("g") + " - No End Date" : "Start " + verifyResult.startDate.Value.ToString("g") + " Until " + verifyResult.validUntil.Value.ToString("g");
                                                //row.Cells["colAssetID"].Value = verifyResult.assetId;

                                                ////Check Validity Expiration
                                                //if (verifyResult.startDate > Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.startDate != DateTime.MinValue)
                                                //{
                                                //    row.Cells["colStatus"].Value = "INVALID";
                                                //    row.DefaultCellStyle.BackColor = Color.Black;
                                                //    row.DefaultCellStyle.ForeColor = Color.White;
                                                //    playAlarmSound("Expired");
                                                //}
                                                //else if (verifyResult.validUntil < Convert.ToDateTime(DateTime.Now.ToString("g")) && verifyResult.validUntil != DateTime.MinValue)
                                                //{
                                                //    row.Cells["colStatus"].Value = "EXPIRED";
                                                //    row.DefaultCellStyle.BackColor = Color.Orange;
                                                //    row.DefaultCellStyle.ForeColor = Color.White;
                                                //    playAlarmSound("Expired");
                                                //}
                                                //else
                                                //{
                                                //    row.Cells["colStatus"].Value = "OK";
                                                //    row.DefaultCellStyle.BackColor = Color.Green;
                                                //    row.DefaultCellStyle.ForeColor = Color.White;
                                                //    playAlarmSound("Ok");
                                                //}
                                                //SaveTransaction(row.Cells["colValidityPeriod"].Value.ToString(), verifyResult.name, verifyResult.position, verifyResult.email, verifyResult.userType, verifyResult.description, verifyResult.takeOutNote, verifyResult.ownerImageUrl, verifyResult.assetImageUrl, verifyResult.updatedBy, verifyResult.notes, "TRACK-Asset", verifyResult.assetId);
                                                SaveTransaction(row.Cells["colValidityPeriod"].Value.ToString(), verifyResult.name, verifyResult.description, verifyResult.takeOutInfo, /*verifyResult.imageUrls, verifyResult.updateUserId,*/ "TRACK-Owner", verifyResult.assetId, verifyResult.assetType, verifyResult.baseLocation);
                                            }
                                            else
                                            {
                                                ////row.Cells["colAssetTag"].Value = txtRFIDTag.Text;
                                                //row.Cells["colAssetOwner"].Value = verifyResult.ownerUserId;
                                                ////row.Cells["colAssetDescription"].Value = verifyResult.description;
                                                ////row.Cells["colTakeOutNote"].Value = verifyResult.takeOutInfo;
                                                //row.DefaultCellStyle.BackColor = Color.Yellow;
                                                //row.DefaultCellStyle.ForeColor = Color.Black;
                                                getOwnerNameOnly = true;
                                                getownerInfo(verifyResult.ownerUserId);
                                                SaveTransaction("", txtOwnerName.Text, verifyResult.description, verifyResult.takeOutInfo, /*verifyResult.imageUrls, verifyResult.updateUserId,*/ "TRACK-Asset", verifyResult.assetId, verifyResult.assetType, verifyResult.baseLocation);
                                            }

                                            //row.Cells["colStatus"].Value = "OK";
                                            row.DefaultCellStyle.BackColor = Color.Green;
                                            row.DefaultCellStyle.ForeColor = Color.White;
                                            playAlarmSound("Ok");

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
                                            //lblAssetCount.Visible = true;
                                            grdViewRFIDTag.Refresh();
                                            lblAssetCount.Text = "Asset Counts: " + grdViewRFIDTag.Rows.Count;

                                            grdViewRFIDTag.FirstDisplayedScrollingRowIndex = grdViewRFIDTag.RowCount - 1;
                                            //grdViewRFIDTag.Refresh();
                                            //ClearGridTimer.Stop();
                                            //IsStopComparing = false;
                                            //if (row.Cells["colStatus"].Value == null)
                                            //    SaveTransaction(verifyResult.assetId, "TRACK-Asset");
                                            //else
                                            //    SaveTransaction(verifyResult.assetId, "TRACK-Owner-" + row.Cells["colStatus"].Value.ToString());
                                            //ClearGridTimer.Stop();
                                            //txtRFIDTag.Text = string.Empty;
                                            IsStopComparing = false;
                                        //}

                                        //btnBack.Focus();
                                        return;
                                        //}
                                        //else
                                        //{
                                        //    MessageBox.Show(verifyResult.result + " " + verifyResult.message);
                                        //    //MessageBox.Show("RFID Tag: " + txtRFIDTag.Text + " " + verifyResult.message);
                                        //}
                                    //}));
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
                                    //MessageBox.Show("Error" + numericStatusCode);
                                    //SendKeys.Send("{ESC}");
                                    lblMsgAssetNotRegister.Visible = true;
                                }

                            //});

                            //ClearFields();
                    //    }));
                    //    return;

                      }
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

            if (description.Contains("ID_CARD"))
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

        private void SaveTransaction(string validityPeriod, string srcownerName, string description, string takeOutNote, /*string imageUrls, string updatedBy,*/ string type, int assetId, string classification, string baseLocation)
        {
            //Saving to transaction table
            try
            {
                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                //transactDet.companyId = companyId;//1;
                //transactDet.validityPeriod = validityPeriod;
                //transactDet.ownerName = ownerName;
                //transactDet.position = position;
                //transactDet.email = email;
                //transactDet.userType = userType;
                //transactDet.description = description;
                //transactDet.takeOutNote = takeOutNote;
                //transactDet.ownerImageUrl = ownerImageUrl;
                //transactDet.assetImageUrl = assetImageUrl;
                //transactDet.updatedBy = updatedBy;
                //transactDet.readerInfo = readerInfo;
                //transactDet.notes = notes;
                //transactDet.type = type;
                //transactDet.assetId = assetId;

                transactDet.companyId = companyId;//1;
                transactDet.validityPeriod = validityPeriod;

                //int n;
                //bool isNumeric = int.TryParse(srcownerName, out n);
                //if (isNumeric)
                //{
                //    getownerInfo(n);
                //    transactDet.ownerName = txtOwnerName.Text;//ownerName;
                //}
                transactDet.ownerName = srcownerName;// ownerName;
                //transactDet.position = position;
                //transactDet.email = email;
                //transactDet.userType = userType;
                transactDet.description = description;
                transactDet.takeOutNote = takeOutNote;
                //transactDet.ownerImageUrl = ownerImageUrl;
                //transactDet.assetImageUrl = newImgFileNames;
                //transactDet.imageUrls = imageUrls;
                transactDet.updatedBy = userName;//updatedBy;
                transactDet.readerInfo = antReadLocation;//readerInfo;
                //transactDet.notes = notes;
                transactDet.type = type;
                transactDet.assetId = assetId;
                transactDet.location = baseLocation;
                transactDet.classType = classification;

                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://feather-assets.herokuapp.com/");
                RestRequest transact = new RestRequest("/api/asset/transact", Method.POST);

                var authToken = tokenvalue;
                transact.AddHeader("X-Auth-Token", authToken);
                transact.AddHeader("Content-Type", "application/json; charset=utf-8");
                transact.RequestFormat = DataFormat.Json;
                transact.AddBody(transactDet);

                //execute response
                IRestResponse response = client.Execute(transact);
                lblSubmittingInformation.Visible = false;

                var content = response.Content;
                //client.ExecuteAsync(transact, response =>
                //{
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
                //});
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
            txtClassification.Text = string.Empty;
            txtBaseLocation.Text = string.Empty;
            this.Refresh();
        }

        private void Tracking_Shown(object sender, EventArgs e)
        {
            //this.Refresh();
            //LoopTracking(); 
            connectDeviceSetup();
        }

        private void connectDeviceSetup()
        {
            //if (!IsMultiConnect) { CloseNowConnect(); }
            ConnectDeviceT addConnForm = new ConnectDeviceT(this, 0);
            DialogResult dr = addConnForm.ShowDialog(this);
            this.Focus();
            if (dr == DialogResult.OK)
            {
                //tssl_NowConnID.Text = ConnID;
                ////Init();
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Open Connection Failure.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                connectDeviceSetup();
            }
            else ValidateRule();
        }

        private void Init()
        {
            InitReaderProerty();
            CheckConnID();

            #region 天线能力

            foreach (var item in gb_ReadControl.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    int index = Int32.Parse(cb.Name.Substring(cb.Name.Length - 1, 1));
                    if (index > antCount)
                    {
                        cb.Enabled = false;
                        cb.Checked = false;
                    }
                    else
                    {
                        cb.Enabled = true;
                    }
                }
            }

            #endregion

            grdViewRFIDTag.AutoGenerateColumns = false;
            Type type = grdViewRFIDTag.GetType();
            System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(grdViewRFIDTag, true, null);
        }

        private void InitReaderProerty()
        {
            string strReaderProperty = ClouReaderAPI.CLReader.RFID_OPTION.GetReaderProperty(ConnID);
            string[] str_array = strReaderProperty.Split('|');
            if (str_array.Length == 5)
            {
                try
                {
                    minDB = Int32.Parse(str_array[0]);
                    maxDB = Int32.Parse(str_array[1]);
                    antCount = Int32.Parse(str_array[2]);
                    string[] str_bandList = str_array[3].Split(',');
                    string[] str_RFIDProtocolList = str_array[4].Split(',');
                    for (int i = 0; i < str_bandList.Length; i++)
                    {
                        bandList.Add(Int32.Parse(str_bandList[i]));
                    }
                    for (int i = 0; i < str_RFIDProtocolList.Length; i++)
                    {
                        RFIDProtocolList.Add(Int32.Parse(str_RFIDProtocolList[i]));
                    }
                }
                catch { }
            }
        }

        private void LoopTracking()
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
                        //MessageBox.Show("Reader Com Port Error.", "Asset Tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CallSerialPortSelection();
                        //IsPortError = true;
                        //return;

                        //LoopTracking();
                        ReaderMethodProc();
                    }
                    else if (nReturnValue == -2)
                    {
                        //MessageBox.Show("Reader Com Port Error.", "Asset Tracking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CallSerialPortSelection();
                        //IsPortError = true;
                        //return;

                        //LoopTracking();
                        ReaderMethodProc();
                    }
                    else
                    {
                        if (totalAssetRead < grdViewRFIDTag.Rows.Count)
                        {
                            VerifyTimer.Start();
                        }
                        //return;
                    }
                    //ReaderMethodProc();
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
                //this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ValidateRule();

            if (RegisterUser.regOwnerCon) RegisterUser.reader.CloseCom();
            if (RegisterUser.cam != null) RegisterUser.cam.Stop();

            if (AssetRegistration.regAssetCon) AssetRegistration.reader.CloseCom();
            if (AssetRegistration.cam != null) AssetRegistration.cam.Stop();

            //Clou
            IsStartRead = false;
            IsFlush = false;
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);

            CloseNowConnect();

            ValidateRule();
        }

        private void CloseNowConnect()
        {
            if (!String.IsNullOrEmpty(ConnID))
            {
                try
                {
                    if (IsStartRead)         // 正在读取标签的情况断开连接
                    {
                        ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
                        IsStartRead = false;
                    }
                    ClouReaderAPI.CLReader.CloseConn(ConnID);
                    ConnID = "";
                }
                catch { }
            }
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

                //this.Hide();
                //reader.CloseCom();
                this.Dispose();
                LoginActivity LoginForm = new LoginActivity();
                LoginForm.Show();
            }
        }

        private void CallMainMenu()
        {
            //Return to Main Menu Form
            IsCallingMainMenu = true;

            //this.Hide();
            ////reader.CloseCom();
            //MainMenu MenuForm = new MainMenu(tokenvalue, roleValue);
            //MenuForm.Show();
            this.Close();
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
            //    LoopTracking();
            //}
        }

        private void VerifyTimer_Tick(object sender, EventArgs e)
        {
            ////ClearFields();
            //LoopTracking();
            VerifyTimer.Stop();
  
            if (!string.IsNullOrEmpty(txtRFIDTag.Text.Trim()) /*&& totalAssetRead < grdViewRFIDTag.Rows.Count*/)
            {
                //for (int a = startRowComparing; a < grdViewRFIDTag.Rows.Count; a++)
                //{
                //    //For Asset Row (aRow)
                //    DataGridViewRow aRow = grdViewRFIDTag.Rows[a];
                //    if (aRow.Cells["colAssetOwner"].Value != null /*&& Convert.ToString(aRow.Cells["colStatus"].Value).ToString() != "OK" && Convert.ToString(aRow.Cells["colStatus"].Value).ToString() != "EXPIRED"*/)
                //    {
                //        for (int o = startRowComparing; o < grdViewRFIDTag.Rows.Count; o++)
                //        {
                //            //For ID Row (iRow)
                //            DataGridViewRow iRow = grdViewRFIDTag.Rows[o];
                //            if (Convert.ToString(aRow.Cells["colAssetOwner"].Value).ToString() == Convert.ToString(iRow.Cells["colIDOwner"].Value).ToString())
                //            {
                //                //aRow.Cells["colIDTag"].Value = iRow.Cells["colIDTag"].Value;
                //                aRow.Cells["colOwnerName"].Value = iRow.Cells["colOwnerName"].Value;
                //                aRow.Cells["colValidityPeriod"].Value = iRow.Cells["colValidityPeriod"].Value;
                //                //aRow.Cells["colStatus"].Value = "OK";
                //                //aRow.DefaultCellStyle.BackColor = Color.Green;
                //                //aRow.DefaultCellStyle.ForeColor = Color.White;
                //                iRow.DataGridView.Rows[o].Visible = false;
                //                //aRow.Cells["colIsCompared"].Value = "YES";

                //                if (Convert.ToString(iRow.Cells["colStatus"].Value).ToString() != "EXPIRED" && Convert.ToString(iRow.Cells["colStatus"].Value).ToString() != "INVALID")
                //                {
                //                    aRow.Cells["colStatus"].Value = "OK";
                //                    aRow.DefaultCellStyle.BackColor = Color.Green;
                //                    aRow.DefaultCellStyle.ForeColor = Color.White;
                //                }
                //                else
                //                {
                //                    if (Convert.ToString(iRow.Cells["colStatus"].Value).ToString() == "INVALID")
                //                    {
                //                        aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                //                        aRow.Cells["colStatus"].Value = "INVALID";
                //                        aRow.DefaultCellStyle.BackColor = Color.Black;
                //                        aRow.DefaultCellStyle.ForeColor = Color.White;
                //                    }
                //                    else
                //                    {
                //                        aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                //                        aRow.Cells["colStatus"].Value = "EXPIRED";
                //                        aRow.DefaultCellStyle.BackColor = Color.Orange;
                //                        aRow.DefaultCellStyle.ForeColor = Color.White;
                //                    }
                //                    //aRow.Cells["colAssetID"].Value = iRow.Cells["colAssetID"].Value;
                //                    //aRow.DefaultCellStyle.BackColor = Color.Orange;
                //                    //aRow.DefaultCellStyle.ForeColor = Color.White;
                //                    aRow.Cells["colStatus"].ToolTipText = aRow.Cells["colValidityPeriod"].Value.ToString();
                //                }
                //                //playAlarmSound("Ok");
                //                break;
                //            }
                //            else if (o == grdViewRFIDTag.Rows.Count - 1)
                //            {
                //                aRow.Cells["colStatus"].Value = "UNAUTHORIZED";
                //                aRow.DefaultCellStyle.BackColor = Color.Red;
                //                aRow.DefaultCellStyle.ForeColor = Color.White;
                //                SaveTransaction(Convert.ToInt32(aRow.Cells["colAssetID"].Value.ToString()), "VERIFY-Asset-" + aRow.Cells["colStatus"].Value.ToString());
                //                //aRow.Cells["colIsCompared"].Value = "YES";
                //                playAlarmSound("Unauthorized");
                //                //break;
                //            }
                //        }
                //    }
                   
                    //if (a == grdViewRFIDTag.Rows.Count - 1)
                    //{
                            txtRFIDTag.Text = string.Empty;
                            totalAssetRead = grdViewRFIDTag.Rows.Count;//a + 1;
                            grdViewRFIDTag.ClearSelection();

                            IsStopComparing = true;
                            startRowComparing = grdViewRFIDTag.Rows.Count;
                            IsRFIDTagExist = false;

                    //    //ClearGridTimer.Start();
                    //}
                //}
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

                using (ReportCreation ReportCreationForm = new ReportCreation(AssetIdValue, txtOwnerName.Text, txtDescription.Text, txtTakeOutNote.Text, txtClassification.Text, txtBaseLocation.Text))
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
                    //    LoopTracking();
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
                transactDet.assetId = AssetIdValue;//Tracking.AssetIdValue;
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

                //execute response
                //IRestResponse response = client.Execute(transact);
                lblSubmittingInformation.Visible = false;

                //var content = response.Content;
                client.ExecuteAsync(transact, response =>
                {
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
                });

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

            //client.ExecuteAsync<GlobalClass.GetSetClass>(ownerInfo, response =>
            //{
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize json response into object
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass info = deserial.Deserialize<GlobalClass.GetSetClass>(response);
                    //this.Invoke(new MethodInvoker(delegate
                    //{
                        if (!getOwnerNameOnly)
                        {
                            string urls = info.imageUrl;

                            if (string.IsNullOrEmpty(urls))
                            {
                                lblOwnerPhoto.Text = "NO" + "\n" + "Owner Photo";
                                lblValidIDPhoto.Text = "NO" + "\n" + "Valid ID Photo";
                            }

                            if (urls != null)
                            {
                                string[] ReadUrls = urls.Split(',');

                                if (ReadUrls.Length > 0)
                                {
                                    imgCapture1.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[0]);
                                    lblOwnerPhoto.Visible = false;
                                }
                                if (ReadUrls.Length > 1)
                                {
                                    imgCapture2.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[1]);
                                    lblValidIDPhoto.Visible = false;
                                }
                            }
                        }
                        //ownerName = info.lastName + ", " + info.firstName;
                        txtOwnerName.Text = info.lastName + ", " + info.firstName;
                        //ValidateExpiration(/*validity*/);
                    //}));\
                        getOwnerNameOnly = false;
                }
                else
                {
                    MessageBox.Show("Unable to reach server.. please try again later", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //});
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
                        //if (txtDescription.Text.Trim().Contains("ID_CARD"))
                            result = MessageBox.Show("ID is already expired." + "\n" + "Do you want to renew the ID?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        //else
                        //    result = MessageBox.Show("Asset is already expired." + "\n" + "Do you want to renew the Asset?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        //if (txtDescription.Text.Trim().Contains("ID_CARD"))
                        //    result = MessageBox.Show("ID is already expired." + "\n" + "Do you want to renew the ID?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        //else
                            result = MessageBox.Show("アセットはすでに有効期限が切れています." + "\n" + "あなたは資産を更新したいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }

                    if (result == DialogResult.Yes)
                    {
                        //IsCallingMainMenu = true;
                        //reader.CloseCom();

                        using (AssetRenewal RenewalForm = new AssetRenewal(AssetIdValue, txtOwnerName.Text, txtDescription.Text, txtTakeOutNote.Text, txtClassification.Text, txtBaseLocation.Text))
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
                    //if (grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value.ToString() == "UNAUTHORIZED")
                    //{
                    //    btnBack.Width = 145;
                    //    btnReport.Visible = true;
                    //    //btnReport.PerformClick();
                    //}
                    //else
                    //{
                        btnBack.Width = 269;
                        btnReport.Visible = false;
                    //}
                    ////this.Refresh();

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

                    //execute response
                    //IRestResponse response = client.Execute(assetinfo);
                    //var content = response.Content;

                    //client.ExecuteAsync(assetinfo, response =>
                    //{
 
                       //var content = response.Content;
                    //   this.Invoke(new MethodInvoker(delegate
                    //{
                       //lblLoadingInformation.Visible = false;
                    client.ExecuteAsync<RestResponse>(assetinfo, response =>
                       {
                           if (response.StatusCode == HttpStatusCode.OK)
                           {
                               JsonDeserializer deserial = new JsonDeserializer();
                               GlobalClass.GetSetClass assetInfo = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                               this.Invoke(new MethodInvoker(delegate
                               {
                                   lblLoadingInformation.Visible = false;
                                    string urls = assetInfo.imageUrls;
                               
                                    if (string.IsNullOrEmpty(urls))
                                    {
                                        //this.Invoke(new MethodInvoker(delegate
                                        //{
                                        lblAssetPhoto1.Text = "NO" + "\n" + "Asset Photo 1";
                                        lblAssetPhoto2.Text = "NO" + "\n" + "Asset Photo 2";
                                        lblAssetPhoto3.Text = "NO" + "\n" + "Asset Photo 3";
                                        //}));
                                    }

                                    if (urls != null && !assetInfo.description.Contains("ID_CARD"))
                                    {
                                        string[] ReadUrls = urls.Split(',');
                                        //this.Invoke(new MethodInvoker(delegate
                                        //{
                                        if (ReadUrls.Length > 0)
                                        {
                                            imgCapture3.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[0]);
                                            lblAssetPhoto1.Visible = false;
                                        }
                                        if (ReadUrls.Length > 1)
                                        {
                                            imgCapture4.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[1]);
                                            lblAssetPhoto2.Visible = false;
                                        }
                                        if (ReadUrls.Length > 2)
                                        {
                                            imgCapture5.Load("http://52.163.93.95:8080/FeatherAssets/api/images/1/asset/" + ReadUrls[2]);
                                            lblAssetPhoto3.Visible = false;
                                        }
                                        //}));
                                    }

                                    txtValidityPeriod.Text = Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colValidityPeriod"].Value).ToString();
                                    txtRFIDTag.Text = getAsset.tag;
                                    //AssetIdValue = assetInfo.assetId;
                                    //updatedImgFileNames = assetInfo.imageUrls;
                                    txtDescription.Text = assetInfo.description;
                                    //assetName = assetInfo.name;

                                    //if (assetInfo.description.Contains("ID_CARD"))
                                    //    txtDescription.ReadOnly = true;
                                    //else txtDescription.ReadOnly = false;

                                    txtTakeOutNote.Text = assetInfo.takeOutInfo;
                                    txtClassification.Text = assetInfo.assetType;
                                    txtBaseLocation.Text = assetInfo.baseLocation;

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
                                    //if (Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value).ToString() == "INVALID")
                                    //{
                                    //    MessageBox.Show("ID is not yet valid." + "\n" + "Please check the start date of validity.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //    btnBack.PerformClick();
                                    //}
                                    //if (Convert.ToString(grdViewRFIDTag.Rows[e.RowIndex].Cells["colStatus"].Value).ToString() == "EXPIRED")
                                    //{
                                    //    AssetIdValue = Convert.ToInt32(grdViewRFIDTag.Rows[e.RowIndex].Cells["colAssetID"].Value.ToString());//assetInfo.assetId;
                                    //    ValidateExpiration();
                                    //}
                                    //else AssetIdValue = assetInfo.assetId
                                    AssetIdValue = assetInfo.assetId;
                                }));
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
                       });
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

        private void CurrentDateTimer_Tick(object sender, EventArgs e)
        {
            ////Display the current date and time
            //lblCurrentDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");//DateTime.Now.ToString("h:mm:ss tt") + "\n " + DateTime.Now.ToString("MM/dd/yyyy");//DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblSystemInfo.Text = displaySystemInfo + " | Date: " + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
        }

        //Clou
        #region Interface Method
        // Tag Data
        public void OutPutTags(ClouReaderAPI.Models.Tag_Model tag_Model)
        {
            //Console.WriteLine("EPC:" + tag.EPC + " - TID:" + tag.TID + " - UserData:" + tag.UserData);

            //ReadTagBeep();
            //if (!IsShowTag) return;
            if (tag_Model == null || tag_Model.Result != 0x00) return;

            bool isNew = true; //false;
            DataGridViewRow dgvr = null;
            //lock (dic_Rows)
            //{
            //    try
            //    {
            //        //if (!dic_Rows.ContainsKey(tag_Model.EPC + "|" + tag_Model.TID))
            //        //{
            //        //    dgvr = new DataGridViewRow();
            //            //dgvr.CreateCells(grdViewRFIDTag, new object[] { tag_Model.ReaderName, tag_Model.TagType, tag_Model.EPC, tag_Model.TID, tag_Model.UserData, tag_Model.TagetData, tag_Model.TotalCount, tag_Model.ANT1_COUNT, tag_Model.ANT2_COUNT, tag_Model.ANT3_COUNT, tag_Model.ANT4_COUNT, tag_Model.ANT5_COUNT, tag_Model.ANT6_COUNT, tag_Model.ANT7_COUNT, tag_Model.ANT8_COUNT, tag_Model.RSSI, tag_Model.Frequency, tag_Model.Phase, tag_Model.ReadTime });
            //            //dic_Rows.Add(tag_Model.EPC + "|" + tag_Model.TID, dgvr);
            //            isNew = true;
            //        //}
            //        //else
            //        //{
            //        //    dgvr = dic_Rows[tag_Model.EPC + "|" + tag_Model.TID];
            //        //}
            //    }
            //    catch { }
            //}
            AddSingleTag(tag_Model, dgvr, isNew);

            //txtRFIDTag.Invoke(new MethodInvoker(delegate
            //{
            //    txtRFIDTag.Text = tag_Model.EPC.ToString();
            //    antReadLocation = tag_Model.ANT_NUM.ToString();

            //    CheckRFIDTag();
            //}));

        }

        public void AddSingleTag(Tag_Model tag_6C, DataGridViewRow dgvr, Boolean isNew)
        {
            if (this.grdViewRFIDTag.InvokeRequired)
            {
                this.grdViewRFIDTag.BeginInvoke(new AddTagT(AddSingleTag), tag_6C, dgvr, isNew);
                return;
            }
            try
            {
                txtRFIDTag.Text = tag_6C.EPC.ToString();
                //antReadLocation = tag_6C.ANT_NUM.ToString();

                switch (tag_6C.ANT_NUM)
                {
                    case 1:
                        antReadLocation = ant1Location;
                        break;
                    case 2:
                        antReadLocation = ant2Location;
                        break;
                    case 3:
                        antReadLocation = ant3Location;
                        break;
                    case 4:
                        antReadLocation = ant4Location;
                        break;
                    default:
                        //Console.WriteLine("Default case");
                        break;
                }

                //if (!isNew)
                //{
                //    //Int64 newStr = (Int64)dgvr.Cells["clm_TotalCount"].Value + 1;
                //    //dgvr.Cells["clm_TotalCount"].Value = newStr;
                //    //if (tag_6C.ANT_NUM <= 8)
                //    //{
                //    //    dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value = (Int64)dgvr.Cells["clm_ANT" + tag_6C.ANT_NUM].Value + 1;
                //    //}
                //    //dgvr.Cells["clm_RSSI"].Value = tag_6C.RSSI;
                //    //dgvr.Cells["clm_ReadTime"].Value = tag_6C.ReadTime;
                //}
                //else
                //{
                    //grdViewRFIDTag.Rows.Add(dgvr);
                    CheckRFIDTag();
                //}
                //this.led_Tag_ReadCount.Text = CLReader.DIC_CONNECT[ConnID].ProcessCount.ToString();
            }
            catch { }
        }

        private void InitDataGridView()
        {
            //if (grdViewRFIDTag.InvokeRequired)
            //{
            //    grdViewRFIDTag.BeginInvoke(new MethodInvoker(InitDataGridView), null);
            //    return;
            //}
            //try
            //{
            //    Int32 scrollHeight = grdViewRFIDTag.FirstDisplayedScrollingRowIndex;
            //    BindingSource bs = new BindingSource();
            //    bs.DataSource = ClouReaderAPI.CLReader.DIC_CONNECT[ConnID].dic_NowTags.Values;
            //    bs.SuspendBinding();
            //    grdViewRFIDTag.DataSource = bs;
            //    grdViewRFIDTag.FirstDisplayedScrollingRowIndex = scrollHeight;
            //}
            //catch { }
        }

        public void WriteDebugMsg(string msg)
        {

        }

        public void WriteLog(string msg)
        {

        }

        public void PortConneting(string connID)
        {

        }

        public void PortClosing(string connID)
        {

        }

        public void OutPutTagsOver()
        {
            //this.led_Tag_Count.Text = dic_Rows.Count.ToString();
            IsFlush = false;
        }

        public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
        {

        }

        #endregion

        private void Tracking_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
        }

        private void btnStartReading_Click(object sender, EventArgs e)
        {
            try
            {
                if ((chkAnt1.Checked && string.IsNullOrEmpty(cmbLocationAnt1.Text)) || (chkAnt2.Checked && string.IsNullOrEmpty(cmbLocationAnt2.Text)) || (chkAnt3.Checked && string.IsNullOrEmpty(cmbLocationAnt3.Text)) || (chkAnt4.Checked && string.IsNullOrEmpty(cmbLocationAnt4.Text)) || (!chkAnt1.Checked && !chkAnt2.Checked && !chkAnt3.Checked && !chkAnt4.Checked))
                {
                    MessageBox.Show("Location is required.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    btnStartReading.Text = "Please wait...";

                    //validate and save location
                    if (chkAnt1.Checked && !AntLocationInfo.Contains(cmbLocationAnt1.Text))
                    {
                        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt1.Text;
                        save = true;
                    }
                    if (chkAnt2.Checked && !AntLocationInfo.Contains(cmbLocationAnt2.Text))
                    {
                        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt2.Text;
                        save = true;
                    }
                    if (chkAnt3.Checked && !AntLocationInfo.Contains(cmbLocationAnt3.Text))
                    {
                        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt3.Text;
                        save = true;
                    }
                    if (chkAnt4.Checked && !AntLocationInfo.Contains(cmbLocationAnt4.Text))
                    {
                        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt4.Text;
                        save = true;
                    }

                    //string[] loc = AntLocationInfo.Split(',');
                    //for (int i = 0; i < loc.Length; i++)
                    //{
                    //    if (loc[i].ToLower() == cmbLocationAnt1.Text.ToLower() || loc[i].ToLower() == cmbLocationAnt2.Text.ToLower() || loc[i].ToLower() == cmbLocationAnt3.Text.ToLower() || loc[i].ToLower() == cmbLocationAnt4.Text.ToLower())
                    //    {
                    //        save = false;
                    //        break;
                    //    }
                    //    else
                    //        save = true;

                    //}
                    if (save == true)
                    {
                        //Save AntLocation
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

                        //storing the values  
                        key.SetValue("LocInfo", AntLocationInfo);
                        key.Close();
                    }

                    //assign antenna value
                    ant1Location = cmbLocationAnt1.Text;
                    ant2Location = cmbLocationAnt2.Text;
                    ant3Location = cmbLocationAnt3.Text;
                    ant4Location = cmbLocationAnt4.Text;

                    String rt = "";
                    ClouReaderAPI.CLReader.RFID_OPTION.StopReader(ConnID);
                    rt = ClouReaderAPI.CLReader.RFID_OPTION.GetEPC(ConnID, GetReadTagParam(""));
                    if (!rt.StartsWith("0")) 
                    { 
                        MessageBox.Show("Read failed, Controller is off or Antenna not selected!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        /*connectDeviceSetup();*/
                        btnStartReading.Text = "Start Reading";
                        return; 
                    }
                    else
                        tsb_Read_Enable();
                }
                        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsb_Read_Enable()
        {
            //CLReader.DIC_CONNECT[ConnID].ProcessCount = 0;  // 该连接的计数器清零。
            //TJ_LastTagcount = 0;
            ////StartFlush();                                   // 开始刷新状态
            //if (rb_While.Checked)
            //{
                IsStartRead = true;
                ////CheckConnID();//CheckEnableButton();
            //}
                gb_ReadControl.Visible = false;
        }

        public void StartFlush()
        {
            if (IsFlush == true) return;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
            {
                IsFlush = true;
                long flushCount = 0;
                while (IsFlush)
                {
                    if (flushCount % 2 == 0) FlushState();
                    flushCount++;
                    System.Threading.Thread.Sleep(500);
                    // Application.DoEvents();
                }
            }));
        }

        public void FlushState()
        {
            if (this.lb_ReceiveCount.InvokeRequired)
            {
                this.grdViewRFIDTag.BeginInvoke(new FlushStateT(FlushState), null);
                return;
            }
            Monitor.Enter(grdViewRFIDTag);
            try
            {
                //long nowTagCount = CLReader.DIC_CONNECT[ConnID].ProcessCount;
                //this.lb_ReceiveCount.Text = nowTagCount.ToString();
                //this.tssl_CacheSize.Text = CLReader.DIC_CONNECT[ConnID].receiveBufferManager.DataCount.ToString();
                //// this.lb_tagTotalCount.Text = CLReader.DIC_CONNECT[ConnID].dic_NowTags.Count.ToString();
                //// this.lb_tagTotalCount.Text = dic_Rows.Count.ToString();
                //this.led_Tag_Count.Text = dic_Rows.Count.ToString();
                //Int32 totalMinutes = (Int32)((DateTime.Now - TJ_Run_Start).TotalMilliseconds / 1000);
                //// lb_ReadTime.Text = totalMinutes +" S";
                //led_Time.Text = totalMinutes.ToString();
                //long l_Speed = Math.Abs(nowTagCount - TJ_LastTagcount);
                //// lb_ReadTagSpeed.Text = (l_Speed < 0 ? 0 : l_Speed) + " T/S";
                //led_Speed.Text = l_Speed.ToString();
                //TJ_LastTagcount = CLReader.DIC_CONNECT[ConnID].ProcessCount;

                //float cpuLoad = pc_Processor.NextValue();
                //tssl_CPULoad.Text = cpuLoad.ToString("F2") + "%";           // CPU使用率

            }
            catch { }
            Monitor.Exit(grdViewRFIDTag);
        }

        private void cmbLocationAnt1_Leave(object sender, EventArgs e)
        {
            //if (AntLocationInfo == null)
            //    AntLocationInfo = cmbLocationAnt1.Text;
            //else
            //{
            //    string[] loc = AntLocationInfo.Split(',');
            //    for (int i = 0; i < loc.Length; i++)
            //    {
            //        if (loc[i].ToLower() == cmbLocationAnt1.Text.ToLower())
            //        {
            //            save = false;
            //            break;
            //        }
            //        else
            //            save = true;

            //    }
            //    if (save == true)
            //    {
            //        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt1.Text;

            //        //Save AntLocation
            //        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

            //        //storing the values  
            //        key.SetValue("LocInfo", AntLocationInfo);
            //        key.Close();
            //    }
            //}
        }

        private void chkAnt1_CheckedChanged(object sender, EventArgs e)
        {
            cmbLocationAnt1.Text = string.Empty;
            if (chkAnt1.Checked) 
                cmbLocationAnt1.Enabled = true;
            else 
                cmbLocationAnt1.Enabled = false;
        }

        private void chkAnt2_CheckedChanged(object sender, EventArgs e)
        {
            cmbLocationAnt2.Text = string.Empty;
            if (chkAnt2.Checked)
                cmbLocationAnt2.Enabled = true;
            else
                cmbLocationAnt2.Enabled = false;
        }

        private void chkAnt3_CheckedChanged(object sender, EventArgs e)
        {
            cmbLocationAnt3.Text = string.Empty;
            if (chkAnt3.Checked)
                cmbLocationAnt3.Enabled = true;
            else
                cmbLocationAnt3.Enabled = false;
        }

        private void chkAnt4_CheckedChanged(object sender, EventArgs e)
        {
            cmbLocationAnt4.Text = string.Empty;
            if (chkAnt4.Checked)
                cmbLocationAnt4.Enabled = true;
            else
                cmbLocationAnt4.Enabled = false;
        }

        private void cmbLocationAnt2_Leave(object sender, EventArgs e)
        {
            //if (AntLocationInfo == null)
            //    AntLocationInfo = cmbLocationAnt2.Text;
            //else
            //{
            //    string[] loc = AntLocationInfo.Split(',');
            //    for (int i = 0; i < loc.Length; i++)
            //    {
            //        if (loc[i].ToLower() == cmbLocationAnt2.Text.ToLower())
            //        {
            //            save = false;
            //            break;
            //        }
            //        else
            //            save = true;

            //    }
            //    if (save == true)
            //    {
            //        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt2.Text;

            //        //Save AntLocation
            //        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

            //        //storing the values  
            //        key.SetValue("LocInfo", AntLocationInfo);
            //        key.Close();
            //    }
            //}
        }

        private void cmbLocationAnt3_Leave(object sender, EventArgs e)
        {
            //if (AntLocationInfo == null)
            //    AntLocationInfo = cmbLocationAnt3.Text;
            //else
            //{
            //    string[] loc = AntLocationInfo.Split(',');
            //    for (int i = 0; i < loc.Length; i++)
            //    {
            //        if (loc[i].ToLower() == cmbLocationAnt3.Text.ToLower())
            //        {
            //            save = false;
            //            break;
            //        }
            //        else
            //            save = true;

            //    }
            //    if (save == true)
            //    {
            //        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt3.Text;

            //        //Save AntLocation
            //        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

            //        //storing the values  
            //        key.SetValue("LocInfo", AntLocationInfo);
            //        key.Close();
            //    }
            //}
        }

        private void cmbLocationAnt4_Leave(object sender, EventArgs e)
        {
            //if (AntLocationInfo == null)
            //    AntLocationInfo = cmbLocationAnt4.Text;
            //else
            //{
            //    string[] loc = AntLocationInfo.Split(',');
            //    for (int i = 0; i < loc.Length; i++)
            //    {
            //        if (loc[i].ToLower() == cmbLocationAnt4.Text.ToLower())
            //        {
            //            save = false;
            //            break;
            //        }
            //        else
            //            save = true;

            //    }
            //    if (save == true)
            //    {
            //        AntLocationInfo = AntLocationInfo + ',' + cmbLocationAnt4.Text;

            //        //Save AntLocation
            //        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

            //        //storing the values  
            //        key.SetValue("LocInfo", AntLocationInfo);
            //        key.Close();
            //    }
            //}
        }

    }

    public class Ant1Location
    {
        public string location { get; set; }
        public string value { get; set; }
    }
    public class Ant2Location
    {
        public string location { get; set; }
        public string value { get; set; }
    }

    public class Ant3Location
    {
        public string location { get; set; }
        public string value { get; set; }
    }
    public class Ant4Location
    {
        public string location { get; set; }
        public string value { get; set; }
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

