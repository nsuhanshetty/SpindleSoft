using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    class AlterationSaver
    {
        public static bool SaveAlterationInfo(Alteration alt)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(alt);
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

        }
    }
}
