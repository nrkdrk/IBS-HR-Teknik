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
        int hibealtmenuControl = 0;
        int hibealtmenuControl1 = 0;
        public static int lastEpisode = 0;

        /*lastEpisode nedir
         *Anasayfa=0 
         *Online Destek=1 
         *Randevu İşlemleri=2 
         *Devir İşlemleri=3 
         *Raporlama=4
         *Detaylı Raporlama=5*/
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
                label9.Text = "Teknik Takip";
                label9.Visible = true;
                lastEpisode = 1;
            }
            else if (onlinealtmenuControl == 1)
            {
                onlinealtmenu.Visible = false;
                onlinealtmenuControl = 0;
                label9.Text = "Ana Sayfa";
                lastEpisode = 0;
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
                label9.Text = "Teknik Takip";
                label9.Visible = true;
                lastEpisode = 1;
            }
            else if (onlinealtmenuControl == 1)
            {
                onlinealtmenu.Visible = false;
                onlinealtmenuControl = 0;
                label9.Text="Ana Sayfa";
                lastEpisode = 0;
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
            lastEpisode = 2;
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
            lastEpisode = 2;
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
            lastEpisode = 2;
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
            lastEpisode = 2;
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
            lastEpisode = 2;
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
            lastEpisode = 2;
        }
    }
}
