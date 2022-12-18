using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i652b8_restapi_client
{
    static class Config
    {
        static Config()
        {
            Ip = ConfigurationManager.AppSettings["ip"].ToString();
            Port = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
        }

        private static string ip;
        public static string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private static int port;
        public static int Port
        {
            get { return port; }
            set { port = value; }
        }

        private static User currentUser;
        public static User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

    }
}
