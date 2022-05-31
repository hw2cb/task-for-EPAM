using BLL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonDAL;
using DAL.Interfaces;

namespace BLL
{
    public class UsersManager : IUsersBLL
    {
        private IUsersDAL _jsonDal;
        //TODO: Configuration
        public UsersManager(IUsersDAL jsonDal)
        {
            _jsonDal = jsonDal;
        }

        public User AddUser(string userName, DateTime dateOfBirthday, string namePhoto, string login, string password)
        {
            User user = _jsonDal.AddUser(userName, dateOfBirthday, login, password);
            SetPhoto(user.Id, namePhoto);
            return user;
        }

        public void EditUser(Guid id, string name, DateTime dateOfBirthday)
        {
            _jsonDal.EditUser(id, name, dateOfBirthday);
        }

        public void EditUser(Guid id, Award award)
        {
            _jsonDal.EditUser(id, award);
        }


        public User GetUser(Guid id)
        {
            return _jsonDal.GetUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _jsonDal.GetUsers();
        }

        public void RemoveUser(Guid id)
        {
            _jsonDal.RemoveUser(id);
        }

        public void SetPhoto(Guid id, string path)
        {
            _jsonDal.SetPhoto(id, path);
        }
    }
}
