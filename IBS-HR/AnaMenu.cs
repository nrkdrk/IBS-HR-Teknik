using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBS_HR
{
    public partial class AnaMenu : Form
    {
        bool flag = false;
        int onlinealtmenuControl = 0;

        public AnaMenu()
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
            CikisDialog CikisDialog = new CikisDialog();

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
            CikisDialog CikisDialog = new CikisDialog();

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
            CikisDialog CikisDialog = new CikisDialog();

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
