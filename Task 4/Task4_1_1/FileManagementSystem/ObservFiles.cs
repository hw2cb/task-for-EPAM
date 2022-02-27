using FileManagementSystem.Enums;
using FileManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    public class ObservFiles : FileManagementSystem
    {
        //класс отвечает за отслеживание изменений файлов
        //при изменении, должна сохраниться старая копия файлов в скрытую папку, с название Guid
        //при созданиие экземпляра объекта, должна создаваться скрытая папка, в ней лог
        //в логе будут сохраняться время изменений и гуид (в виде json)
        private SaveFiles _saveFile;
        public delegate ChoiceType EndObserv(List<Changes> changes);
        private EndObserv _endObserv;

        public delegate void Restart();
        private Restart _restart;
        private bool isChanged;

        private DateTime StartObserv;

        public ObservFiles(string pathToFile) : base(pathToFile)
        {
            _saveFile = new SaveFiles(pathToFile);
            isChanged = false;
        }
        public void Start()
        {
            //если логов или системной папки нет, значит в этой директории нет изменений и система отслеживания запущена в первый раз!
            if (!FileManager.VerifyFile(_pathToLog) || !FileManager.VerifyDirectory(_pathToSystemFolder))
            {
                InitStartTime();
                //запускаю начало настройки (при первом запуске программы, создадутся необходимые файлы и папки)
                StartSettings();
                //создаю копию текущей директории (можно было сделать буферную директорию, копировать туда на время текущую
                //и если изменения произойдут, сохранять буферную и новую измененную, но я сделал просто сохранение при каждом запуске)
                Thread.Sleep(TimeSpan.FromSeconds(1));
                SaveChanges();
            }
            else
            {
                //подгружаем логи в объект, что бы добавить новое изменение и снова засериализовать
                LoadLogs();
                InitStartTime();
            }

            Run();

        }
        private void SaveChanges()
        {
            /* Метод сохраняет текущее состояние директории в специальную папку, в которой создается папка с Guid
             */

            FilesChange fc = new FilesChange(_pathToSystemFolder, StartObserv);
            //создаю папку с именем Guid, где будет распологаться текущая директория
            string pathToSpecialGuidFolder = fc.PathTo;
            FileManager.CreateDirectory(pathToSpecialGuidFolder, DirectoryType.Hidden);
            //сохраняю директорию
            _saveFile.SaveAll(pathToSpecialGuidFolder, _pathToDirectory, DirectoryType.Hidden);


            //записываю все логи
            _changeToLog.Add(fc);
            FileManager.WriteAllFileText(_pathToLog, JsonConvert.SerializeObject(_changeToLog));
            InitStartTime();

        }
        private void InitStartTime()
        {
            //для удобства отката, секунды ставлю на 0
            if (_changeToLog.LastOrDefault() == null || _changeToLog.Count == 0) StartObserv = new DateTime(DateTime.Now.Year, 
                DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            else
                StartObserv = _changeToLog.LastOrDefault().EndChange;
        }
        public void RegisterOnEndObserv(EndObserv endObserv)
        {
            if (endObserv == null) throw new ArgumentNullException("method should be not null");
            _endObserv = endObserv;
        }
        public void RegisterOnDisagree(Restart restart)
        {
            if (restart == null) throw new ArgumentNullException("method should be not null");
            _restart = restart;
        }
        private void Run()
        {
            //стандартный пример из msdn
            using var watcher = new FileSystemWatcher(_pathToDirectory);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Нажми enter для выхода из режима наблюдения!");
            Console.ReadLine();
            //

            if (_restart == null) throw new Exception("delegate Restart should be not null");
            if(_endObserv == null) throw new Exception("delegate EndObserv should be not null");
            //если изменений не сделано, то просто рестартаю
            if (isChanged == false) 
                _restart();
            else
            {
                //если изменения все таки были сделаны, то вызываю делегат, на который подписался клиентский код и ожидаю получить выбор сохранить изменения или нет
                ChoiceType selectUser = _endObserv(_changes);
                switch (selectUser)
                {
                    case ChoiceType.AgreeChanges:
                        SaveChanges();
                        _restart();
                        break;
                    case ChoiceType.DisagreeChanges:
                        _restart();
                        break;
                    default: throw new ArgumentException("Choice should be AgreeChanges or DisagreeChanges");
                }
            }
        }
        private void AtChange(DateTime dateTime, string fullPath, ChangeType changeType, string oldPath = "")
        {
            if (isChanged != true) isChanged = true;

            string strForOldPath = "";
            if (oldPath != "")
                strForOldPath = $"old path: {oldPath}";

            _changes.Add(new Changes(dateTime, fullPath, changeType.ToString() + $"{strForOldPath}"));
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            AtChange(DateTime.Now, e.FullPath, ChangeType.Change);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            AtChange(DateTime.Now, e.FullPath, ChangeType.Created);

        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            AtChange(DateTime.Now, e.FullPath, ChangeType.Deleted);
        }


        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            AtChange(DateTime.Now, e.FullPath, ChangeType.Rename, e.OldFullPath);
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }


    }
}
