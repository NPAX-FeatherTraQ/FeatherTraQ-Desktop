using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class AssetRenewal : Form
    {
        string validUntilValue;
        string startDateValue;
        string tokenvalue;
        string language;
        int companyId;
        int userId;
        string readerInfo;
        int assetId;
        string ownerName;
        string description;
        string takeOutNote;
        string userName;
        string classification;
        string baseLocation;

        public AssetRenewal(int srcAssetId, string srcOwnerName, string srcDescription, string srcTakeOutNote, string srcClassification, string srcBaseLocation)
        {
            InitializeComponent();

            getLanguage();
            //languageHandler();
            GetAssetSystemInfo();
            AssetValidUntilDateTime();
            assetId = srcAssetId;
            ownerName = srcOwnerName;
            description = srcDescription;
            takeOutNote = srcTakeOutNote;
            classification = srcClassification;
            baseLocation = srcBaseLocation;
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
                //Console.WriteLine(Properties.mainmenu.btnScan);
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.mainmenu", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");
                groupBox1.Text = rm.GetString("groupBox1");
                rbtnValidToday.Text = rm.GetString("rbtnValidToday");
                rbtnValidUntil.Text = rm.GetString("rbtnValidUntil");
                rbtnValidUnlimited.Text = rm.GetString("rbtnValidUnlimited");
                lblSubmittingInformation.Text = rm.GetString("lblSubmittingInformation");
                btnSubmit.Text = rm.GetString("btnSubmit");
                btnCancel.Text = rm.GetString("btnCancel");
            }
            else
            {
                ChangeLanguage("en");
            }
        }
        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainMenu));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
        private void AssetValidUntilDateTime()
        {
            //For Valid Until Date
            if (!rbtnValidUntil.Checked)
            {
                //dtStartDate.CustomFormat = "'Date'";
                //dtStartDate.Format = DateTimePickerFormat.Custom;
                dtDatePicker.CustomFormat = "'Date'";
                dtDatePicker.Format = DateTimePickerFormat.Custom;

                dtTimePicker.CustomFormat = "'Time'";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
                dtTimePicker.Checked = false;
                dtTimePicker.Enabled = false;
            }
            else
            {
                //dtStartDate.CustomFormat = "MM/dd/yyyy";
                //dtStartDate.Format = DateTimePickerFormat.Custom;
                //dtStartDate.Value = DateTime.Now;
                //For Valid Until Date
                dtDatePicker.CustomFormat = "MM/dd/yyyy";
                dtDatePicker.Format = DateTimePickerFormat.Custom;
                dtDatePicker.Value = DateTime.Now;

                dtTimePicker.CustomFormat = "'Time'";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
                dtTimePicker.Checked = false;
                dtTimePicker.Enabled = true;
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
                    companyId = (int)(key.GetValue("companyId"));
                    userId = (int)(key.GetValue("UserId"));
                    readerInfo = (string)(key.GetValue("readerInfo"));
                    userName = (string)(key.GetValue("UserName")).ToString();
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
                if (language == "English")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel the ID renewal?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
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
                    DialogResult result = MessageBox.Show("アセットの更新を取り消すにしてもよろしいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
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
                //For Validity Expiration
                if (dtStartTimePicker.Checked) startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd") + dtStartTimePicker.Value.ToString("THH:mm");
                else startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "17:00";

                if (Convert.ToDateTime(startDateValue) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd THH:mm")))
                {
                    MessageBox.Show("Start Date must not less than to current Date and Time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rbtnValidToday.Checked)
                {
                    startDateValue = DateTime.UtcNow.ToString("yyyy-MM-dd"); //+ "00:01";
                    validUntilValue = DateTime.UtcNow.ToString("yyyy-MM-dd T") + "17:00";

                    if (Convert.ToDateTime(validUntilValue) < Convert.ToDateTime(DateTime.Now.ToString("g")))
                    {
                        MessageBox.Show("ID Validity Period is already expired.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rbtnValidUntil.Checked)
                {
                    //startDateValue = dtStartDate.Value.ToString("yyyy-MM-dd"); //+ "00:01";

                    if (dtTimePicker.Checked) validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd") + dtTimePicker.Value.ToString("THH:mm");
                    else validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd T") + "17:00";

                    if (Convert.ToDateTime(startDateValue) > Convert.ToDateTime(validUntilValue))
                    {
                        MessageBox.Show("Start Date must not greater than Until Date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Convert.ToDateTime(validUntilValue) < Convert.ToDateTime(DateTime.Now.ToString("g")))
                    {
                        MessageBox.Show("Until Date must not less than to current Date and Time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    //startDateValue = null;
                    validUntilValue = null;
                }

                //For Web Service
                GlobalClass.GetSetClass assetExtend = new GlobalClass.GetSetClass();

                DateTime? dt = null;
                assetExtend.startDate = startDateValue != null ? Convert.ToDateTime(startDateValue) : dt;
                assetExtend.validUntil = validUntilValue != null ? Convert.ToDateTime(validUntilValue) : dt;
                //if (AssetRegistration.assetId != 0)
                //    assetExtend.assetId = AssetRegistration.assetId;
                //else
                    assetExtend.assetId = assetId;//Verification.AssetIdValue;
                assetExtend.updateUserId = userId;

                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://feather-assets.herokuapp.com/");
                RestRequest extend = new RestRequest("/api/asset/extend", Method.POST);

                var authToken = tokenvalue;
                extend.AddHeader("X-Auth-Token", authToken);
                extend.AddHeader("Content-Type", "application/json; charset=utf-8");
                extend.RequestFormat = DataFormat.Json;
                extend.AddBody(assetExtend);

                lblSubmittingInformation.Visible = true;
                this.Refresh();


                IRestResponse response = client.Execute(extend);
                lblSubmittingInformation.Visible = false;

                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)//if (response.IsSuccessStatusCode)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                    if (restResult.result == "OK")
                    {
                        SaveTransaction(assetExtend.startDate, assetExtend.validUntil);
                        if (language.ToLower() == "japanese") MessageBox.Show("アセットが正常に更新されました。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("ID successfully renewed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(restResult.result + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        
                }
                else
                {
                    MessageBox.Show("Error Code " +
                    response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTransaction(DateTime? startDate, DateTime? validUntil)
        {
            //Saving to transaction table
            try
            {
                //For Web Service
                GlobalClass.GetSetClass transactDet = new GlobalClass.GetSetClass();

                //transactDet.companyId = companyId;//1;
                //transactDet.readerInfo = readerInfo;
                //transactDet.type = "RENEW-ID";
                ////transactDet.readerId = 1;
                ////transactDet.notes = txtExplanationNotes.Text.Trim();
                ////transactDet.imageUrl = newImgFileNames;//txtCapturedImagePath.Text;//txtImagePath.Text;
                ////transactDet.assetId = Verification.AssetIdValue;
                ////if (AssetRegistration.assetId != 0)
                ////    transactDet.assetId = AssetRegistration.assetId;
                ////else
                //    transactDet.assetId = assetId;//Verification.AssetIdValue;

                transactDet.companyId = companyId;//1;
                transactDet.validityPeriod = validUntil == null ? "Start " + startDate.Value.ToString("g") + " - No End Date" : "Start " + startDate.Value.ToString("g") + " Until " + validUntil.Value.ToString("g");
                transactDet.ownerName = ownerName;
                //transactDet.position = position;
                //transactDet.email = email;
                //transactDet.userType = userType;
                transactDet.description = description;
                transactDet.takeOutNote = takeOutNote;
                //transactDet.ownerImageUrl = ownerImageUrl;
                //transactDet.assetImageUrl = newImgFileNames;
                transactDet.updatedBy = userName;
                transactDet.readerInfo = readerInfo;
                //transactDet.notes = notes;
                transactDet.type = "RENEW-ID";
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

                //lblSubmittingInformation.Visible = true;
                //this.Refresh();

                IRestResponse response = client.Execute(transact);
                lblSubmittingInformation.Visible = false;

                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JsonDeserializer deserial = new JsonDeserializer();
                    GlobalClass.GetSetClass restResult = deserial.Deserialize<GlobalClass.GetSetClass>(response);

                    if (restResult.result != "OK")
                    {
                        if (language.ToLower() == "japanese") MessageBox.Show("取引が保存されました..." + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("transaction saved..." + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Saving transaction..." + "\n" + "Error Code " +
                    response.StatusCode /*+ " : Message - " + response.ErrorMessage*/);
                    return;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void rbtnValidUntil_CheckedChanged(object sender, EventArgs e)
        {
            AssetValidUntilDateTime();
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

        private void dtStartTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AssetValidUntilTime();
        }
    }

    //public class AssetExtend
    //{
    //    public int updateUserId { get; set; }
    //    public int assetId { get; set; }
    //    public DateTime? validUntil { get; set; }
    //}
}
