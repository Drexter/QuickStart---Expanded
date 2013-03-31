using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.IO;

namespace QuickStart
{
    public class Global : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        protected static ISessionFactory CreateSessionFactory()
        {
            return new Configuration()
                .Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.Configuration.ConfigurationManager.AppSettings["PATH_NHIBERNATE_CONFIG_FILE"]))
                .BuildSessionFactory();
        }

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }

        protected Global()
        {
       
        HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize(); 

   
            BeginRequest += delegate
            {
                CurrentSession = SessionFactory.OpenSession();
            };
            EndRequest += delegate
            {
                if (CurrentSession != null)
                    CurrentSession.Dispose();
            };
        }
    }
}