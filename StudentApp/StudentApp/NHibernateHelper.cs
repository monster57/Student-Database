using System;
using NHibernate;
using NHibernate.Cfg;

namespace StudentApp
{
    public sealed class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
        private static ISession currentSession = null;

        public static ISession GetCurrentSession()
        {
            try
            {
                currentSession = sessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return currentSession;
        }

        public static void CloseSession()
        {
            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}