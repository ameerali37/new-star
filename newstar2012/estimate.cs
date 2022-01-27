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
    public partial class estimate : Form
    {
        public estimate()
        {
            InitializeComponent();
        }
        int k = 0;
        int p = 1;
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n7 = 0, n8 = 0;
                string dname = comboBox2.SelectedItem.ToString();
                string bno = textBox6.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string slno = textBox1.Text;
                int slno1 = int.Parse(slno);
                string iname = comboBox1.SelectedItem.ToString();
                string qty = textBox2.Text;
                int qty1 = int.Parse(qty);
                string rate = textBox3.Text;
                int rate1 = int.Parse(rate);
                string discount = textBox4.Text;
                int discount1 = int.Parse(discount);
                string total = textBox5.Text;
                int total1 = int.Parse(total);
                SqlCommand cmd = new SqlCommand("Insert into estimate values(@dname,@bno,@date,@sno,@iname,@qty,@rate,@discount,@total,@nettotal)", cn);
                cmd.Parameters.AddWithValue("@dname", dname);
                cmd.Parameters.AddWithValue("@bno", bno);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@sno", slno1);
                cmd.Parameters.AddWithValue("@iname", iname);
                cmd.Parameters.AddWithValue("@qty", qty1);
                cmd.Parameters.AddWithValue("@rate", rate1);
                cmd.Parameters.AddWithValue("@discount", discount1);
                cmd.Parameters.AddWithValue("@total", total1);
                cmd.Parameters.AddWithValue("@nettotal", 0);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                SqlDataAdapter da5 = new SqlDataAdapter("select * from availability where iname='" + iname + "'", cn);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                if (ds5.Tables[0].Rows.Count > 0)
                {
                    string qty5 = ds5.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                    int qty6 = int.Parse(qty5);
                    int qty7 = qty6 + qty1;
                    SqlCommand cmd7 = new SqlCommand("update availability set qty='" + qty7 + "' where iname='" + iname + "'", cn);
                    cn.Open();
                    n7 = cmd7.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    SqlCommand cmd8 = new SqlCommand("Insert into availability values(@iname,@qty)", cn);
                    cmd8.Parameters.AddWithValue("@iname", iname);
                    cmd8.Parameters.AddWithValue("@qty", qty1);
                    cn.Open();
                    n8 = cmd8.ExecuteNonQuery();
                    cn.Close();
                }
                if (((n > 0) && (n7 > 0)) || ((n > 0) && (n8 > 0)))
                {
                    MessageBox.Show("Added");

                    //int ntotal = 0;
                    k = k + total1;
                    textBox7.Text = k.ToString();
                    p = p + 1;
                    textBox1.Text = p.ToString();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Added");
                }


            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void estimate_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = p.ToString();
                SqlDataAdapter da = new SqlDataAdapter("select * from dealer", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    string ss = ds.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                    comboBox2.Items.Add(ss);
                }
                SqlDataAdapter da1 = new SqlDataAdapter("select * from item", cn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                for (int i1 = 0; i1 < ds1.Tables[0].Rows.Count; i1++)
                {

                    string ss1 = ds1.Tables[0].Rows[i1].ItemArray.GetValue(0).ToString();
                    comboBox1.Items.Add(ss1);
                }
            }

            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string dname1 = comboBox2.SelectedItem.ToString();
                string bno1 = textBox6.Text;
                string date1 = dateTimePicker1.Value.ToShortDateString();
                string net = textBox7.Text;
                int net1 = int.Parse(net);
                SqlCommand cmd1 = new SqlCommand("Insert into estimate values(@dname,@bno,@date,@sno,@iname,@qty,@rate,@discount,@total,@nettotal)", cn);
                cmd1.Parameters.AddWithValue("@dname", dname1);
                cmd1.Parameters.AddWithValue("@bno", bno1);
                cmd1.Parameters.AddWithValue("@date", date1);
                cmd1.Parameters.AddWithValue("@sno", 0);
                cmd1.Parameters.AddWithValue("@iname", 0);
                cmd1.Parameters.AddWithValue("@qty", 0);
                cmd1.Parameters.AddWithValue("@rate", 0);
                cmd1.Parameters.AddWithValue("@discount", 0);
                cmd1.Parameters.AddWithValue("@total", 0);
                cmd1.Parameters.AddWithValue("@nettotal", net1);
                cn.Open();
                int n1 = cmd1.ExecuteNonQuery();
                cn.Close();
                int n2 = 0, n3 = 0;
                if (n1 > 0)
                {

                    SqlDataAdapter da2 = new SqlDataAdapter("select * from dailybalance where date='" + date1 + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        string expense1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        string income1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                        string balance1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
                        int expense2 = int.Parse(expense1);
                        int income2 = int.Parse(income1);
                        int balance2 = int.Parse(balance1);
                        int expense3 = expense2 + net1;
                        int balance3 = income2 - expense3;
                        SqlCommand cmd5 = new SqlCommand("update dailybalance set expense='" + expense3 + "', balance='" + balance3 + "' where date='" + date1 + "'", cn);
                        cn.Open();
                        n2 = cmd5.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {

                        int bl = 0 - net1;
                        SqlCommand cmd6 = new SqlCommand("Insert into dailybalance values(@date,@income,@expense,@balance)", cn);
                        cmd6.Parameters.AddWithValue("@date", date1);
                        cmd6.Parameters.AddWithValue("@income", 0);
                        cmd6.Parameters.AddWithValue("@expense", net1);
                        cmd6.Parameters.AddWithValue("@balance", bl);
                        cn.Open();
                        n3 = cmd6.ExecuteNonQuery();
                        cn.Close();



                    }
                    if ((n2 > 0) || (n3 > 0))
                    {
                        MessageBox.Show("Added Net Amount");
                        p = 1;
                        k = 0;
                        textBox7.Text = "";
                        textBox1.Text = "1";
                        textBox6.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Not Added Net Amount");
                    }
                }
                else
                {
                    MessageBox.Show("Not Added Net Amount");
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int n7 = 0, n8 = 0;
                string dname = comboBox2.SelectedItem.ToString();
                string bno = textBox6.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string slno = textBox1.Text;
                int slno1 = int.Parse(slno);
                string iname = comboBox1.SelectedItem.ToString();
                string qty = textBox2.Text;
                int qty1 = int.Parse(qty);
                string rate = textBox3.Text;
                int rate1 = int.Parse(rate);
                string discount = textBox4.Text;
                int discount1 = int.Parse(discount);
                string total = textBox5.Text;
                int total1 = int.Parse(total);
                SqlCommand cmd = new SqlCommand("Insert into estimate values(@dname,@bno,@date,@sno,@iname,@qty,@rate,@discount,@total,@nettotal)", cn);
                cmd.Parameters.AddWithValue("@dname", dname);
                cmd.Parameters.AddWithValue("@bno", bno);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@sno", slno1);
                cmd.Parameters.AddWithValue("@iname", iname);
                cmd.Parameters.AddWithValue("@qty", qty1);
                cmd.Parameters.AddWithValue("@rate", rate1);
                cmd.Parameters.AddWithValue("@discount", discount1);
                cmd.Parameters.AddWithValue("@total", total1);
                cmd.Parameters.AddWithValue("@nettotal", 0);
                cn.Open();
                int n = cmd.ExecuteNonQuery();
                cn.Close();
                SqlDataAdapter da5 = new SqlDataAdapter("select * from availability where iname='" + iname + "'", cn);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5);
                if (ds5.Tables[0].Rows.Count > 0)
                {
                    string qty5 = ds5.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                    int qty6 = int.Parse(qty5);
                    int qty7 = qty6 + qty1;
                    SqlCommand cmd7 = new SqlCommand("update availability set qty='" + qty7 + "' where iname='" + iname + "'", cn);
                    cn.Open();
                    n7 = cmd7.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    SqlCommand cmd8 = new SqlCommand("Insert into availability values(@iname,@qty)", cn);
                    cmd8.Parameters.AddWithValue("@iname", iname);
                    cmd8.Parameters.AddWithValue("@qty", qty1);
                    cn.Open();
                    n8 = cmd8.ExecuteNonQuery();
                    cn.Close();
                }
                if (((n > 0) && (n7 > 0)) || ((n > 0) && (n8 > 0)))
                {
                    MessageBox.Show("Added");

                    //int ntotal = 0;
                    k = k + total1;
                    textBox7.Text = k.ToString();
                    p = p + 1;
                    textBox1.Text = p.ToString();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Added");
                }


            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string dname1 = comboBox2.SelectedItem.ToString();
                string bno1 = textBox6.Text;
                string date1 = dateTimePicker1.Value.ToShortDateString();
                string net = textBox7.Text;
                int net1 = int.Parse(net);
                SqlCommand cmd1 = new SqlCommand("Insert into estimate values(@dname,@bno,@date,@sno,@iname,@qty,@rate,@discount,@total,@nettotal)", cn);
                cmd1.Parameters.AddWithValue("@dname", dname1);
                cmd1.Parameters.AddWithValue("@bno", bno1);
                cmd1.Parameters.AddWithValue("@date", date1);
                cmd1.Parameters.AddWithValue("@sno", 0);
                cmd1.Parameters.AddWithValue("@iname", 0);
                cmd1.Parameters.AddWithValue("@qty", 0);
                cmd1.Parameters.AddWithValue("@rate", 0);
                cmd1.Parameters.AddWithValue("@discount", 0);
                cmd1.Parameters.AddWithValue("@total", 0);
                cmd1.Parameters.AddWithValue("@nettotal", net1);
                cn.Open();
                int n1 = cmd1.ExecuteNonQuery();
                cn.Close();
                int n2 = 0, n3 = 0;
                if (n1 > 0)
                {

                    SqlDataAdapter da2 = new SqlDataAdapter("select * from dailybalance where date='" + date1 + "'", cn);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        string expense1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        string income1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                        string balance1 = ds2.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();
                        int expense2 = int.Parse(expense1);
                        int income2 = int.Parse(income1);
                        int balance2 = int.Parse(balance1);
                        int expense3 = expense2 + net1;
                        int balance3 = income2 - expense3;
                        SqlCommand cmd5 = new SqlCommand("update dailybalance set expense='" + expense3 + "', balance='" + balance3 + "' where date='" + date1 + "'", cn);
                        cn.Open();
                        n2 = cmd5.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {

                        int bl = 0 - net1;
                        SqlCommand cmd6 = new SqlCommand("Insert into dailybalance values(@date,@income,@expense,@balance)", cn);
                        cmd6.Parameters.AddWithValue("@date", date1);
                        cmd6.Parameters.AddWithValue("@income", 0);
                        cmd6.Parameters.AddWithValue("@expense", net1);
                        cmd6.Parameters.AddWithValue("@balance", bl);
                        cn.Open();
                        n3 = cmd6.ExecuteNonQuery();
                        cn.Close();



                    }
                    if ((n2 > 0) || (n3 > 0))
                    {
                        MessageBox.Show("Added Net Amount");
                        p = 1;
                        k = 0;
                        textBox7.Text = "";
                        textBox1.Text = "1";
                        textBox6.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Not Added Net Amount");
                    }
                }
                else
                {
                    MessageBox.Show("Not Added Net Amount");
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message);
            }
        }
    }
}
