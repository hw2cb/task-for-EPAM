using DAL.Interfaces;
using Entities;
using JsonDAL.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDAL
{
    public class JsonUsersDAO : JsonDAO, IUsersDAL
    {
        private const string JsonFilesPath = @"D:\Learn\EPAM\TaskRepository\task-for-EPAM\Task 8\EPAM.8_1\Files\Users\";
        private IAwardsDAL _awardsDAL;
        public JsonUsersDAO(IAwardsDAL awardsDAL)
        {
            _awardsDAL = awardsDAL;
        }
        public User AddUser(string name, DateTime dateOfBirthday)
        {
            var user = new User(name, dateOfBirthday);

            string json = JsonConvert.SerializeObject(user);
            File.WriteAllText(GetFileFullNameById(user.Id), json);
            return user;
        }

        public void EditUser(Guid id, string name, DateTime dateOfBirthday)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);
            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(pathToFile));
            user.Edit(name, dateOfBirthday);
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(user));
        }
        public void EditUser(Guid id, Award award)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);
            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(pathToFile));
            user.Awards.Add(award);
            user.AwardsId.Add(award.Id);
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(user));
        }

        public User GetUser(Guid id)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(pathToFile));

            foreach(var awardId in user.AwardsId)
            {
                user.Awards.Add(_awardsDAL.GetAward(awardId));
            }
            return user;
        }

        public IEnumerable<User> GetUsers()
        {

            string[] files = Directory.GetFiles(JsonFilesPath);
            List<User> users = new List<User>();
            if (files.Length == 0) return users;
            for (int i = 0; i < files.Length; i++)
            {
                string content = File.ReadAllText(files[i]);
                User user = JsonConvert.DeserializeObject<User>(content);
                foreach (var awardId in user.AwardsId)
                {
                    user.Awards.Add(_awardsDAL.GetAward(awardId));
                }
                users.Add(user);
            }
            return users;
        }

        public void RemoveUser(Guid id)
        {
            string pathToUser = GetFileFullNameById(id);
            CheckFileUser(pathToUser);
            File.Delete(pathToUser);
        }
        public void Save(User user)
        {
            string pathToFile = GetFileFullNameById(user.Id);
            CheckFileUser(pathToFile);
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(user));
        }

        public void SetPhoto(Guid id, string path)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);
            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(pathToFile));
            user.PathToImage = path;
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(user));
        }

        private string GetFileFullNameById(Guid id) => JsonFilesPath + id + ".json";

    }
}
