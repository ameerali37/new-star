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
    public partial class warning : Form
    {
        public warning()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void warning_Load(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("Select iname as 'Item Name', qty as 'Stock' from availability where qty<=5", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
