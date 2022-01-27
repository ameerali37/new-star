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
    public partial class ViewEstimate : Form
    {
        public ViewEstimate()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void ViewEstimate_Load(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("Select dname as 'Dealer Name',bno as 'Bill No',date as 'Date',sno as 'SL No',iname as 'Item Name',qty as 'Quantity',rate as 'Rate',discount as 'Discount', total as 'Total', nettotal as 'Net Amount' from estimate order by date", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                SqlDataAdapter da1 = new SqlDataAdapter("select * from dealer", cn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {

                    string ss = ds1.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                    comboBox1.Items.Add(ss);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string a1 = comboBox1.SelectedItem.ToString();
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where dname='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string a1 = dateTimePicker1.Value.ToShortDateString();
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where date='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string a1 = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where bno='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                string a1 = comboBox1.SelectedItem.ToString();
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where dname='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

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

                string a1 = dateTimePicker1.Value.ToShortDateString();
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where date='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {

                string a1 = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter("select * from estimate where bno='" + a1 + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
    }
}
