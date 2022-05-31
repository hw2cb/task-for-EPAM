using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int Age { get; set; }

        //AwardsId хранятся для сериализации, что бы не хранить один объект
        //Award в двух файлах
        public List<Guid> AwardsId { get; private set; }



        //Awards для использования
        [JsonIgnore]
        public List<Award> Awards { get; private set; } = new List<Award>();

        public string PathToImage { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        public User(string name, DateTime dateOfBirthday, string login, string password) : this(Guid.NewGuid(), name, dateOfBirthday, login, password)
        {

        }
        public User(Guid id, string name, DateTime dateOfBirthday, string login, string password)
        {
            Id = id;
            Name = name;
            DateOfBirthday = dateOfBirthday;
            Login = login;
            Password = password;
            AwardsId = new List<Guid>();
            SetAge();
        }
        public User()
        {

        }
        public void Edit(string name, DateTime dateOfBirthday)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            SetAge();

        }
        public void SetAge()
        {
            Age = GetNewAge(DateOfBirthday);
        }
        public static int GetNewAge(DateTime dateOfBirhday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dateOfBirhday.Year;
            if (dateOfBirhday > now.AddYears(-age))
                age--;

            return age;
        }


        public void AddAwards(IEnumerable<Award> awards)
        {
            foreach (var award in awards)
                Awards.Add(award);
        }
        public override string ToString()
        {
            return $"Имя: {Name} дата рождения:{DateOfBirthday} возраст: {Age}";
        }
    }
}
