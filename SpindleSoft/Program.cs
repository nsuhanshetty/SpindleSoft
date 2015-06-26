using log4net;
using System;
using System.Windows.Forms;

namespace SpindleSoft
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var session = NHibernateHelper.OpenSession();

            //log.Info("testing and feeling awesome");
            Application.Run(new Main());
        }
    }
}