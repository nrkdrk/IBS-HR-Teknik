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
    public partial class TeknikViewForm : Form
    {
        
        bool flag = false;
        public string productId { get; set; }
        Boolean viewControl = false;
       
        public TeknikViewForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeknikViewForm_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void TeknikViewForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                this.Location = Cursor.Position;
            }
        }

        private void TeknikViewForm_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void TeknikViewForm_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            sqlConnection.Open();
            using (sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("select * from [TechnicalRecord] where id = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           /* MessageBox.Show(reader["owner"].ToString());*/
                            textBox1.Text = reader["owner"].ToString();
                            textBox4.Text = reader["contact"].ToString();
                            textBox6.Text = reader["address"].ToString();
                            textBox2.Text = reader["product"].ToString();
                            dateTimePicker1.Value = (DateTime)reader["delivery_date"];
                            textBox3.Text = reader["accessory"].ToString();
                            textBox5.Text = reader["explanation"].ToString();
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String contact = textBox4.Text;
            String address = textBox6.Text;
            String product = textBox2.Text;
            String delivery_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String accessory = textBox3.Text;
            String explanation = textBox5.Text;

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            sqlConnection.Open();
            using (sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE  TechnicalRecord SET owner=@owner,contact=@contact," +
                    "address=@address,product=@product,delivery_date=@delivery_date,accessory=@accessory," +
                    "explanation=@explanation where id = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", productId);
                    command.Parameters.Add("@owner", name);
                    command.Parameters.Add("@contact", contact);
                    command.Parameters.Add("@address", address);
                    command.Parameters.Add("@product", product);
                    command.Parameters.Add("@delivery_date", delivery_date);
                    command.Parameters.Add("@accessory", accessory);
                    command.Parameters.Add("@explanation", explanation);
                    command.ExecuteNonQuery();

                    UpdateDialogForm updateDialogForm = new UpdateDialogForm();
                    DialogResult dialogResult = updateDialogForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        //do processing
                    }
                    else
                    {
                        //do processing
                    }
                }
                this.Close();
            }
        }

        private void TeknikViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TeknikİslemlerForm teknikİslemlerForm = (TeknikİslemlerForm)Application.OpenForms["TeknikİslemlerForm"];
            teknikİslemlerForm.DataGridView();
        }
    }
}
