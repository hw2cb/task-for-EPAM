using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;
using Task2_2_1.Barriers;
using Task2_2_1.Bonuses;

namespace Task2_2_1
{
    internal static class Collision
    {

        public static bool IsTouch(GameField gameField, Player player, Direction direction)
        {

            /* 1 - препятствия
             * 2 - враги
             * 3 - кактусы
             * 0 - свободное место
             * 4 - speed
             * 5 - health
             */
            bool flag = false;
            //метод проверяет коснулся ли игрок ограждения
            switch (direction)
            {


                case Direction.Left:
                    //не оопешно, но пока реализовано так
                    if (gameField.Field[player.currentY, player.currentX - 1] == 3)
                    {
                        player.DoDamage(Cactus.Damage);
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY, player.currentX - 1] == 1)
                    {
                        flag = true;
                    }
                    break;
                case Direction.Right:
                    if (gameField.Field[player.currentY, player.currentX + 1] == 3)
                    {
                        player.DoDamage(Cactus.Damage);
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY, player.currentX + 1] == 1)
                    {
                        flag = true;
                    }
                    break;
                case Direction.Up:
                    if (gameField.Field[player.currentY - 1, player.currentX] == 3)
                    {
                        player.DoDamage(Cactus.Damage);
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY - 1, player.currentX] == 1)
                    {
                        flag = true;
                    }
                    break;
                case Direction.Down:
                    if (gameField.Field[player.currentY + 1, player.currentX] == 3)
                    {
                        player.DoDamage(Cactus.Damage);
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY + 1, player.currentX] == 1)
                    {
                        flag = true;
                    }
                    break;
            }
            return flag;
        }
        public static bool IsTouchBonus(GameField gameField, Player player, Direction direction)
        {

            /* 1 - препятствия
             * 2 - враги
             * 3 - кактусы
             * 0 - свободное место
             * 4 - speed
             * 5 - health
             */
            bool flag = false;
            //так как игровое поле реализовано через двумерный массив, пока что создам просто два объекта для инициализации бафов
            //TODO: Обдумать другую реализацию
            Apple apple = new Apple(20);
            Cherry cherry = new Cherry(50);
            //метод проверяет коснулся ли игрок ограждения
            switch (direction)
            {
                case Direction.Left:
                    //не оопешно, но пока реализовано так
                    if (gameField.Field[player.currentY, player.currentX - 1] == 4)
                    {
                        player.SetSpeed(apple.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY, player.currentX - 1] == 5)
                    {
                        player.SetHealth(cherry.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    break;
                case Direction.Right:
                    if (gameField.Field[player.currentY, player.currentX + 1] == 4)
                    {
                        player.SetSpeed(apple.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY, player.currentX + 1] == 5)
                    {
                        player.SetHealth(cherry.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    break;
                case Direction.Up:
                    if (gameField.Field[player.currentY - 1, player.currentX] == 4)
                    {
                        player.SetSpeed(apple.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY - 1, player.currentX] == 5)
                    {
                        player.SetHealth(cherry.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    break;
                case Direction.Down:
                    if (gameField.Field[player.currentY + 1, player.currentX] == 4)
                    {
                        player.SetSpeed(apple.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    else if (gameField.Field[player.currentY + 1, player.currentX] == 5)
                    {
                        player.SetHealth(cherry.Buff);
                        gameField.Bonuses.Pop();
                        flag = true;
                    }
                    break;
            }
            return flag;
        }
    }
}
