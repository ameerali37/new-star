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
    public partial class AddDealer : Form
    {
        public AddDealer()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dname1 = textBox1.Text;
                string address1 = textBox2.Text;
                string contno1 = textBox3.Text;
                SqlDataAdapter da2 = new SqlDataAdapter("select * from dealer where dname='" + dname1 + "'", cn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Already Added");
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into dealer values(@dname,@address,@contno)", cn);
                    cmd1.Parameters.AddWithValue("@dname", dname1);
                    cmd1.Parameters.AddWithValue("@address", address1);
                    cmd1.Parameters.AddWithValue("@contno", contno1);

                    cn.Open();
                    int n1 = cmd1.ExecuteNonQuery();
                    cn.Close();
                    if (n1 > 0)
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
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        public void clear()
        {

            textBox2.Text = "";
            textBox3.Text = "";

        }
        private void AddDealer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Dealer Name");
                }
                else
                {
                    string dname1 = textBox1.Text;
                    string address1 = textBox2.Text;
                    string contno1 = textBox3.Text;
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from dealer where dname='" + dname1 + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Already Added");
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("Insert into dealer values(@dname,@address,@contno)", cn);
                        cmd1.Parameters.AddWithValue("@dname", dname1);
                        cmd1.Parameters.AddWithValue("@address", address1);
                        cmd1.Parameters.AddWithValue("@contno", contno1);

                        cn.Open();
                        int n1 = cmd1.ExecuteNonQuery();
                        cn.Close();
                        if (n1 > 0)
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
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
    }
}
