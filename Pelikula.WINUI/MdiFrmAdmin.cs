using Pelikula.WINUI.Forms.TipKorisnika;
using Pelikula.WINUI.Zanr;
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
    public partial class MdiFrmAdmin : Form
    {
        public MdiFrmAdmin()
        {
            InitializeComponent();
            Size = new Size() { Width = 1300, Height = 700 };
            StartPosition = FormStartPosition.CenterScreen;
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
