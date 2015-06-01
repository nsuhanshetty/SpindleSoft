using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

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

        private static void InitializeSessionFactory()
        {
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

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
