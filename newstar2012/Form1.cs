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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter item name, price");
                }
                else
                {
                    string iname1 = textBox2.Text;
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from item where iname='" + iname1 + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Already Added");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into item values(@iname,@rate)", cn);

                        cmd.Parameters.AddWithValue("@iname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@rate", textBox3.Text);


                        cn.Open();
                        int status = cmd.ExecuteNonQuery();
                        cn.Close();
                        if (status > 0)
                        {
                            MessageBox.Show("success");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void clear()
        {

            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter item name, price");
                }
                else
                {
                    string iname1 = textBox2.Text;
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from item where iname='" + iname1 + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Already Added");
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into item values(@iname,@rate)", cn);

                        cmd.Parameters.AddWithValue("@iname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@rate", textBox3.Text);


                        cn.Open();
                        int status = cmd.ExecuteNonQuery();
                        cn.Close();
                        if (status > 0)
                        {
                            MessageBox.Show("success");
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
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
