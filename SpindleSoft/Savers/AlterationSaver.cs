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
        public static bool SaveAlterationInfo(Alteration _alteration)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (var item in _alteration.AlterationItems)
                        {
                            item.Alteration = _alteration;
                        }
                        session.SaveOrUpdate(_alteration);
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
