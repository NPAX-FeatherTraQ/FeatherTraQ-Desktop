using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_FEATHER_ASSETS
{
    public partial class Assets : Form
    {
        string tokenValue;
        string roleValue;
        List<AssetInformation> assetInformation = new List<AssetInformation>(); 

        public Assets(/*string tokenValueSource, *//*string roleSource*/)
        {
            InitializeComponent();

            //comboAsset.SelectedIndex = 1;
            getKey();
            
            
            //roleValue = roleSource;
            InitializeAsset();

            if (roleValue == "ROLE_ADMIN" || roleValue == "ROLE_GUARD")
            {
                btnBack2.Text = "Back";
            }
            else if (roleValue == "ROLE_USER")
            {
                btnBack2.Text = "Log-out";
            }
            
        }

        private void getKey()
        {
             try
            {
                //opening the subkey  
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SavedUserInfo");

                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                    tokenValue = (string)(key.GetValue("authenticationToken"));
                    roleValue = (string)(key.GetValue("roles"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeAsset()
        {
            try
            {
                //var company = 1;
                var id = 26;

                //initialize Rest Client
                RestClient client = new RestClient(/*"http://feather-assets.herokuapp.com/");*/"http://52.163.93.95:8080/FeatherAssets/");
                RestRequest assetInfo = new RestRequest("/api/user/"+ id +"/assets/list/", Method.GET);

                var authToken = tokenValue;

                //add needed headers
                assetInfo.RequestFormat = DataFormat.Json;
                assetInfo.AddHeader("Content-Type", "application/json; charset=utf-8");
                assetInfo.AddHeader("X-Auth-Token", authToken);

                //execute request
                var response = client.Execute<List<AssetInformation>>(assetInfo);
                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deserialize json response into object
                    JsonDeserializer deserial = new JsonDeserializer();
                    assetInformation = deserial.Deserialize<List<AssetInformation>>(response);
                    
                    //add combobox information
                    if (assetInformation.Count == 0)
                    {                        
                        MessageBox.Show("Not yet registered an asset... Please visit your administrator to register your asset", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Restart();
                    }
                    else
                    {
                        this.comboAsset.DataSource = assetInformation;
                        this.comboAsset.ValueMember = "assetId";
                        this.comboAsset.DisplayMember = "name";
                    }
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

        private void Assets_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Restart();
            Environment.Exit(0);
        }

        private void comboAsset_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int aId;
            int i = comboAsset.SelectedIndex;
            bool parseOK = Int32.TryParse(comboAsset.SelectedValue.ToString(), out aId);
           
            //display information from selected combobox index
            if (aId == assetInformation[i].assetId)
            {
                //display necessary text information
                assetName.Text = assetInformation[i].name;
                descriptionTxt1.Text = assetInformation[i].description;
                tagTxt.Text = assetInformation[i].tag;
                informationTxt.Text = assetInformation[i].takeOutInfo;
                
                //display image
                string Urls = assetInformation[i].imageUrls;
                string[] readUrls = Urls.Split(',');
                foreach (string getUrls in readUrls)
                {
                    if (Urls == "")
                    {
                        assetImage.Image = null;
                        //MessageBox.Show("No picture", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (readUrls.Length > 1 && File.Exists(readUrls[1])) assetImage.Image = Image.FromFile(readUrls[1]);
                        else assetImage.Image = null;
                        if (readUrls.Length > 2 && File.Exists(readUrls[2])) assetImage1.Image = Image.FromFile(readUrls[2]);
                        else assetImage1.Image = null;
                        if (readUrls.Length > 3 && File.Exists(readUrls[3])) assetImage2.Image = Image.FromFile(readUrls[3]);
                        else assetImage2.Image = null;
                        if (readUrls.Length > 4 && File.Exists(readUrls[4])) assetImage3.Image = Image.FromFile(readUrls[4]);
                        else assetImage3.Image = null;
                        if (readUrls.Length > 5 && File.Exists(readUrls[5])) assetImage4.Image = Image.FromFile(readUrls[5]);
                        else assetImage4.Image = null;
                    }
                }

                //tag type
                if (assetInformation[i].tagType == 1)
                {
                    tagTypeTxt.Text = "RFID Tag";
                }
                else if (assetInformation[i].tagType == 2)
                {
                    tagTypeTxt.Text = "Qr Code";
                }
                else
                {
                    tagTypeTxt.Text = "Bar Code";
                }
            }          
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (roleValue == "ROLE_ADMIN" || roleValue == "ROLE_GUARD")
            {
                this.Hide();
                MainMenu menuForm = new MainMenu(tokenValue, roleValue);
                menuForm.Show();
                //Application.Restart();
            }
            else if (roleValue == "ROLE_USER")
            {
                Application.Restart();
                //Environment.Exit(0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void assetName_Click(object sender, EventArgs e)
        {

        }
    }

    public class AssetInformation
    {
        public int assetId { get; set; }
        public int companyId { get; set; }
        public int ownerId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageUrls { get; set; }
        public string tag { get; set; }
        public int tagType { get; set; }
        public bool takeOutAllowed { get; set; }
        public string takeOutInfo { get; set; }
    }
}
