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
    public partial class ViewQuotation : Form
    {
        public ViewQuotation()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void ViewQuotation_Load(object sender, EventArgs e)
        {

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("Select bno as 'Bill No',cname as 'Customer Name',date as 'Date',sno as 'SL No',iname as 'Item Name',qty as 'Quantity',rate as 'Rate', total as 'Total', netamount as 'Net Amount' from quotation order by date", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0].DefaultView;
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

                string a1 = dateTimePicker1.Value.ToShortDateString();
                SqlDataAdapter da = new SqlDataAdapter("select * from quotation where date='" + a1 + "'", cn);
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

                string a1 = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter("select * from quotation where cname='" + a1 + "'", cn);
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

                string a1 = dateTimePicker1.Value.ToShortDateString();
                SqlDataAdapter da = new SqlDataAdapter("select * from quotation where date='" + a1 + "'", cn);
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

                string a1 = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter("select * from quotation where cname='" + a1 + "'", cn);
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
