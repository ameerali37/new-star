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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter username and password");
                }
                else
                {


                    string uname = textBox1.Text;
                    string pswd = textBox2.Text;
                    SqlDataAdapter da = new SqlDataAdapter("select * from login", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    string ss = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                    string ss1 = ds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                    if (ss.Equals(uname) && ss1.Equals(pswd))
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter username and password");
                }
                else
                {


                    string uname = textBox1.Text;
                    string pswd = textBox2.Text;
                    SqlDataAdapter da = new SqlDataAdapter("select * from login", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    string ss = ds.Tables[0].Rows[0].ItemArray.GetValue(0).ToString();
                    string ss1 = ds.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                    if (ss.Equals(uname) && ss1.Equals(pswd))
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect");
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
