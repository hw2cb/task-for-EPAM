/*TASK 1.1.6
 * FONT ADJUSTMENT
 * Предложите способ хранения информации о форматировании текста надписи
 *  и напишите программу, которая позволяет устанавливать и изменять начертание:
 *  
 *  Параметры надписи: None
 *  Введите:
 *      1: bold
 *      2: italic
 *      3: underline
 *  1
 *  Параметры надписи: Bold
 *  Введите:
 *      1: bold
 *      2: italic
 *      3: underline
 */
namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<int, string> repositoryFonts = new Dictionary<int, string>()
            {
                {1, "bold" },
                {2, "italic" },
                {3, "underline" }
            };
            bool isStart = false;
            string currentFont = "";
            while (true)
            {
                if (!isStart)
                {
                    currentFont = "None";
                    isStart = true;
                }

                Console.WriteLine($"Параметры надписи: {currentFont}");
                Console.WriteLine("Введите: ");
                foreach(var pairs in repositoryFonts)
                {
                    Console.WriteLine($"{pairs.Key}: {pairs.Value}");
                }
                //проверку на некорректный ввод делать не стал, что б не награмождать
                int.TryParse(Console.ReadLine(), out int res);

                currentFont = repositoryFonts.GetValueOrDefault(res);
            }

        }
    }
}