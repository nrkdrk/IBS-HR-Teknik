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
            string dbName = "IBSHR";
            SqlConnection connection = new SqlConnection("server=.\\SQLEXPRESS;database=master; Integrated Security=SSPI");
            SqlCommand command = new SqlCommand("SELECT Count(name) FROM master.dbo.sysdatabases WHERE name=@prmVeritabani", connection);
            command.Parameters.AddWithValue("@prmVeriTabani", dbName);
            connection.Open();
            string connectionString = "server=.\\SQLEXPRESS; database=IBSHR; integrated security=SSPI; User id = sa; Password=nrkdrk;";
            using (SqlConnection tolustur = new SqlConnection(connectionString))
            try
            {
                    string query = "insert into TechnicalRecord (id, owner,contact,address,product,delivery_date,accessory,explanation)" +
                    " VALUES (@id,@name,@contact,@address,@product,@delivery_date,@accessory,@explanation)";
                    using (SqlCommand querySaveStaff = new SqlCommand(query))
                    {
                        querySaveStaff.Connection = tolustur;
                        querySaveStaff.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = "Berk";
                        querySaveStaff.Parameters.Add("@contact", SqlDbType.VarChar, 30).Value = "05051102956";
                        querySaveStaff.Parameters.Add("@address", SqlDbType.VarChar, 30).Value = "asdasdasdasdasdsa";
                        querySaveStaff.Parameters.Add("@product", SqlDbType.VarChar, 30).Value = "Besadasdasdsadasdasdrk";
                        querySaveStaff.Parameters.Add("@delivery_date", SqlDbType.VarChar, 30).Value = "27.11.2017";
                        querySaveStaff.Parameters.Add("@accessory", SqlDbType.VarChar, 30).Value = "asdasdasdsadasdad";
                        querySaveStaff.Parameters.Add("@explanation", SqlDbType.VarChar, 30).Value = "dasdasdasdasdasdasd";
                        tolustur.Open();
                    }

                }
            catch (Exception ex)
            {
                MessageBox.Show("Kurgu Hazırlanırken Hata." + ex.Message);
            }
            /* command.CommandText = "insert into TechnicalRecord (id, owner,contact,address,product,delivery_date,accessory,explanation)" +
                 " VALUES (1, 'Ahmet Kelebek','05425701107','asdghahjdgahdgahjsdgjasjhdsha','laptop','27.11.2017','','ısınıyor')";
             command.Connection = connection;


             command.ExecuteNonQuery();
             connection.Close();*/

        }
    }
}
