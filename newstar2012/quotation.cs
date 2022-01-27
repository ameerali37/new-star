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
    public partial class quotation : Form
    {
        public quotation()
        {
            InitializeComponent();
        }

        int p = 1;
        int k = 0;
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void quotation_Load(object sender, EventArgs e)
        {
            try
            {
                textBox11.Text = p.ToString();
                SqlDataAdapter da = new SqlDataAdapter("select * from item", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    string item1 = ds.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                    comboBox2.Items.Add(item1);
                }
                SqlDataAdapter da1 = new SqlDataAdapter("select * from quotation", cn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int count = ds1.Tables[0].Rows.Count;

                    string bno1 = ds1.Tables[0].Rows[count - 1].ItemArray.GetValue(0).ToString();
                    int bno2 = int.Parse(bno1);
                    int bno3 = bno2 + 1;
                    textBox1.Text = bno3.ToString();
                }
                else
                {
                    textBox1.Text = "1";
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
            string item4 = comboBox2.SelectedItem.ToString();
            string qty3 = textBox10.Text;
            int qty4 = int.Parse(qty3);

            SqlDataAdapter da4 = new SqlDataAdapter("select * from item where iname='" + item4 + "'", cn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            if (ds4.Tables[0].Rows.Count > 0)
            {
                string rate1 = ds4.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                int rate2 = int.Parse(rate1);
                int rate3 = rate2 * qty4;
                textBox9.Text = rate2.ToString();
                textBox4.Text = rate3.ToString();
            }
            else
            {
                MessageBox.Show("Item Not Found");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int n2 = 0;
                string cname = textBox2.Text;
                string qty3 = textBox10.Text;
                int qty4 = int.Parse(qty3);
                string bno = textBox1.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string slno = textBox11.Text;
                int slno1 = int.Parse(slno);
                string iname = comboBox2.SelectedItem.ToString();
                string rate = textBox9.Text;
                int rate1 = int.Parse(rate);
                string total = textBox4.Text;
                int total1 = int.Parse(total);
                SqlCommand cmd = new SqlCommand("Insert into quotation values(@bno,@cname,@date,@sno,@iname,@qty,@rate,@total,@netamount)", cn);

                cmd.Parameters.AddWithValue("@bno", bno);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@sno", slno1);
                cmd.Parameters.AddWithValue("@iname", iname);
                cmd.Parameters.AddWithValue("@qty", qty4);
                cmd.Parameters.AddWithValue("@rate", rate1);

                cmd.Parameters.AddWithValue("@total", total1);
                cmd.Parameters.AddWithValue("@netamount", 0);
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
                    int qty7 = qty6 - qty4;
                    SqlCommand cmd5 = new SqlCommand("update availability set qty='" + qty7 + "' where iname='" + iname + "'", cn);
                    cn.Open();
                    n2 = cmd5.ExecuteNonQuery();
                    cn.Close();

                }
                else
                {
                    MessageBox.Show("Item Not Found");
                }
                if ((n > 0) && (n2 > 0))
                {
                    MessageBox.Show("Added");

                    //int ntotal = 0;
                    k = k + total1;
                    textBox12.Text = k.ToString();
                    p = p + 1;
                    textBox11.Text = p.ToString();
                    textBox4.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Added");
                }

            }
            catch (Exception ex5)
            {
                MessageBox.Show(ex5.Message);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string cname1 = textBox2.Text;
                string bno1 = textBox1.Text;
                string date1 = dateTimePicker1.Value.ToShortDateString();
                string net = textBox12.Text;
                int net1 = int.Parse(net);
                SqlCommand cmd1 = new SqlCommand("Insert into quotation values(@bno,@cname,@date,@sno,@iname,@qty,@rate,@total,@netamount)", cn);

                cmd1.Parameters.AddWithValue("@bno", bno1);
                cmd1.Parameters.AddWithValue("@cname", cname1);
                cmd1.Parameters.AddWithValue("@date", date1);
                cmd1.Parameters.AddWithValue("@sno", 0);
                cmd1.Parameters.AddWithValue("@iname", 0);
                cmd1.Parameters.AddWithValue("@qty", 0);
                cmd1.Parameters.AddWithValue("@rate", 0);

                cmd1.Parameters.AddWithValue("@total", 0);
                cmd1.Parameters.AddWithValue("@netamount", net1);
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
                        int income3 = income2 + net1;
                        int balance3 = income3 - expense2;
                        SqlCommand cmd5 = new SqlCommand("update dailybalance set income='" + income3 + "', balance='" + balance3 + "' where date='" + date1 + "'", cn);
                        cn.Open();
                        n2 = cmd5.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {

                        int bl = net1;
                        SqlCommand cmd6 = new SqlCommand("Insert into dailybalance values(@date,@income,@expense,@balance)", cn);
                        cmd6.Parameters.AddWithValue("@date", date1);
                        cmd6.Parameters.AddWithValue("@income", net1);
                        cmd6.Parameters.AddWithValue("@expense", 0);
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
                        textBox12.Text = "";
                        string bno11 = textBox1.Text;
                        int bno12 = int.Parse(bno11);
                        int bno13 = bno12 + 1;
                        textBox1.Text = bno13.ToString();
                        textBox2.Text = "";
                        textBox11.Text = "1";

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

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                string item4 = comboBox2.SelectedItem.ToString();
                string qty3 = textBox10.Text;
                int qty4 = int.Parse(qty3);

                SqlDataAdapter da4 = new SqlDataAdapter("select * from item where iname='" + item4 + "'", cn);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    string rate1 = ds4.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                    int rate2 = int.Parse(rate1);
                    int rate3 = rate2 * qty4;
                    textBox9.Text = rate2.ToString();
                    textBox4.Text = rate3.ToString();
                }
                else
                {
                    MessageBox.Show("Item Not Found");
                }
            }
            catch (Exception ex8)
            {
                MessageBox.Show(ex8.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                int n2 = 0;
                string cname = textBox2.Text;
                string qty3 = textBox10.Text;
                int qty4 = int.Parse(qty3);
                string bno = textBox1.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string slno = textBox11.Text;
                int slno1 = int.Parse(slno);
                string iname = comboBox2.SelectedItem.ToString();
                string rate = textBox9.Text;
                int rate1 = int.Parse(rate);
                string total = textBox4.Text;
                int total1 = int.Parse(total);
                SqlCommand cmd = new SqlCommand("Insert into quotation values(@bno,@cname,@date,@sno,@iname,@qty,@rate,@total,@netamount)", cn);

                cmd.Parameters.AddWithValue("@bno", bno);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@sno", slno1);
                cmd.Parameters.AddWithValue("@iname", iname);
                cmd.Parameters.AddWithValue("@qty", qty4);
                cmd.Parameters.AddWithValue("@rate", rate1);

                cmd.Parameters.AddWithValue("@total", total1);
                cmd.Parameters.AddWithValue("@netamount", 0);
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
                    int qty7 = qty6 - qty4;
                    SqlCommand cmd5 = new SqlCommand("update availability set qty='" + qty7 + "' where iname='" + iname + "'", cn);
                    cn.Open();
                    n2 = cmd5.ExecuteNonQuery();
                    cn.Close();

                }
                else
                {
                    MessageBox.Show("Item Not Found");
                }
                if ((n > 0) && (n2 > 0))
                {
                    MessageBox.Show("Added");

                    //int ntotal = 0;
                    k = k + total1;
                    textBox12.Text = k.ToString();
                    p = p + 1;
                    textBox11.Text = p.ToString();
                    textBox4.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Added");
                }

            }
            catch (Exception ex5)
            {
                MessageBox.Show(ex5.Message);
            }


        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                string cname1 = textBox2.Text;
                string bno1 = textBox1.Text;
                string date1 = dateTimePicker1.Value.ToShortDateString();
                string net = textBox12.Text;
                int net1 = int.Parse(net);
                SqlCommand cmd1 = new SqlCommand("Insert into quotation values(@bno,@cname,@date,@sno,@iname,@qty,@rate,@total,@netamount)", cn);

                cmd1.Parameters.AddWithValue("@bno", bno1);
                cmd1.Parameters.AddWithValue("@cname", cname1);
                cmd1.Parameters.AddWithValue("@date", date1);
                cmd1.Parameters.AddWithValue("@sno", 0);
                cmd1.Parameters.AddWithValue("@iname", 0);
                cmd1.Parameters.AddWithValue("@qty", 0);
                cmd1.Parameters.AddWithValue("@rate", 0);

                cmd1.Parameters.AddWithValue("@total", 0);
                cmd1.Parameters.AddWithValue("@netamount", net1);
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
                        int income3 = income2 + net1;
                        int balance3 = income3 - expense2;
                        SqlCommand cmd5 = new SqlCommand("update dailybalance set income='" + income3 + "', balance='" + balance3 + "' where date='" + date1 + "'", cn);
                        cn.Open();
                        n2 = cmd5.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {

                        int bl = net1;
                        SqlCommand cmd6 = new SqlCommand("Insert into dailybalance values(@date,@income,@expense,@balance)", cn);
                        cmd6.Parameters.AddWithValue("@date", date1);
                        cmd6.Parameters.AddWithValue("@income", net1);
                        cmd6.Parameters.AddWithValue("@expense", 0);
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
                        textBox12.Text = "";
                        string bno11 = textBox1.Text;
                        int bno12 = int.Parse(bno11);
                        int bno13 = bno12 + 1;
                        textBox1.Text = bno13.ToString();
                        textBox2.Text = "";
                        textBox11.Text = "1";

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
