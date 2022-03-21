using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementSystem;
using FileManagementSystem.Enums;
using FileManagementSystem.Models;

namespace Task4_1_1
{
    internal sealed class Startup
    {


        public static void Run()
        {

            while(Configuration.WorkMode == WorkMode.None)
            {
                StartConfiguration();
                switch(Configuration.WorkMode)
                {
                    case WorkMode.Observ:
                        StartObservMode();
                        break;
                    case WorkMode.Rollback:
                        StartRollBackMode();
                        break;
                    default: continue;
                }
            }
        }
        private static void StartObservMode()
        {
            ObservFiles observ = new ObservFiles(Configuration.PathToDirectory);
            observ.RegisterOnEndObserv(SelectTypeSave);
            observ.RegisterOnDisagree(Restart);
            observ.Start();
        }
        private static void StartRollBackMode()
        {
            DateTime dt = ConsoleUI.ReadDateTime();
            RollBackFiles rollBack = new RollBackFiles(Configuration.PathToDirectory, dt);
            rollBack.RegisterOnErrorLoadLog(ErrorLoadLog);
            rollBack.RegisterOnErrorSearchChanges(ErrorSearchChanges);
            rollBack.RegisterOnEndRollbBack(SuccessRollBack);
            rollBack.Start();

        }
        private static void SuccessRollBack(DateTime startChange, DateTime endChange)
        {
            ConsoleUI.PrintSuccessRollBack(startChange, endChange);
            Restart();
        }
        private static void ErrorSearchChanges(List<FilesChange> changes)
        {
            ConsoleUI.PrintDetailChanges(changes);
            Restart();
        }
        private static void ErrorLoadLog()
        {
            ConsoleUI.PrintNoLogs();
            Restart();
        }
        private static void Restart()
        {
            Configuration.WorkMode = WorkMode.None;
            Run();
        }
        private static ChoiceType SelectTypeSave(List<Changes> changes)
        {
            //метод для события, выбор пользователя, сохранять изменения или нет 
            ConsoleUI.PrintChanges(changes);
            int selectNumber = ConsoleUI.ReadAction();
            switch(selectNumber)
            {
                case 1: return ChoiceType.AgreeChanges;
                case 2: return ChoiceType.DisagreeChanges;
                default: return ChoiceType.None;
            }
        }
        private static void StartConfiguration()
        {
            Configuration.PathToDirectory = ConsoleUI.ReadPath();
            int numberMode = ConsoleUI.ReadWorkMode();
            //не знаю точно где реализовать выбор режима, в классе ConsoleUI (он отвечает за консольный ввод-вывод), здесь или
            //вообще передавать самому классу FileManager ключ в виде int и он уже сам определит
            switch (numberMode)
            {
                case 1:
                    Configuration.WorkMode = WorkMode.Observ;
                    break;
                case 2:
                    Configuration.WorkMode = WorkMode.Rollback;
                    break;
                case 3:
                    Configuration.WorkMode = WorkMode.None;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(numberMode));
            }
        }
    }
}
