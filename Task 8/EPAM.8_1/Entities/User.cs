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

        public User(string name, DateTime dateOfBirthday)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirthday = dateOfBirthday;

            AwardsId = new List<Guid>();
            SetAge();

        }
        public void Edit(string name, DateTime dateOfBirthday)
        {
            Name = name;
            DateOfBirthday = dateOfBirthday;
            SetAge();

        }
        private void SetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirthday.Year;
            if (DateOfBirthday > now.AddYears(-age))
                age--;
            Age = age;
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
