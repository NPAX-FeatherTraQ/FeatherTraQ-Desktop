using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RFID_FEATHER_ASSETS
{
    public partial class RegisterAsset : Form
    {
        string str = "Data Source=DESKTOPI5-PC\\MSSQL2014;Initial Catalog=RFID;User ID=sa;Password=systemadmin";
        string ownerid;

        public RegisterAsset()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu MenuForm = new MainMenu();
            MenuForm.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRFIDTag.Text.Length == 0 || comboOwner.Text.Length == 0 || txtAssetName.Text.Length == 0 || txtDescription.Text.Length == 0 || txtTakeOutNote.Text.Length == 0)
                {
                    MessageBox.Show("Complete information is required.",this.Text);
                    ClearFields();
                    return; 
                }
                if (!CheckDuplicateRFID())
                {
                    MessageBox.Show("RFID already assigned.",this.Text);
                    txtRFIDTag.Focus();
                    return;
                }

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Asset(rfid_tag,owner_id,name,description,take_out_allowed,take_out_info,created_at,updated_at) values (@rfid_tag,@owner_id,@name,@description,@take_out_allowed,@take_out_info,@created_at,@updated_at)", con);
                cmd.Parameters.AddWithValue("@rfid_tag", txtRFIDTag.Text);
                cmd.Parameters.AddWithValue("@owner_id", ownerid);
                cmd.Parameters.AddWithValue("@name", txtAssetName.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                if (radbtnYes.Checked)
                {
                    cmd.Parameters.AddWithValue("@take_out_allowed", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@take_out_allowed", 0);
                }
                cmd.Parameters.AddWithValue("@take_out_info", txtTakeOutNote.Text);
                //cmd.Parameters.AddWithValue("@Section", combosec.SelectedItem.ToString());  
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd.Parameters.AddWithValue("@updated_at", DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Asset successfully saved.",this.Text);

                ClearFields();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ClearFields()
        {
            txtRFIDTag.Text = string.Empty;
            comboOwner.Items.Clear();
            txtAssetName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            radbtnNo.Checked = true;
            txtTakeOutNote.Text = string.Empty;
            txtRFIDTag.Focus();
        }

        private bool CheckDuplicateRFID()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from asset where rfid_tag='" + txtRFIDTag.Text.Trim() + "'", con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                return false;
            }
            else
            {
                rd.Close();
                return true;
            }
        }

        private void RegisterAsset_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu MenuForm = new MainMenu();
            MenuForm.ShowDialog();
        }

        private void comboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from User_Master where first_name ='" + comboOwner.Text.Trim() + "'", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                ownerid = rd["user_id"].ToString();
            }
            rd.Close();

        }

        private void comboOwner_DropDown(object sender, EventArgs e)
        {
            comboOwner.Items.Clear();

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from User_Master", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                comboOwner.Items.Add(rd["first_name"].ToString());
            }
            rd.Close(); 
        }

        private void btnGetEPC_Click(object sender, EventArgs e)
        {

        }

    }
}
