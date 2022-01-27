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
    public partial class availability : Form
    {
        public availability()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Server=USER-E83B436DF5\\AMEER;Database=electricals;Integrated Security=true");
        private void availability_Load(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("Select iname as 'ItemName',qty as 'Stock' from availability order by iname", cn);
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
