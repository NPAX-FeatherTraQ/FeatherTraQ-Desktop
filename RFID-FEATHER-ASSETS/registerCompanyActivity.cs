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
    public partial class registerCompanyActivity : Form
    {
        public registerCompanyActivity()
        {
            InitializeComponent();
        }

        

        private void registerCompanyActivity_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Company company = new Company();

            company.companyName = txtCompanyName.Text;
            company.address = txtAddress.Text;
            company.website = txtWebsite.Text;

            RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");//("http://feather-assets.herokuapp.com/");
            RestRequest regCompany = new RestRequest("/company", Method.POST);

            regCompany.AddHeader("Content-Type", "application/json; charset=utf-8");
            regCompany.RequestFormat = DataFormat.Json;
            regCompany.AddBody(company);

            IRestResponse response = client.Execute(regCompany);
            var content = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                RestResult restResult = deserial.Deserialize<RestResult>(response);

                if (restResult.result == "OK")
                {
                    MessageBox.Show("Company Saved", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(restResult.result + " " + restResult.message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Failed to connect to server.. please try again later..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Company
    {
        public string companyName { get; set; }
        public string address { get; set; }
        public string website { get; set; }
    }
}
