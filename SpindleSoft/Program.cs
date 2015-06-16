using System;
using System.Windows.Forms;
using log4net.Config;

namespace SpindleSoft
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            BasicConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var session = NHibernateHelper.OpenSession();
            Application.Run(new Main());
        }
    }
}