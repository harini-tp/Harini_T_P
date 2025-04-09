using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Coding_test
{
    internal class User
    {
        public int userId {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public User(int userId, string username, string password, string role)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }
}
