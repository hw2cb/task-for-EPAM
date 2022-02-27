using FileManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    internal class SaveFiles : FileManagementSystem
    {
        //класс отвечает за сохранение файлов, internal, потому что не хочу что бы класс использовался вне библиотеки
        public SaveFiles(string pathToFile) : base(pathToFile)
        {
        }
        public void SaveAll(string pathTo, string pathFrom, DirectoryType directoryType = DirectoryType.Visible)
        {
            //метод может работать как со скрытми папками и файлами, так и с видимыми
            if (!FileManager.VerifyDirectory(pathTo))
                throw new Exception("directory not found");

            //создаю идентичную структуру

            foreach (string dirPath in Directory.GetDirectories(pathFrom, "*", SearchOption.AllDirectories))
            {
                //
                if(directoryType == DirectoryType.Hidden)
                    if (File.GetAttributes(dirPath).HasFlag(FileAttributes.Hidden)) continue;
                FileManager.CreateDirectory(dirPath.Replace(pathFrom, pathTo), directoryType);
            }
                
            //копирую все файлы туда
            foreach (string newPath in Directory.GetFiles(pathFrom, "*.*", SearchOption.AllDirectories))
            {
                if (directoryType == DirectoryType.Hidden)
                    if (File.GetAttributes(newPath).HasFlag(FileAttributes.Hidden)) continue;
                File.Copy(newPath, newPath.Replace(pathFrom, pathTo), true);

                if(directoryType == DirectoryType.Hidden) File.SetAttributes(newPath.Replace(pathFrom, pathTo), FileAttributes.Hidden);
                else File.SetAttributes(newPath.Replace(pathFrom, pathTo), FileAttributes.Normal);
                

            }

        }
    }
}
