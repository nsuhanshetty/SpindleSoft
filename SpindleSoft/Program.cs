﻿using log4net;
using System;
using System.Windows.Forms;

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
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = LogManager.GetLogger(typeof(Main));
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex);
            }
        }
    }
}