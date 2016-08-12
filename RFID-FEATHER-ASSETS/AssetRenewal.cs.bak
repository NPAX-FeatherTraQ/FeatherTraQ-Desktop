using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class AssetRenewal : Form
    {
        string validUntilValue;
        string tokenvalue;
        int companyId;
        int userId;
        string readerInfo;

        public AssetRenewal()
        {
            InitializeComponent();

            GetAssetSystemInfo();
            AssetValidUntilDateTime();
        }

        private void AssetValidUntilDateTime()
        {
            //For Valid Until Date
            if (!rbtnValidUntil.Checked)
            {
                dtDatePicker.CustomFormat = "'Date'";
                dtDatePicker.Format = DateTimePickerFormat.Custom;

                dtTimePicker.CustomFormat = "'Time'";
                dtTimePicker.Format = DateTimePickerFormat.Custom;
                dtTimePicker.Checked = false;
            }
            else
            {
                //For Valid Until Date
                dtDatePicker.CustomFormat = "MM/dd/yyyy";
                dtDatePicker.Format = DateTimePickerFormat.Custom;
                dtDatePicker.Value = DateTime.Now;
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
                
                DialogResult result = MessageBox.Show("Are you sure you want to cancel the asset renewal?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                if (rbtnValidToday.Checked)
                {
                    validUntilValue = DateTime.UtcNow.ToString("yyyy-MM-dd T") + "17:00";
                }
                else if (rbtnValidUntil.Checked)
                {
                    if (dtTimePicker.Checked) validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd") + dtTimePicker.Value.ToString("THH:mm");
                    else validUntilValue = dtDatePicker.Value.ToString("yyyy-MM-dd T") + "17:00";
                }
                else validUntilValue = null;

                //For Web Service
                AssetExtend assetExtend = new AssetExtend();

                DateTime? dt = null;
                assetExtend.validUntil = validUntilValue != null ? Convert.ToDateTime(validUntilValue) : dt;
                assetExtend.assetId = Verification.AssetIdValue;
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
                    RestResult restResult = deserial.Deserialize<RestResult>(response);

                    if (restResult.result == "OK")
                    {
                        SaveTransaction();

                        MessageBox.Show("Asset successfully renewed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Dispose();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTransaction()
        {
            //Saving to transaction table
            try
            {
                //For Web Service
                Transaction transactDet = new Transaction();

                transactDet.companyId = companyId;//1;
                transactDet.readerInfo = readerInfo;
                //transactDet.readerId = 1;
                //transactDet.notes = txtExplanationNotes.Text.Trim();
                //transactDet.imageUrl = newImgFileNames;//txtCapturedImagePath.Text;//txtImagePath.Text;
                transactDet.assetId = Verification.AssetIdValue;

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
                    RestResult restResult = deserial.Deserialize<RestResult>(response);

                    if (restResult.result != "OK")
                    {
                        MessageBox.Show("Saving transaction..." + "\n" + restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }

    public class AssetExtend
    {
        public int updateUserId { get; set; }
        public int assetId { get; set; }
        public DateTime? validUntil { get; set; }
    }
}
