using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Auth : IAuthBLL
    {

        private readonly IUsersBLL _usersBLL;
        private readonly IUsersDAL _usersDAL;
        public Auth(IUsersBLL usersBLL, IUsersDAL usersDAL)
        {
            _usersBLL = usersBLL;
            _usersDAL = usersDAL;
        }
        public bool CanLogin(string login, string password)
        {
            string hashedPass = HashedPass(password);
            IEnumerable<User> users = _usersBLL.GetUsers();
            User user = users.Where(x => x.Login == login && x.Password == hashedPass).FirstOrDefault();
            if (user != null)
                return true;

            return false;
        }

        public bool CheckRole(string username, string role)
        {
            IEnumerable<User> users = _usersBLL.GetUsers();
            User user = users.Where(x => x.Login == username).FirstOrDefault();
            if (user == null)
                return false;

            if (user.Roles.Contains(role)) return true;
            return false;

        }

        public string[] GetRolesUser(string username)
        {
            IEnumerable<User> users = _usersBLL.GetUsers();
            User user = users.Where(x => x.Login == username).FirstOrDefault();
            if (user == null)
                return new string[0];

            return user.Roles.ToArray();
        }

        public User Register(string userName, DateTime dateOfBirthday, string pathToPhoto, string login, string password)
        {
            string hashedPass = HashedPass(password);
            return _usersBLL.AddUser(userName, dateOfBirthday, pathToPhoto, login, hashedPass);
        }

        public void SetRole(string username, string role)
        {
            IEnumerable<User> users = _usersBLL.GetUsers();
            User user = users.Where(x => x.Login == username).FirstOrDefault();
            if (user != null)
            {
                user.Roles.Add(role);
            }
            _usersDAL.Save(user);
        }
        private string HashedPass(string pass)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return Convert.ToBase64String(hash);
            //byte[] salt = new byte[128 / 8];
            //using (var rngCsp = new RNGCryptoServiceProvider())
            //{
            //    rngCsp.GetNonZeroBytes(salt);
            //}

            //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            //    password: pass,
            //    salt: salt,
            //    prf: KeyDerivationPrf.HMACSHA256,
            //    iterationCount: 100000,
            //    numBytesRequested: 256 / 8));
            //return hashed;
        }
    }
}
