using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MB_Üretim_Planlama_Ve_Kontrol_v3._0
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
            Application.Run(new Form1());
        }
    }
}
