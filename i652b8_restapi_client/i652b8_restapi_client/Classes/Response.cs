using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i652b8_restapi_client
{
    class Response
    {
        private int error;

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private List<Entry> entries;

        public List<Entry> Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int isAdmin;

        public int IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

    }
}
