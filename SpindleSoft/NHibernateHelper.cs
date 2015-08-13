using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;

namespace SpindleSoft
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(NHibernateHelper));

        /*Strongly typed NHibernate configuration*/
        private static void InitializeSessionFactory()
        {
            try
            {
                log.Info("NHibernate Started");
                //todo: toget connection info from appsetting.
                _sessionFactory = Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString(c => c
                                .Server("localhost")
                                .Database("SpindleSoftDb")
                                .Username("sa")
                                .Password("sshetty")).ShowSql())
                    //(c => c.FromAppSetting("ConnectionString")) // Modify your ConnectionString
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    //.ExposeConfiguration(cfg => new NHibernate.Tool.hbm2ddl.SchemaExport(cfg).Create(true, true))
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                System.Windows.Forms.MessageBox.Show("Message:" + ex.Message + Environment.NewLine + "InnerException:" + ex.InnerException + "Source:" + ex.Source);
                throw;
            }
        }

        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }

        }
    }
}
