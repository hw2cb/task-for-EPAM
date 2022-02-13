using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2
{
    internal sealed class CommandHandler
    {
        private static int currentFunctionNumber;
        public static bool IsStart { get; private set; }

        public static void EnterSelectAction()
        {
            if(!SD.IsLogIn)
            {
                SD.LogInUI();
                GraphEditor.LogIn();
            }
            SD.HeadMenuUI();
            IsStart = false;
            if(int.TryParse(Console.ReadLine(), out currentFunctionNumber) && (currentFunctionNumber <= 0 || currentFunctionNumber < 6))
            {
                IsStart = true;
                Handler();
            }
        }
        public static int EnterSelectFigure()
        {
            bool flag = false;
            int numberFigure = -1;

            numberFigure = SD.EnterValueMenuValidator(GraphEditor.CountFigures);

            return numberFigure;
        }
        private static void Handler()
        {
            switch(currentFunctionNumber)
            {
                case 1:
                    GraphEditor.SelectFigure();
                    break;
                case 2:
                    GraphEditor.ShowFigures();
                    break;
                case 3:
                    GraphEditor.CleanFigures();
                    break;
                case 4:
                    GraphEditor.LogOut();
                    break;
                case 5:
                    GraphEditor.ChangeUser();
                    break;
            }
        }
    }
}
