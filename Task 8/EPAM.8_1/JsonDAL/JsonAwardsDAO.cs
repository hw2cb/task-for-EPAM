using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using JsonDAL.Abstract;
using DAL.Interfaces;
using System.IO;
using Newtonsoft.Json;
namespace JsonDAL
{
    public class JsonAwardsDAO : JsonDAO, IAwardsDAL
    {
        private const string JsonFilesPath = @"D:\Learn\EPAM\TaskRepository\task-for-EPAM\Task 8\EPAM.8_1\Files\Awards\";

        public Award AddAward(string title)
        {
            var award = new Award(title);

            string json = JsonConvert.SerializeObject(award);
            File.WriteAllText(GetFileFullNameById(award.Id), json);
            return award;
        }

        public void EditAward(Guid id, string title)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);
            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(pathToFile));
            award.Edit(title);
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(award));
        }

        public Award GetAward(Guid id)
        {
            string pathToFile = GetFileFullNameById(id);
            try
            {
                CheckFileUser(pathToFile);
            }
            catch
            {
                return new Award("Удалена");
            }
            

            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(pathToFile));
            return award;
        }

        public IEnumerable<Award> GetAwards()
        {
            string[] files = Directory.GetFiles(JsonFilesPath);
            List<Award> awards = new List<Award>();
            if (files.Length == 0) return awards;
            for (int i = 0; i < files.Length; i++)
            {
                awards.Add(JsonConvert.DeserializeObject<Award>(File.ReadAllText(files[i])));
            }
            return awards;
        }

        public void RemoveAward(Guid id)
        {
            string pathToUser = GetFileFullNameById(id);
            CheckFileUser(pathToUser);
            File.Delete(pathToUser);
        }
        public void Save(Award award)
        {
            string pathToFile = GetFileFullNameById(award.Id);
            CheckFileUser(pathToFile);
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(award));
        }

        public void SetPhoto(Guid id, string path)
        {
            string pathToFile = GetFileFullNameById(id);
            CheckFileUser(pathToFile);
            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(pathToFile));
            award.PathToImage = path;
            File.WriteAllText(pathToFile, JsonConvert.SerializeObject(award));
        }

        private string GetFileFullNameById(Guid id) => JsonFilesPath + id + ".json";

    }
}
