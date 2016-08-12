using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
    public partial class TransactionHistory : Form
    {
        string tokenValue;
        string roleValue;
        string language;
        int companyId;
        string startDate;
        string endDate;
        public int assetId;
        int userId;
        /*int ownerId;
        int updateId;
        int registerUserId;*/
        string name;
        
        public TransactionHistory()
        {
            InitializeComponent();
            getLanguage();
            languageHandler();
            GetAssetSystemInfo();
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
                ResourceManager rm = new ResourceManager("RFID_FEATHER_ASSETS.Languages.TransactionHistory", Assembly.GetExecutingAssembly());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ja-JP");

                this.Text = rm.GetString("title");
                grpSearchCriteria.Text = rm.GetString("grpSearchCriteria");
                grpDetails.Text = rm.GetString("grpDetails");
                lblDateFrom.Text = rm.GetString("lblDateFrom");
                lblDateTo.Text = rm.GetString("lblDateTo");
                btnGenerate.Text = rm.GetString("btnGenerate");
                btnCancel.Text = rm.GetString("btnCancel");
                lblLoadingInformation.Text = rm.GetString("lblLoadingInformation");
                ColTransId.HeaderText = rm.GetString("ColTransId");
                ColRegisterId.HeaderText = rm.GetString("ColRegisterId");
                ColCompanyId.HeaderText = rm.GetString("ColCompanyId");
                ColAssetId.HeaderText = rm.GetString("ColAssetId");
                ColUpdatedAt.HeaderText = rm.GetString("ColUpdatedAt");
                ColUpdateId.HeaderText = rm.GetString("ColUpdateId");
                ColDescription.HeaderText = rm.GetString("ColDescription");
                ColImgUrl.HeaderText = rm.GetString("ColImgUrl");
                ColRFIDTag.HeaderText = rm.GetString("ColRFIDTag");
                ColTakeOutNote.HeaderText = rm.GetString("ColTakeOutNote");
                ColValidUntil.HeaderText = rm.GetString("ColValidUntil");
                ColNotes.HeaderText = rm.GetString("ColNotes");
                ColPersonImgUrl.HeaderText = rm.GetString("ColPersonImgUrl");
                ColCreatedAt.HeaderText = rm.GetString("ColCreatedAt");
                btnExport.Text = rm.GetString("btnExport");
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
                    tokenValue = (string)(key.GetValue("authenticationToken"));
                    roleValue = (string)(key.GetValue("roles"));
                    companyId = (int)(key.GetValue("companyId"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOwnerInfo(int id)
        {
            try
            {
                //var company = 1;             

                //initialize Rest Client
                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                RestRequest ownerInfo = new RestRequest("/api/user/" + id , Method.GET);

                var authToken = tokenValue;

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

                    name = info.lastName + " " + info.lastName;
                    
                }
                else
                {
                    MessageBox.Show("Unable to reach server.. please try again later", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Application.Restart();
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                grdViewTransactions.Rows.Clear();
                grdViewTransactions.Refresh();

                if (language == "English") lblLoadingInformation.Text = "Getting Information. Please wait...";
                else lblLoadingInformation.Text = "情報の取得. お待ちください...";
                lblLoadingInformation.Visible = true;
                lblLoadingInformation.Refresh();

                startDate = dtDateFromPicker.Value.ToString("yyyy-MM-ddT00:01");
                endDate = dtDateToPicker.Value.ToString("yyyy-MM-ddT23:59");
                if (!string.IsNullOrEmpty(txtAssetID.Text.Trim())) assetId = int.Parse(txtAssetID.Text.Trim());
                if (!string.IsNullOrEmpty(txtUserID.Text.Trim())) userId = int.Parse(txtUserID.Text.Trim());

                //initialize Rest Client
                RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                RestRequest transactionInfo = new RestRequest("/api/transaction/search?startDate=" + startDate + "&endDate=" + endDate /*+ "&assetId=" + assetId*/, Method.GET);

                var authToken = tokenValue;

                //add needed headers
                transactionInfo.RequestFormat = DataFormat.Json;
                transactionInfo.AddHeader("Content-Type", "application/json; charset=utf-8");
                transactionInfo.AddHeader("X-Auth-Token", authToken);

                //execute request
                var response = client.Execute<List<GlobalClass.GetSetClass>>(transactionInfo);
                var content = response.Content;

                lblLoadingInformation.Visible = false;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize json response into object
                    JsonDeserializer deserial = new JsonDeserializer();
                    List<GlobalClass.GetSetClass> generateResult = deserial.Deserialize<List<GlobalClass.GetSetClass>>(response);

                    string ValidUntil;

                    if (generateResult.Count != 0)
                    {
                        grdViewTransactions.ColumnHeadersVisible = true;

                        for (int i = 0; i < generateResult.Count; i++)
                        {                         
                            int idx = grdViewTransactions.Rows.Add();
                            DataGridViewRow row = grdViewTransactions.Rows[idx];

                            row.Cells["ColTransId"].Value = generateResult[i].transactionId;
                            row.Cells["ColAssetId"].Value = generateResult[i].asset.assetId ?? null;
                            row.Cells["ColCompanyId"].Value = generateResult[i].asset.companyId ?? null;
                            getOwnerInfo(generateResult[i].asset.registerUserId);
                            row.Cells["ColRegisterId"].Value = name;
                            getOwnerInfo(generateResult[i].asset.updateUserId);
                            row.Cells["ColUpdateId"].Value = name;
                            row.Cells["ColDescription"].Value = generateResult[i].asset.description;
                            row.Cells["ColImgUrl"].Value = generateResult[i].asset.imageUrls;
                            row.Cells["ColRFIDTag"].Value = generateResult[i].asset.tag;
                            row.Cells["ColTakeOutNote"].Value = generateResult[i].asset.takeOutInfo;

                            ValidUntil = generateResult[i].asset.validUntil == null ? "No Expiration" : generateResult[i].asset.validUntil.ToString(); //!= DateTime.MinValue ? generateResult[i].asset.validUntil.ToString("g") : "No Expiration";
                            row.Cells["ColValidUntil"].Value = ValidUntil;

                            row.Cells["ColNotes"].Value = generateResult[i].notes;
                            row.Cells["ColPersonImgUrl"].Value = generateResult[i].imageUrls;
                            row.Cells["ColCreatedAt"].Value = generateResult[i].createdAt.ToString("g");
                            row.Cells["ColUpdatedAt"].Value = generateResult[i].asset.updatedAt.ToString("s");
                            row.Cells["ColReaderInfo"].Value = generateResult[i].readerInfo;

                            //grdViewTransactions.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                            //return;
                        }
                    }
                    else
                    {
                        grdViewTransactions.ColumnHeadersVisible = false;
                        if (language == "English") lblLoadingInformation.Text = "Transaction not found.";
                        else lblLoadingInformation.Text = "トランザクションが見つかりません.";
                        lblLoadingInformation.Visible = true;
                        //lblLoadingInformation.Refresh();
                    }

                }
                else 
                {
                    if (language == "English") MessageBox.Show("Error connecting to server.. Please try again later");
                    else MessageBox.Show("サーバーへの接続エラー.. 後でもう一度試してください");
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CallMainMenu();
        }

        private void TransactionHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            CallMainMenu();
        }

        private void CallMainMenu()
        {
            this.Hide();
            MainMenu MenuForm = new MainMenu(tokenValue, roleValue);
            MenuForm.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            { 
                // Don't save if no data is returned
                if (grdViewTransactions.Rows.Count == 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();
                // Column headers
                string columnsHeader = "";

                for (int i = 0; i < grdViewTransactions.Columns.Count; i++)
                {
                     if (grdViewTransactions.Columns[i].Visible)
                     {
                        columnsHeader += grdViewTransactions.Columns[i].HeaderText + ",";
                     }
                }
                sb.Append(columnsHeader + Environment.NewLine);

                // Go through each cell in the datagridview 
                foreach (DataGridViewRow dgvRow in grdViewTransactions.Rows)
                {
                    // Make sure it's not an empty row.
                    if (!dgvRow.IsNewRow)
                    {
                        for (int c = 0; c < dgvRow.Cells.Count; c++)
                        {
                            // Append the cells data followed by a comma to delimit.
                            if (grdViewTransactions.Columns[c].Visible)
                            {
                                sb.Append(dgvRow.Cells[c].Value + ",");
                            }
                        }
                        // Add a new line in the text file.
                        sb.Append(Environment.NewLine);
                    }
                }

                // Load up the save file dialog with the default option as saving as a .csv file.
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "CSV files (*.csv)|*.csv";
                @sfd.FileName = "TransactionHistory_" + DateTime.Now.ToString("yyyyMMdd_hhmmss");

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // If they've selected a save location...
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                    {
                        // Write the stringbuilder text to the the file.
                        sw.WriteLine(sb.ToString());
                    }

                    // Confirm to the user it has been completed.
                    if (language == "English")
                    {
                        DialogResult result = MessageBox.Show("Transactions successfully exported." + "\n" + "Do you want to open this file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            Process.Start(@sfd.FileName);
                        }
                        else return;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("トランザクションは正常にエクスポート." + "\n" + "このファイルを開くようにしたいですか？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            Process.Start(@sfd.FileName);
                        }
                        else return;
                    }
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
    }

    //public class GenerateResult
    //{
    //    //public int? assetId { get; set; }
    //    public int transactionId { get; set; }
    //    public string notes { get; set; }
    //    public string imageUrl { get; set; }
    //    public DateTime createdAt { get; set; }
    //    public string readerInfo { get; set; }
    //    public AssetList asset { get; set; }
    //}

    //public class AssetList
    //{
    //    public int? assetId { get; set; }
    //    public int? companyId { get; set; }
    //    public int registerUserId { get; set; }
    //    public int updateUserId { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public string imageUrls { get; set; }
    //    public string tag { get; set; }
    //    public string takeOutInfo { get; set; }
    //    public DateTime updatedAt { get; set; }
    //    public DateTime validUntil { get; set; }
    //}
    
    //public class OwnerInfo
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
