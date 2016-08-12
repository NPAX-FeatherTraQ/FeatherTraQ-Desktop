using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Data.SqlClient;
using RestSharp;
using System.Net;
using RestSharp.Deserializers;
using Microsoft.Win32;
using System.Net.NetworkInformation;

namespace RFID_FEATHER_ASSETS
{

    
    public partial class LoginActivity : Form
    {
        //string connectionString = "server=128.199.83.107;port=3306;uid=root;pwd=aws123;database=feather_assets;";
        string readerInfo;

        public LoginActivity()//string portnamesource)
        {
            InitializeComponent();
            //cmbComPort.Text = portnamesource;
            //GetAssetSystemInfo();
            GetReaderInfo();
        }

        private void GetReaderInfo()
        {
            try
            { 
                string LocalIp = string.Empty;
                string Domain = !string.IsNullOrEmpty(System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName) ? System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName : "x";
                string Host = System.Net.Dns.GetHostName();

                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (System.Net.IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            LocalIp = ip.ToString();
                            break;
                        }
                    }
                    //string IpWidHost = String.Format("[Domain-{0} : Host-{1} : IP-{2}]", Domain, Host, LocalIp);
                }
                else return;
           
                var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                               where nic.OperationalStatus == OperationalStatus.Up
                               select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
                //var macAddrs = NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
                readerInfo = /*"Domain:" + Domain +*/ "Host:" + Host + " IP Address:" + LocalIp + " Mac Address:" + macAddr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    cboCompanyList.Text = (string)(key.GetValue("companyId"));
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ClearFields()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ////Validation for Company 
                //if (string.IsNullOrEmpty (cboCompanyList.Text.Trim()))
                //{
                //    lblCompanyRequired.Visible = true;
                //    cboCompanyList.Focus();
                //    return;
                //} else lblCompanyRequired.Visible = false;

                //Validation for User Name and Password
                if (txtUserName.TextLength == 0 || txtPassword.TextLength == 0)
                {
                    lblUserPasswordRequired.Visible = true;
                    txtUserName.Focus();
                    return;
                }
                else
                {
                    lblUserPasswordRequired.Visible = false;

                    //picLoading.Visible = true;
                    lblSigningIn.Visible = true;//btnLogin.Text = "Logging in...";
                    this.Refresh();

                    LoginInfo loginInfo = new LoginInfo();
                    //store information to object
                    loginInfo.email = txtUserName.Text;
                    loginInfo.password = txtPassword.Text;

                    //initialize web service
                    //RestClient(request);
                    RestClient client = new RestClient("http://52.163.93.95:8080/FeatherAssets/");
                    RestRequest login = new RestRequest("/login", Method.POST);


                    //pass information to web service
                    login.AddHeader("Content-Type", "application/json; charset=utf-8");
                    login.RequestFormat = DataFormat.Json;
                    login.AddBody(loginInfo);

                    //retrieve response
                    IRestResponse response = client.Execute(login);
                    lblSigningIn.Visible = false; 

                    var content = response.Content;

                    //check for errors
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        //deserialize JSON -> Object
                        LoginResult loginResult = new LoginResult();

                        JsonDeserializer deserial = new JsonDeserializer();
                        loginResult = deserial.Deserialize<LoginResult>(response);

                        SaveAssetSystemInfo(loginResult.authenticationToken, loginResult.roles, loginResult.companyId, loginResult.userId, txtUserName.Text.Trim(), readerInfo);

                        //check authorities                       
                        if (loginResult.roles == "ROLE_ADMIN")
                        {
                            this.Hide();
                            MainMenu MenuForm = new MainMenu(loginResult.authenticationToken, /*cmbComPort.Text,*/ loginResult.roles);
                            MenuForm.ShowDialog();
                        }
                        else if (loginResult.roles == "ROLE_GUARD")
                        {
                            //TODO RFID SCAN CODE MISSING
                            this.Hide();
                            Verification verification = new Verification();//loginResult.authenticationToken, loginResult.roles);
                            verification.Show();
                        }
                        else if (loginResult.roles == "ROLE_USER")
                        {
                            this.Hide();
                            Assets asset = new Assets(/*loginResult.authenticationToken, loginResult.roles*/);
                            asset.Show();
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
                        MessageBox.Show("Error: " + numericStatusCode + response.ErrorMessage);
                    }

                    //picLoading.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void SaveAssetSystemInfo(string autoken, string roles, int companyId, int userId, string loginid, string readerInfo)
        {
            try
            {
                //accessing the CurrentUser root element  
                //and adding "AssetSystemInfo" subkey to the "SOFTWARE" subkey  
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AssetSystemInfo");

                //storing the values  
                if (!string.IsNullOrEmpty(autoken)) key.SetValue("authenticationToken", autoken);
                if (!string.IsNullOrEmpty(roles)) key.SetValue("roles", roles);
                key.SetValue("companyId", companyId);
                key.SetValue("UserId", userId);
                if (!string.IsNullOrEmpty(loginid)) key.SetValue("UserName", loginid);
                if (!string.IsNullOrEmpty(readerInfo)) key.SetValue("readerInfo", readerInfo);
                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                {
                    //btnLogin_Click(sender, e);
                    btnLogin.PerformClick();
                }
          }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cboCompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SaveAssetSystemInfo(string.Empty, string.Empty, cboCompanyList.Text.Trim(), string.Empty, string.Empty);
        }

        private void LoginActivity_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

     }

    //Getters and Setters

    public class LoginInfo
    {
        public string email {get; set;}
        public string password {get; set;}
    }

    public class LoginResult
    {
        public int companyId {get; set;}
        public string companyName {get; set;}
        public int userId {get; set;}
        public string firstName {get; set;}
        public string lastName{get; set;}
        public string authenticationToken {get; set;}
        public string roles {get; set;}
    }
}
