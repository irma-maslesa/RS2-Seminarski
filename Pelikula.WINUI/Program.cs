using Pelikula.WINUI.Zanr;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmZanr());
        }
    }
}
