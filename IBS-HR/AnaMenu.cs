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
    public partial class AnaMenu : Form
    {
        bool flag = false;
        int onlinealtmenuControl = 0;
        public AnaMenu()
        {
            Boolean processResult = SqlConn();
            if (processResult == true)
            {
                InitializeComponent();
                panel4.BackColor = Color.FromArgb(47, 79, 79);
                homePanel.Controls.Clear();
                HomeForm RandevuForm = new HomeForm();
                RandevuForm.TopLevel = false;
                RandevuForm.AutoScroll = true;
                homePanel.Controls.Add(RandevuForm);
                RandevuForm.Dock = DockStyle.Fill;
                RandevuForm.Show();
            }
            else
            {
                UnsuccessfulDialog unsuccessfulDialog = new UnsuccessfulDialog();
                DialogResult dialogResult = unsuccessfulDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //do processing
                }
                else
                {
                    //do processing
                }
            }
        }
        static Boolean SqlConn()
        {
            Boolean processResult = false;
            try
            {
                string dbName = "IBSHR";
                SqlConnection connection = new SqlConnection("server=.\\SQLEXPRESS;database=master; Integrated Security=SSPI");
                SqlCommand command = new SqlCommand("SELECT Count(name) FROM master.dbo.sysdatabases WHERE name=@prmVeritabani", connection);
                command.Parameters.AddWithValue("@prmVeriTabani", dbName);
                connection.Open();

                int sonuc = (int)command.ExecuteScalar();
                if (sonuc != 0) {
                    SuccessfulDialog successfulDialog = new SuccessfulDialog();
                    DialogResult dialogResult = successfulDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        //do processing
                    }
                    else
                    {
                        //do processing
                    }
                    processResult = true;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Programı İlk Defa Kullanıdığınız Tespit Edildi.\n Veri Tabanı Kurulumu Yapılsın mı ?", "IBS-HR Teknik Servis", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        command.CommandText = "Create Database " + dbName;
                        command.ExecuteNonQuery();
                        connection.Close();

                        string connectionString = "server=.\\SQLEXPRESS; database=IBSHR; integrated security=SSPI; User id = sa; Password=nrkdrk;";
                        using (SqlConnection tolustur = new SqlConnection(connectionString))
                        try
                        {
                            /*Veri tabanında tablolarımızı oluşturuyoruz*/
                            tolustur.Open();
                            /*Teknik Servis kayıt Tablosu*/
                            using (SqlCommand TechnicalRecordCommand = new SqlCommand("CREATE TABLE TechnicalRecord(id int IDENTITY(1,1),owner varchar(100)," +
                            "contact varchar(255),address varchar(255),product varchar(100),delivery_date date,accessory varchar(255),explanation varchar(255));", tolustur))
                            TechnicalRecordCommand.ExecuteNonQuery();
                            /*Teknik İşlemler tablosu*/
                            using (SqlCommand TechnicalOperationsCommand = new SqlCommand("CREATE TABLE TechnicalOperations(id int IDENTITY(1,1),TRId varchar(100)," +
                            "processed bit,approval bit,operation varchar(100),reception_date date,fee varchar(255),completion_date date,operations_carried varchar(255)," +
                            "forwarding bit,referral_clarification varchar(255)); ", tolustur))
                            TechnicalOperationsCommand.ExecuteNonQuery();
                                
                            ProvinceInstallationDialog provinceInstallationDialog = new ProvinceInstallationDialog();
                            DialogResult dialogResult1 = provinceInstallationDialog.ShowDialog();
                            if (dialogResult1== DialogResult.OK)
                            {
                                //do processing
                            }
                            else
                            {
                                //do processing
                            }
                            processResult = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kurgu Hazırlanırken Hata." + ex.Message);
                            processResult = false;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        processResult = false;
                    }                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yerel Sunucu İle Bağlantı Başarısız. \n" + ex.Message);
                MessageBox.Show("Yerel Sunucu Bağlantısı Başarısız. Giriş Yapılamaz.");
                processResult = false;
            }
            return processResult;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                this.Location = Cursor.Position;
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExitDialog CikisDialog = new ExitDialog();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (CikisDialog.ShowDialog(this) == DialogResult.OK)
            {
                //do processing
            }
            else
            {
                //do processing
            }
        }
        private void exitPanel_Click(object sender, EventArgs e)
        {
            ExitDialog CikisDialog = new ExitDialog();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (CikisDialog.ShowDialog(this) == DialogResult.OK)
            {
                //do processing
            }
            else
            {
                //do processing
            }
        }
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            ExitDialog CikisDialog = new ExitDialog();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (CikisDialog.ShowDialog(this) == DialogResult.OK)
            {
                //do processing
            }
            else
            {
                //do processing
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            İnformationDialog informationDialog = new İnformationDialog();
            if (informationDialog.ShowDialog(this) == DialogResult.OK)
            {
                //do processing
            }
            else
            {
                //do processing
            }
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HomeForm RandevuForm = new HomeForm();
            RandevuForm.TopLevel = false;
            RandevuForm.AutoScroll = true;
            homePanel.Controls.Add(RandevuForm);
            RandevuForm.Dock = DockStyle.Fill;
            RandevuForm.Show();

            if (onlinealtmenuControl == 0)
            {
                onlinealtmenu.Visible = true;
                panel8.Visible = true;
                onlinealtmenuControl = 1;
                label9.Text = "Teknik | Hibe | Servis";
                label9.Visible = true;
            }
            else if (onlinealtmenuControl == 1)
            {
                onlinealtmenu.Visible = false;
                onlinealtmenuControl = 0;
                label9.Text = "Ana Sayfa";
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HomeForm RandevuForm = new HomeForm();
            RandevuForm.TopLevel = false;
            RandevuForm.AutoScroll = true;
            homePanel.Controls.Add(RandevuForm);
            RandevuForm.Dock = DockStyle.Fill;
            RandevuForm.Show();
            if (onlinealtmenuControl == 0)
            {
                onlinealtmenu.Visible = true;
                panel8.Visible = true;
                onlinealtmenuControl = 1;
                label9.Text = "Teknik | Hibe | Servis";
                label9.Visible = true;
            }
            else if (onlinealtmenuControl == 1)
            {
                onlinealtmenu.Visible = false;
                onlinealtmenuControl = 0;
                label9.Text = "Ana Sayfa";
            }
        }
        private void panel7_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikKayit teknikKayit = new TeknikKayit();
            teknikKayit.TopLevel = false;
            teknikKayit.AutoScroll = true;
            homePanel.Controls.Add(teknikKayit);
            teknikKayit.Dock = DockStyle.Fill;
            teknikKayit.Show();
            label9.Text = "Teknik Servis Kayıt";
        }
        private void label4_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikKayit teknikKayit = new TeknikKayit();
            teknikKayit.TopLevel = false;
            teknikKayit.AutoScroll = true;
            homePanel.Controls.Add(teknikKayit);
            teknikKayit.Dock = DockStyle.Fill;
            teknikKayit.Show();
            label9.Text = "Teknik Servis Kayıt";
        }
        private void panel5_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikİslemlerForm teknikİslemlerForm = new TeknikİslemlerForm();
            teknikİslemlerForm.TopLevel = false;
            teknikİslemlerForm.AutoScroll = true;
            homePanel.Controls.Add(teknikİslemlerForm);
            teknikİslemlerForm.Dock = DockStyle.Fill;
            teknikİslemlerForm.Show();
            label9.Text = "Teknik İşlemler";
        }
        private void label3_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikİslemlerForm teknikİslemlerForm = new TeknikİslemlerForm();
            teknikİslemlerForm.TopLevel = false;
            teknikİslemlerForm.AutoScroll = true;
            homePanel.Controls.Add(teknikİslemlerForm);
            teknikİslemlerForm.Dock = DockStyle.Fill;
            teknikİslemlerForm.Show();
            label9.Text = "Teknik İşlemler";
        }
        private void panel8_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikListeForm teknikListe = new TeknikListeForm();
            teknikListe.TopLevel = false;
            teknikListe.AutoScroll = true;
            homePanel.Controls.Add(teknikListe);
            teknikListe.Dock = DockStyle.Fill;
            teknikListe.Show();
            label9.Text = "Teknik İşlemler Liste";
        }
        private void label5_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            TeknikListeForm teknikListe = new TeknikListeForm();
            teknikListe.TopLevel = false;
            teknikListe.AutoScroll = true;
            homePanel.Controls.Add(teknikListe);
            teknikListe.Dock = DockStyle.Fill;
            teknikListe.Show();
            label9.Text = "Teknik İşlemler Liste";
        }
        private void panel6_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HibeKayıt hibeKayıt = new HibeKayıt();
            hibeKayıt.TopLevel = false;
            hibeKayıt.AutoScroll = true;
            homePanel.Controls.Add(hibeKayıt);
            hibeKayıt.Dock = DockStyle.Fill;
            hibeKayıt.Show();
            label9.Text = "Hibe Kayıt";
        }
        private void label6_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HibeKayıt hibeKayıt = new HibeKayıt();
            hibeKayıt.TopLevel = false;
            hibeKayıt.AutoScroll = true;
            homePanel.Controls.Add(hibeKayıt);
            hibeKayıt.Dock = DockStyle.Fill;
            hibeKayıt.Show();
            label9.Text = "Hibe Kayıt";
        }
        private void panel9_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HibeListe hibeListe = new HibeListe();
            hibeListe.TopLevel = false;
            hibeListe.AutoScroll = true;
            homePanel.Controls.Add(hibeListe);
            hibeListe.Dock = DockStyle.Fill;
            hibeListe.Show();
            label9.Text = "Hibe Liste";
        }
        private void label7_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            HibeListe hibeListe = new HibeListe();
            hibeListe.TopLevel = false;
            hibeListe.AutoScroll = true;
            homePanel.Controls.Add(hibeListe);
            hibeListe.Dock = DockStyle.Fill;
            hibeListe.Show();
            label9.Text = "Hibe Liste";
        }
        private void panel10_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            Servis_Kayıt servis_Kayıt = new Servis_Kayıt();
            servis_Kayıt.TopLevel = false;
            servis_Kayıt.AutoScroll = true;
            homePanel.Controls.Add(servis_Kayıt);
            servis_Kayıt.Dock = DockStyle.Fill;
            servis_Kayıt.Show();
            label9.Text = "Servis Kayıt";
        }
        private void label8_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            Servis_Kayıt servis_Kayıt = new Servis_Kayıt();
            servis_Kayıt.TopLevel = false;
            servis_Kayıt.AutoScroll = true;
            homePanel.Controls.Add(servis_Kayıt);
            servis_Kayıt.Dock = DockStyle.Fill;
            servis_Kayıt.Show();
            label9.Text = "Servis Kayıt";
        }
        private void panel11_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            ServisListeForm servisListeForm = new ServisListeForm();
            servisListeForm.TopLevel = false;
            servisListeForm.AutoScroll = true;
            homePanel.Controls.Add(servisListeForm);
            servisListeForm.Dock = DockStyle.Fill;
            servisListeForm.Show();
            label9.Text = "Servis Liste";
        }
        private void label11_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            ServisListeForm servisListeForm = new ServisListeForm();
            servisListeForm.TopLevel = false;
            servisListeForm.AutoScroll = true;
            homePanel.Controls.Add(servisListeForm);
            servisListeForm.Dock = DockStyle.Fill;
            servisListeForm.Show();
            label9.Text = "Servis Liste";
        }
    }
}
