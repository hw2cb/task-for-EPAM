using Task3_1_2;

namespace Tasks3_1
{
    internal class Program
    {
        /* Текст для проверки: 
         * 
         * There are a number of traditions for weddings that have survived into the 21st century. It is still traditional for the bride and groom to have their own parties the night before getting married. The groom's party is called a 'Stag party', while the bride's is known as a 'Hen party'. On the morning of the wedding, the groom should not see the bride. If he does, this is bad luck. The bride puts on her special wedding dress, which is usually white. She also needs to wear 'something old, something new, something borrowed and something blue'. At the church, or registry office, the bride and groom exchange rings before walking together back down the aisle. When they get outside, the bride throws her bouquet in the air. Tradition says that whoever catches it will be the next person to get married. But it's not only the bride who throws something. All the people at the wedding throw confetti and rice over the happy couple. Finally, after the reception, the bride and groom drive off to have their honeymoon.
         * 
         * Файл типа test.txt, приложу в корень проекта
         */
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Выберите способ ввода текста в программу: \n1.Из файла .txt\n2.Ввести текст в ручную");
                int result = EnterNumber(2);
                Console.WriteLine("Давайте настроим программу! Введите количество доступных повторений слова в тексте: ");
                int countWordInText = EnterNumber(10);
                switch (result)
                {
                    case 1:
                        Console.WriteLine("Введите путь к файлу: ");
                        string pathToFile = Console.ReadLine();
                        bool flag = EnterText.CheckFile(pathToFile);
                        while(!flag)
                        {
                            Console.WriteLine("Введите верный путь к файлу!");
                            pathToFile = Console.ReadLine();
                            flag = EnterText.CheckFile(pathToFile);
                        }
                        EnterText.EnterTextFromFile(countWordInText, pathToFile);
                        break;
                    case 2:
                        Console.WriteLine("Введите текст: ");
                        EnterText.EnterTextFromConsole(countWordInText);
                        break;
                    default: throw new ArgumentException("invalid argument");
                }
            }
        }
        private static int EnterNumber(int limit)
        {
            int res;
            while (!int.TryParse(Console.ReadLine(), out res) || res > limit)
            {
                Console.WriteLine("Введите число!");
            }
            return res;
        }

    }
}