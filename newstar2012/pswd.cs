using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace newstar2012
{
    public partial class pswd : Form
    {
        public pswd()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter Current Password, New Username and New Password");
                }
                else
                {
                    string cpswd = textBox3.Text;
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from login where pwd='" + cpswd + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        string a1 = textBox1.Text;
                        string a2 = textBox2.Text;
                        SqlCommand cmp = new SqlCommand("update login set uname='" + a1 + "',pwd='" + a2 + "'", cn);

                        cn.Open();
                        int status1 = cmp.ExecuteNonQuery();
                        cn.Close();

                        if (status1 > 0)
                        {
                            MessageBox.Show("Username and Password Changed");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current Password Entered is Wrong");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pswd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter Current Password, New Username and New Password");
                }
                else
                {
                    string cpswd = textBox3.Text;
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from login where pwd='" + cpswd + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        string a1 = textBox1.Text;
                        string a2 = textBox2.Text;
                        SqlCommand cmp = new SqlCommand("update login set uname='" + a1 + "',pwd='" + a2 + "'", cn);

                        cn.Open();
                        int status1 = cmp.ExecuteNonQuery();
                        cn.Close();

                        if (status1 > 0)
                        {
                            MessageBox.Show("Username and Password Changed");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current Password Entered is Wrong");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
