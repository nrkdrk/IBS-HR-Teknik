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
    public partial class Servis_Kayıt : Form
    {
        public Servis_Kayıt()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String service_claimant = textBox1.Text;
            String contact = textBox4.Text;
            String address = textBox6.Text;
            String product = textBox2.Text;
            String appointment_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String fault = textBox3.Text;
            String fault_description = textBox5.Text;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TechnicalService(service_claimant,contact,address,product,appointment_date,fault,fault_description)" +
                " VALUES (@service_claimant,@contact,@address,@product,@appointment_date,@fault,@fault_description)", sqlConnection);
                sqlCommand.Parameters.Add("@service_claimant", service_claimant);
                sqlCommand.Parameters.Add("@contact", contact);
                sqlCommand.Parameters.Add("@address", address);
                sqlCommand.Parameters.Add("@product", product);
                sqlCommand.Parameters.Add("@appointment_date", appointment_date);
                sqlCommand.Parameters.Add("@fault", fault);
                sqlCommand.Parameters.Add("@fault_description", fault_description);
                sqlCommand.ExecuteNonQuery();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                SavedDialogForm savedDialogForm = new SavedDialogForm();
                DialogResult dialogResult = savedDialogForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //do processing
                }
                else
                {
                    //do processing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına eklenirken hata oluştu. Hata: " + ex.Message);
            }
        }
    }
}
