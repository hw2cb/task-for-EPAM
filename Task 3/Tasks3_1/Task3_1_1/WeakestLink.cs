using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1_1
{
    internal class WeakestLink
    {
        private List<Human> people;
        private int countHuman;
        private int period;
        public WeakestLink()
        {
            people = new List<Human>();
        }
        public void Run()
        {
            Console.WriteLine("Введите количество человек: ");
            countHuman = EnterNumber();
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            period = EnterNumber();
            GeneratePeople();
            Console.WriteLine("Список людей в кругу: ");
            PrintPeople();
            Console.WriteLine();
            StartProcess();
            Console.WriteLine("\nОставшиеся люди:");
            PrintPeople();
        }
        private void PrintPeople()
        {
            foreach (Human human in people)
            {
                Console.WriteLine(human);
            }
        }
        private void StartProcess()
        {
            int raund = 1;
            int index = period - 1;
            while(people.Count >= period)
            {
                //индекс, -1 потому что индексируется с 0
                Console.Write($"Раунд {raund}. Вычеркнут человек \"{people[index]}\"");
                people.RemoveAt(index);
                Console.WriteLine($". Людей осталось: { people.Count}");
                raund++;
            }

        }
        private void GeneratePeople()
        {
            //использую библиотеку из NuGet для генерации рандомных имен
            var personGenerator = new PersonNameGenerator();
            
            for (int i = 0; i<countHuman; i++)
            {
                var name = personGenerator.GenerateRandomFirstName();
                people.Add(new Human(name));
            }
        }
        private int EnterNumber()
        {
            int res;
            while(!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Введите число!");
            }
            return res;
        }
    }
}
