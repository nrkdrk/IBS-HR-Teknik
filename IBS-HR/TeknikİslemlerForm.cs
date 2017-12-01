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

        private void button1_Click(object sender, EventArgs e)
        {
            String id= label2.Text;
            Boolean processed;
            Boolean approval;
            Boolean forwarding;
            if (checkBox1.Checked == true)
            {
                 processed = true;
            }
            else
            {
                 processed = false;
            }
            if (checkBox3.Checked == true)
            {
                approval = true;
            }
            else
            {
                approval = false;
            }
            String operation=textBox1.Text;
            String reception_date=dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String fee=textBox3.Text;
            String completion_date= dateTimePicker2.Value.ToString("yyyy-MM-dd");
            String operations_carried=textBox7.Text;
            if (checkBox2.Checked == true)
            {
                forwarding = true;
            }
            else
            {
                forwarding=false;
            }
            String referral_clarification=textBox2.Text;
             try
             {
                 SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
                 sqlConnection.Open();
                 SqlCommand sqlCommand = new SqlCommand("INSERT INTO TechnicalOperations(TRId,processed,approval,operation,reception_date,fee,completion_date,operations_carried,forwarding,referral_clarification)" +
                 " VALUES (@TRId,@processed,@approval,@operation,@reception_date,@fee,@completion_date,@operations_carried,@forwarding,@referral_clarification)", sqlConnection);
                 sqlCommand.Parameters.Add("@TRId", id);
                 sqlCommand.Parameters.Add("@processed", processed);
                 sqlCommand.Parameters.Add("@approval", approval);
                 sqlCommand.Parameters.Add("@operation", operation);
                 sqlCommand.Parameters.Add("@reception_date", reception_date);
                 sqlCommand.Parameters.Add("@fee", fee);
                 sqlCommand.Parameters.Add("@completion_date", completion_date);
                 sqlCommand.Parameters.Add("@operations_carried", operations_carried);
                 sqlCommand.Parameters.Add("@forwarding", forwarding);
                 sqlCommand.Parameters.Add("@referral_clarification", referral_clarification);
                 sqlCommand.ExecuteNonQuery();
                 MessageBox.Show("Kayıt Edildi");
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Veritabanına eklenirken hata oluştu. Hata: " + ex.Message);
             }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {/****************Seçilen Ürünün teknik detaylarını alttaki form araçlarında gösterme**************************/
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                textBox1.Text = String.Empty;
                dateTimePicker1.Value = DateTime.Today;
                textBox3.Text = String.Empty;
                dateTimePicker2.Value = DateTime.Today;
                textBox7.Text = String.Empty;
                textBox2.Text = String.Empty;
                id = row.Cells[0].Value.ToString();
                label2.Text = id;
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
                sqlConnection.Open();
                using (sqlConnection)
                {
                    using (SqlCommand command = new SqlCommand("select * from [TechnicalOperations] where id = @id", sqlConnection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                label2.Text = reader["TRId"].ToString();
                                String processed = reader["processed"].ToString();
                                String approval = reader["approval"].ToString();
                                String forwarding = reader["forwarding"].ToString();
                                if (processed == "True")
                                {
                                    checkBox1.Checked = true;
                                }
                                else
                                {
                                    checkBox1.Checked = false;
                                }
                                if (approval == "True")
                                {
                                    checkBox3.Checked = true;
                                }
                                else
                                {
                                    checkBox3.Checked = false;
                                }
                                if (forwarding == "True")
                                {
                                    checkBox2.Checked = true;
                                }
                                else
                                {
                                    checkBox2.Checked = false;
                                }
                                textBox1.Text = reader["operation"].ToString();
                                dateTimePicker1.Value = (DateTime)reader["reception_date"];
                                textBox3.Text = reader["fee"].ToString();
                                dateTimePicker2.Value = (DateTime)reader["completion_date"];
                                textBox7.Text = reader["operations_carried"].ToString();
                                textBox2.Text = reader["referral_clarification"].ToString();
                            }
                        }
                    }
                }
            }
        }
        private void TeknikİslemlerForm_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox1.Text= String.Empty;
            dateTimePicker1.Value = DateTime.Today;
            textBox3.Text = String.Empty;
            dateTimePicker2.Value = DateTime.Today;
            textBox7.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox1.Text = String.Empty;
            dateTimePicker1.Value = DateTime.Today;
            textBox3.Text = String.Empty;
            dateTimePicker2.Value = DateTime.Today;
            textBox7.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
