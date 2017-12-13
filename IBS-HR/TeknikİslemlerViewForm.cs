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
    public partial class TeknikİslemlerViewForm : Form
    {
        public TeknikİslemlerViewForm()
        {
            InitializeComponent();
        }
        public string productId { get; set; }
        bool flag = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeknikİslemlerViewForm_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void TeknikİslemlerViewForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                this.Location = Cursor.Position;
            }
        }

        private void TeknikİslemlerViewForm_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
        private void TeknikİslemlerViewForm_Load(object sender, EventArgs e)
        {
            label2.Text = productId;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox1.Text = String.Empty;
            dateTimePicker1.Value = DateTime.Today;
            textBox3.Text = String.Empty;
            dateTimePicker2.Value = DateTime.Today;
            textBox7.Text = String.Empty;
            textBox2.Text = String.Empty;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            sqlConnection.Open();
            using (sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("select * from [TechnicalOperations] where TRId = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@id", productId);

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

        private void button1_Click(object sender, EventArgs e)
        {
          /*  String id = label2.Text;
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
            String operation = textBox1.Text;
            String reception_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String fee = textBox3.Text;
            String completion_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            String operations_carried = textBox7.Text;
            if (checkBox2.Checked == true)
            {
                forwarding = true;
            }
            else
            {
                forwarding = false;
            }
            String referral_clarification = textBox2.Text;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R7MNN89\SQLEXPRESS;Initial Catalog=IBSHR;User ID=sa;Password=nrkdrk");
            sqlConnection.Open();
            using (sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE  TechnicalOperations SET TRId=@TRId,processed=@processed," +
                    "approval=@approval,forwarding=@forwarding,delivery_date=@delivery_date,accessory=@accessory," +
                    "explanation=@explanation where id = @id", sqlConnection))
                {
                    command.Parameters.AddWithValue("@TRId", id);
                    command.Parameters.Add("@processed", processed);
                    command.Parameters.Add("@approval", approval);
                    command.Parameters.Add("@forwarding", forwarding);
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
            }*/
        }
    }
}
