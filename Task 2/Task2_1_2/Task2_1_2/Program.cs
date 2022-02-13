/*Task 2.1.2
 * CUSTOM PAINT
 * 
 */

using Task2_1_2;
using Task2_1_2.Figure;

namespace Tasks2_2
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            //Для того, что бы можно было легко добавить новую фигуру и не писать кучу строчек кода для каждой фигуры (выбор фигуры в консоли, ее параметры и тд)
            //не придумал как реализовать это по другому
            Configuration.AddFigures(new Circle(), new Line(), new Rectangle(), new Ring(), new Square(), new Triangle())
                .Run();

        }
    }
}