using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class TransactionHistory : Form
    {
        string tokenValue;
        string roleValue;
        int companyId;
        string startDate;
        string endDate;
        public int assetId;
        int userId;

        public TransactionHistory()
        {
            InitializeComponent();
            GetAssetSystemInfo();
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                grdViewTransactions.Rows.Clear();
                grdViewTransactions.Refresh();

                lblLoadingInformation.Text = "Getting Information. Please wait...";
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
                var response = client.Execute<List<GenerateResult>>(transactionInfo);
                var content = response.Content;

                lblLoadingInformation.Visible = false;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize json response into object
                    JsonDeserializer deserial = new JsonDeserializer();
                    List<GenerateResult> generateResult = deserial.Deserialize<List<GenerateResult>>(response);

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
                            row.Cells["ColRegisterId"].Value = generateResult[i].asset.registerUserId ?? null;
                            row.Cells["ColUpdateId"].Value = generateResult[i].asset.updateUserId ?? null;
                            row.Cells["ColDescription"].Value = generateResult[i].asset.description;
                            row.Cells["ColImgUrl"].Value = generateResult[i].asset.imageUrls;
                            row.Cells["ColRFIDTag"].Value = generateResult[i].asset.tag;
                            row.Cells["ColTakeOutNote"].Value = generateResult[i].asset.takeOutInfo;

                            ValidUntil = generateResult[i].asset.validUntil != DateTime.MinValue ? generateResult[i].asset.validUntil.ToString("g") : "No Expiration";
                            row.Cells["ColValidUntil"].Value = ValidUntil;

                            row.Cells["ColNotes"].Value = generateResult[i].notes;
                            row.Cells["ColPersonImgUrl"].Value = generateResult[i].imageUrl;
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
                        lblLoadingInformation.Text = "Transaction not found.";
                        lblLoadingInformation.Visible = true;
                        //lblLoadingInformation.Refresh();
                    }

                }
                else 
                {
                    MessageBox.Show("Error connecting to server.. please try again later");
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
                    DialogResult result = MessageBox.Show("Transactions successfully exported." + "\n" + "Do you want to open this file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(@sfd.FileName);
                    }
                    else return; 
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
    }

    public class GenerateResult
    {
        //public int? assetId { get; set; }
        public int transactionId { get; set; }
        public string notes { get; set; }
        public string imageUrl { get; set; }
        public DateTime createdAt { get; set; }
        public string readerInfo { get; set; }
        public AssetList asset { get; set; }
    }

    public class AssetList
    {
        public int? assetId { get; set; }
        public int? companyId { get; set; }
        public int? registerUserId { get; set; }
        public int? updateUserId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageUrls { get; set; }
        public string tag { get; set; }
        public string takeOutInfo { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime validUntil { get; set; }
    }
}
