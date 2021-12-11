using Pelikula.WINUI.Forms.Korisnik;
using System;
using System.Windows.Forms;

namespace Pelikula.WINUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmPrijava frm = new FrmPrijava();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK) {
                Application.Run(new MdiFrmMain());
            }
        }
    }
}
