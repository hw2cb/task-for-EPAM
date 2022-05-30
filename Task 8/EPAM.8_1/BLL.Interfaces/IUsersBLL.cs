using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsersBLL
    {
        User AddUser(string userName, DateTime dateOfBirthday, string pathToPhoto);
        void RemoveUser(Guid id);
        void EditUser(Guid id, string name, DateTime dateOfBirthday);
        void EditUser(Guid id, Award award);
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void SetPhoto(Guid id, string path);
    }
}
