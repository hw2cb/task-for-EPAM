
using Task2_2_1;

namespace Tasks2_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameField field = new GameField(40, 30, 20, 4);
            Game game = new Game(field);
            game.Start();

        }

    }
}