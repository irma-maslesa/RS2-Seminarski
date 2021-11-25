﻿using Pelikula.API.Model;
using Pelikula.WINUI.Forms.Korisnik;
using Pelikula.WINUI.Forms.TipKorisnika;
using Pelikula.WINUI.Forms.Zanr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI
{
    public partial class MdiFrmMain : Form
    {
        private KorisnikTip? prijavljeniKorisnikTip = null;

        public MdiFrmMain()
        {
            InitializeComponent();
            Size = new Size() { Width = 1300, Height = 700 };
            StartPosition = FormStartPosition.CenterScreen;

            var korisnik = Properties.Settings.Default.PrijavljeniKorisnik;
            if (korisnik != null)
            {
                string tip = korisnik.TipKorisnika.Naziv;

                switch (tip)
                {
                    case "Administrator":
                        prijavljeniKorisnikTip = KorisnikTip.Administrator;
                        break;
                    case "Moderator":
                        prijavljeniKorisnikTip = KorisnikTip.Moderator;
                        break;
                    case "Radnik":
                        prijavljeniKorisnikTip = KorisnikTip.Radnik;
                        break;
                    case "Klijent":
                        prijavljeniKorisnikTip = KorisnikTip.Klijent;
                        break;
                }

                tssKorisnik.Text = $"Korisnik: {korisnik.Ime} {korisnik.Prezime} ({korisnik.KorisnickoIme})";
            }
            else
            {
                MessageBox.Show("Prijava na sistem nije uspjela, pojavila se greška!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        private void MdiFrmMain_Load(object sender, EventArgs e)
        {
            korisniciToolStripMenuItem.Visible = false;
            tipoviKorisnikaToolStripMenuItem.Visible = false;
            saleToolStripMenuItem.Visible = false;
            zanroviToolStripMenuItem.Visible = false;
            jediniceMjereToolStripMenuItem.Visible = false;
            filmskeLicnostiToolStripMenuItem.Visible = false;
            klijentiToolStripMenuItem.Visible = false;
            filmoviToolStripMenuItem.Visible = false;
            projekcijeToolStripMenuItem.Visible = false;
            artikliToolStripMenuItem.Visible = false;
            rezervacijeToolStripMenuItem.Visible = false;
            prodajaToolStripMenuItem.Visible = false;
            izvjestajiToolStripMenuItem.Visible = false;
            obavijestiToolStripMenuItem.Visible = false;
            dojmoviToolStripMenuItem.Visible = false;
            anketeToolStripMenuItem.Visible = false;
            odjavaToolStripMenuItem.Visible = true;

            if (prijavljeniKorisnikTip.HasValue)
            {
                switch (prijavljeniKorisnikTip.Value)
                {
                    case KorisnikTip.Administrator:
                        korisniciToolStripMenuItem.Visible = true;
                        tipoviKorisnikaToolStripMenuItem.Visible = true;
                        saleToolStripMenuItem.Visible = true;
                        zanroviToolStripMenuItem.Visible = true;
                        jediniceMjereToolStripMenuItem.Visible = true;
                        filmskeLicnostiToolStripMenuItem.Visible = true;
                        filmoviToolStripMenuItem.Visible = true;
                        projekcijeToolStripMenuItem.Visible = true;
                        artikliToolStripMenuItem.Visible = true;
                        izvjestajiToolStripMenuItem.Visible = true;
                        obavijestiToolStripMenuItem.Visible = true;
                        dojmoviToolStripMenuItem.Visible = true;
                        anketeToolStripMenuItem.Visible = true;
                        break;
                    case KorisnikTip.Moderator:
                        filmoviToolStripMenuItem.Visible = true;
                        projekcijeToolStripMenuItem.Visible = true;
                        artikliToolStripMenuItem.Visible = true;
                        izvjestajiToolStripMenuItem.Visible = true;
                        obavijestiToolStripMenuItem.Visible = true;
                        dojmoviToolStripMenuItem.Visible = true;
                        anketeToolStripMenuItem.Visible = true;
                        break;
                    case KorisnikTip.Radnik:
                        klijentiToolStripMenuItem.Visible = true;
                        rezervacijeToolStripMenuItem.Visible = true;
                        prodajaToolStripMenuItem.Visible = true;
                        break;
                }
            }

        }

        private void ZanroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmZanr frm = new FrmZanr();
            OpenForm(frm);
        }

        private void TipoviKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipKorisnika frm = new FrmTipKorisnika();
            OpenForm(frm);
        }

        private void KorisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKorisnik frm = new FrmKorisnik();
            OpenForm(frm);
        }

        private void OdjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Restart();
        }

        private void OpenForm(Form frm)
        {
            if (!MdiChildren.Select(f => f.Name).Contains(frm.Name))
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }

                frm.MdiParent = this;

                frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;

                frm.Show();
            }
        }
    }
}