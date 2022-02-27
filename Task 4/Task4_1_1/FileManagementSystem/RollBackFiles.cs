using FileManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    public class RollBackFiles : FileManagementSystem
    {
        private SaveFiles _saveFile;

        public delegate void ErrorLoadLog();
        private ErrorLoadLog _errorLoadLog;

        public delegate void ErrorSearchChanges(List<FilesChange> changes);
        private ErrorSearchChanges _errorSearchChanges;

        public delegate void EndRollBack(DateTime startChange, DateTime endChange);
        private EndRollBack _endRollBack;

        private DateTime _dateToRollBack;

        public RollBackFiles(string pathToFile, DateTime dateToRollBack) : base(pathToFile)
        {
            _dateToRollBack = dateToRollBack;
            _saveFile = new SaveFiles(pathToFile);
        }
        public void Start()
        {

            if (_errorLoadLog == null) throw new Exception("its necessary to subscribe to the delegate that handles error of loading the log! Use RegisterOnErrorLoadLog()");
            if (_errorSearchChanges == null) throw new Exception("its necessary to subscribe to the delegate that handles error of loading the log! Use RegisterOnErrorSearchChanges()");
            if (_endRollBack == null) throw new Exception("its necessary to subscribe to the delegate that handles error of loading the log! Use RegisterOnEndRollBack()");
            //если изменений нет, вызовем метод, который подпишет клиентский код для ошибки
            //второй вариант выкидывать кастомную ошибку, что бы ее обрабатывал клиентский код
            if (!LoadLogs()) _errorLoadLog();

            FilesChange change = SearchChange();
            if (change == null)
            {
                //если изменение не найдено, то выведу список всех изменений и дам возможность пользователю увидеть время изменений
                //костыль, так как в тз указано искать изменения по тем данным, которые введет пользователь. При первом запуске, сохраняется текущая директория
                //и промежуток времени сохранения пару секунд, естественно пользователь не сможет ввести время, дабы попасть в этот промежуток.
                //проще было сделать вывод всех изменений пользователю и возможность выбрать куда откатиться, но тз есть тз

                List<FilesChange> copyChanges = new List<FilesChange>();
                copyChanges.AddRange(_changeToLog);

                _errorSearchChanges(copyChanges);
            }
            else
                StartRollBack(change);
            
        }
        private void StartRollBack(FilesChange change)
        {
            Console.WriteLine($"DEBUG: {change.Id}, start:{change.StartChange}, end:{change.EndChange}");
            //здесь нужно удалить все файлы из директории и скопировать туда нужные
            FileManager.DeleteDirectoriesAndFiles(_pathToDirectory);
            //теперь нужно перекопировать все нужные файлы из нужной папки Guid
            _saveFile.SaveAll(_pathToDirectory, change.PathTo, DirectoryType.Visible);
            _endRollBack(change.StartChange, change.EndChange);
        }
        private FilesChange SearchChange()
        {
            FilesChange change = null;

            for(int i=0; i<_changeToLog.Count; i++)
            {
                if(_dateToRollBack >=_changeToLog[i].StartChange && _dateToRollBack <= _changeToLog[i].EndChange)
                {
                    change = _changeToLog[i];
                }
            }
            return change;

        }
        public void RegisterOnErrorLoadLog(ErrorLoadLog errorLoadLog)
        {
            if (errorLoadLog == null) throw new ArgumentNullException("method should be not null");
            _errorLoadLog = errorLoadLog;
        }
        public void RegisterOnErrorSearchChanges(ErrorSearchChanges errorSearchChanges)
        {
            if (errorSearchChanges == null) throw new ArgumentNullException("method should be not null");
            _errorSearchChanges = errorSearchChanges;
        }
        public void RegisterOnEndRollbBack(EndRollBack endRollBack)
        {
            if (endRollBack == null) throw new ArgumentNullException("method should be not null");
            _endRollBack = endRollBack;
        }

    }
}
