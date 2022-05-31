using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthBLL
    {
        bool CanLogin(string username, string password);
        bool CheckRole(string username, string role);
        string[] GetRolesUser(string username);
        void SetRole(string username, string role);
        User Register(string userName, DateTime dateOfBirthday, string pathToPhoto, string login, string password);
    }
}
