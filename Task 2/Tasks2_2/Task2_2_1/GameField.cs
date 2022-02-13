using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;
using Task2_2_1.Bonuses;

namespace Task2_2_1
{
    internal class GameField
    {
        public int playerX { get; set; }
        public int playerY { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int[,] Field { get; private set; }
        private int _countBarriers;
        private int _countBonus;
        public Stack<Bonus> Bonuses { get; private set; }

        public GameField(int width, int height, int countBarriers, int countBonus)
        {
            if (width <= 0) throw new ArgumentException("width should be > 0");
            if (height <= 0) throw new ArgumentException("width should be > 0");
            if (countBarriers <= 0) throw new ArgumentException("countbarriers should be >0");
            Width = width;
            Height = height;
            playerX = 0;
            playerY = 1;
            _countBarriers = countBarriers;
            _countBonus = countBonus;
            Bonuses = new Stack<Bonus>();
            GenerateGameField();
        }
        public void GenerateGameField()
        {
            //генерация игровой карты
            /* 1 - препятствия
             * 2 - враги
             * 3 - препятсвия с уроном
             * 0 - свободное место
             * 
             * 
             */
            Field = new int[Height, Width];
           

            //генерирую границы (кактусы) в массив
            GenerateBorder();
            //генерация препятствий с уроном
            GenerateBarrier(BarrierOption.Damage);
            //генерация препятствий без урона
            GenerateBarrier(BarrierOption.NotDamage);
            GenerateBonus(BonusOption.Health);
            GenerateBonus(BonusOption.Speed);
            

        }
        //27 28 29
        public void GenerateBorder()
        {
            //генерация границ игрового поля в массив
            for (int i = 0; i <Width; i++)
            {
                //с 4 потому что худ оставляем пустым
                Field[4, i] = 3;
                Field[Height-1, i] = 3;

            }
            for (int i = 4; i < Height; i++)
            {
                //с 4 потому что худ оставляем пустым
                Field[i, 0] = 3;
                Field[i, Width-1] = 3;
            }
        }

        public void DEBUG_OUT()
        {
            //дебаг вывод на консоль массив поля
            for(int i = 0; i < Height; i++)
            {
                for(int j=0; j < Width; j++)
                {
                    Console.Write($"{Field[i, j]}");
                }
            }
        }
        public void GenerateBarrier(BarrierOption barrierOption)
        {
            //генерация рандомных препятствий с уроном
            //площадь поля 1200



            Random rand = new Random();
            for (int i = 0; i < _countBarriers; i++)
            {
                //поставил такие значения, что бы не попасть в игрока
                // -2 что бы не закрасить границы
                int indexBarrierX = rand.Next(5, Height-2);
                int indexBarrierY = rand.Next(5, Width - 2);

                //простенькая проверка на то, занята ли клетка

                if(Field[indexBarrierX, indexBarrierY] != 0)
                {
                    //рандомим дальше
                    indexBarrierX = rand.Next(5, Height - 2);
                    indexBarrierY = rand.Next(5, Width - 2);
                }

                if(barrierOption == BarrierOption.Damage)
                {
                    //Cactus
                    Field[indexBarrierX, indexBarrierY] = 3;
                }
                else
                {
                    //Stone
                    Field[indexBarrierX, indexBarrierY] = 1;
                }
                

            }
        }
        public void GenerateBonus(BonusOption bonusOption)
        {
            /* 1 - препятствия
             * 2 - враги
             * 3 - кактусы
             * 0 - свободное место
             * 4 - BonusSpeed
             * 5 - BonusHealth
             */
            Random rand = new Random();
            for (int i = 0; i < _countBonus; i++)
            {
                //поставил такие значения, что бы не попасть в игрока
                // -2 что бы не закрасить границы
                int indexBarrierX = rand.Next(5, Height - 2);
                int indexBarrierY = rand.Next(5, Width - 2);

                //простенькая проверка на то, занята ли клетка

                if (Field[indexBarrierX, indexBarrierY] != 0)
                {
                    //рандомим дальше
                    indexBarrierX = rand.Next(5, Height - 2);
                    indexBarrierY = rand.Next(5, Width - 2);
                }

                if (bonusOption == BonusOption.Health)
                {
                    //бонусы с мувспидом
                    Field[indexBarrierX, indexBarrierY] = 4;
                    Apple apple = new Apple(100);
                    Bonuses.Push(apple);
                }
                else if(bonusOption == BonusOption.Speed)
                {
                    //бонусы с хп
                    Field[indexBarrierX, indexBarrierY] = 5;
                    Cherry cherry = new Cherry(100);
                    Bonuses.Push(cherry);
                }


            }
        }
        
    }
    enum BarrierOption
    {
        Damage,
        NotDamage
    }
    enum BonusOption
    {
        Health,
        Speed
    }
}
