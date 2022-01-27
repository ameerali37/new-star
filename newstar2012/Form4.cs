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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();

        }



       

        private void button2_Click(object sender, EventArgs e)
        {
            availability av = new availability();
            av.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            quotation qt = new quotation();
            qt.Show();
        }

       

       

        private void button1_Click(object sender, EventArgs e)
        {
            balance1 bl1 = new balance1();
            bl1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pswd ps = new pswd();
            ps.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            warning wn = new warning();
            wn.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            estimate es = new estimate();
            es.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddDealer ad = new AddDealer();
            ad.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ViewQuotation vq = new ViewQuotation();
            vq.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ViewEstimate ve = new ViewEstimate();
            ve.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewItem vi = new ViewItem();
            vi.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ViewDealer vd = new ViewDealer();
            vd.Show();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            estimate es = new estimate();
            es.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            quotation qt = new quotation();
            qt.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            balance1 bl1 = new balance1();
            bl1.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            availability av = new availability();
            av.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            ViewEstimate ve = new ViewEstimate();
            ve.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            ViewQuotation vq = new ViewQuotation();
            vq.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            ViewDealer vd = new ViewDealer();
            vd.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            ViewItem vi = new ViewItem();
            vi.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            AddDealer ad = new AddDealer();
            ad.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            warning wn = new warning();
            wn.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            pswd ps = new pswd();
            ps.Show();
        }
    }
}
