using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i652b8_restapi_client
{
    public class Entry
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string passwd;

        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }

        private string md5;

        public string Md5
        {
            get { return md5; }
            set { md5 = value; }
        }

        private string sha1;

        public string Sha1
        {
            get { return sha1; }
            set { sha1 = value; }
        }

        private string sha256;

        public string Sha256
        {
            get { return sha256; }
            set { sha256 = value; }
        }
    }
}
