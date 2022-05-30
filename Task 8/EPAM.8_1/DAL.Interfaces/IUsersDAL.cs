using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL.Interfaces
{
    public interface IUsersDAL
    {
        User AddUser(string name, DateTime dateOfBirthday);
        void RemoveUser(Guid Id);
        void EditUser(Guid id, string name, DateTime dateOfBirthday);
        void EditUser(Guid id, Award award);

        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void Save(User user);
        void SetPhoto(Guid id, string path);


    }
}
