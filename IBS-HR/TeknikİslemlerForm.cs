/*Berk Can www.nrkdrk.com | https://github.com/nrkdrk/IBS-HR-Teknik */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IBS_HR
{
    public partial class TeknikİslemlerForm : Form
    {
        public TeknikİslemlerForm()
        {
            InitializeComponent();
        }

        public DataGridView Dgv { get; set; }
        string id;

        private void TeknikİslemlerForm_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from TechnicalRecord", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
            }
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Ürün Sahibi";
            dataGridView1.Columns[2].HeaderText = "İletişim";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Ürün";
            dataGridView1.Columns[5].HeaderText = "Teslim Alınma";
            dataGridView1.Columns[6].HeaderText = "Aksesuar";
            dataGridView1.Columns[7].HeaderText = "Arıza";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id= row.Cells[0].Value.ToString();
                label2.Text = id;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TeknikViewForm teknikViewForm = new TeknikViewForm();
            teknikViewForm.productId = id;
            teknikViewForm.Show();
        }

        public void DataGridView()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from TechnicalRecord", sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
            }
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Ürün Sahibi";
            dataGridView1.Columns[2].HeaderText = "İletişim";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Ürün";
            dataGridView1.Columns[5].HeaderText = "Teslim Alınma";
            dataGridView1.Columns[6].HeaderText = "Aksesuar";
            dataGridView1.Columns[7].HeaderText = "Arıza";
        }
    }
}
