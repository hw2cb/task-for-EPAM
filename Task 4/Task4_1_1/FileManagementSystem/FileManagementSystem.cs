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
    public abstract class FileManagementSystem
    {
        protected string _pathToDirectory;
        protected const string nameSystemFolder = "FMS";
        protected string _pathToSystemFolder;
        protected string _pathToLog;
        protected List<Changes> _changes;
        protected List<FilesChange> _changeToLog;
        
        public FileManagementSystem(string pathToFile)
        {
            _pathToDirectory = pathToFile;
            _pathToSystemFolder = Path.Combine(_pathToDirectory, nameSystemFolder);
            _pathToLog = Path.Combine(_pathToSystemFolder, "logChanges.json");
            _changes = new List<Changes>();
            _changeToLog = new List<FilesChange>();
        }
        public void StartSettings()
        {
            if (!FileManager.VerifyDirectory(_pathToDirectory))
                throw new Exception("directory not found");
            //создание папки хранилища
            if (!FileManager.VerifyDirectory(_pathToSystemFolder))
            {
                Console.WriteLine($"[DEBUG]: Создание папки-хранилища: {_pathToSystemFolder}");
                FileManager.CreateDirectory(_pathToSystemFolder, DirectoryType.Hidden);
            }
            //создание файла логов
            if (!FileManager.VerifyFile(_pathToLog))
                FileManager.CreateFile(_pathToLog, FileType.Hidden);
        }

        public bool LoadLogs()
        {
            if (!FileManager.VerifyFile(_pathToLog))
                return false;

            string jsonText = FileManager.ReadAllFileText(_pathToLog);
            var changesWithLog = JsonConvert.DeserializeObject<List<FilesChange>>(jsonText);
            if(changesWithLog != null)
                _changeToLog = changesWithLog;

            if (_changeToLog.Count == 0) return false;
            else return true;
        }
    }
}
