

namespace Task3_3_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Введите слово, которое хотите проверить: ");
                string str = Console.ReadLine();
                if(str == String.Empty)
                {
                    Console.WriteLine("Введите слово!");
                    continue;
                }
                Console.WriteLine($"Слово написано на: {str.GetLanguage()}");
                Console.WriteLine("Нажмите на любую кнопку, что бы проверить другое слово. ESC - выйти");
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.Escape) break;
            }

        }
    }
}