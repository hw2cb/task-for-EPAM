using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public LoginModel(string login, string password)
        {

            Login = login;
            Password = password;
        }
    }
}
