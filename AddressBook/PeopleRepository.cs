using NHibernate;
using System.Linq;

namespace AddressBook
{
    public class PeopleRepository
    {
        public void Add(People people)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(people);
                    transaction.Commit();
                }
            }
        }

        public void Update(People people)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(people);
                    transaction.Commit();
                }
            }
        }

        public void Delete(People people)
        {
            using (ISession session = HibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(people);
                    transaction.Commit();
                }
            }
        }
    }
}
