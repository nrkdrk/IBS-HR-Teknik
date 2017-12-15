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
    public partial class HibeKayıt : Form
    {
        public HibeKayıt()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String owner = textBox1.Text;
            String product = textBox2.Text;
            String contact = textBox4.Text;
            String approval_holder = textBox5.Text;
            String address = textBox6.Text;
            String why = textBox3.Text;
            String reception_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Boolean confirmation=false;
            if (checkBox1.Checked == true)
            {
                confirmation = true;
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO GrantOperations(owner,product,confirmation,contact,reception_date,approval_holder,address,why)" +
                " VALUES (@owner,@product,@confirmation,@contact,@reception_date,@approval_holder,@address,@why)", sqlConnection);
                sqlCommand.Parameters.Add("@owner", owner);
                sqlCommand.Parameters.Add("@product", product);
                sqlCommand.Parameters.Add("@confirmation", confirmation);
                sqlCommand.Parameters.Add("@contact", contact);
                sqlCommand.Parameters.Add("@reception_date", reception_date);
                sqlCommand.Parameters.Add("@approval_holder", approval_holder);
                sqlCommand.Parameters.Add("@address", address);
                sqlCommand.Parameters.Add("@why", why);
                sqlCommand.ExecuteNonQuery();
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
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
                checkBox1.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına eklenirken hata oluştu. Hata: " + ex.Message);
            }

        }
    }
}
