using FileManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    internal class FileManager
    {
        //класс отвечает за работу с файловой системой
        public static void CreateDirectory(string path, DirectoryType directoryType = DirectoryType.Visible)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            if(directoryType == DirectoryType.Hidden)
            {
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            
        }
        public static void CreateFile(string path, FileType fileType = FileType.Visible)
        {
            File.Create(path).Close();
            if(fileType == FileType.Hidden)
                File.SetAttributes(path, FileAttributes.Hidden);
        }
        public static bool VerifyDirectory(string path) => Directory.Exists(path);
        public static bool VerifyFile(string path) => File.Exists(path);

        public static void WriteAllFileText(string path, string content)
        {
            //скрытые файлы не хочет записывать, поэтому пришлось костылить это, что б метод оставался рабочим и для не скрытых файлов
            if (!VerifyFile(path)) throw new FileNotFoundException("file not found");

            bool flag = false;
            if (File.GetAttributes(path) == FileAttributes.Hidden)
            {
                File.SetAttributes(path, FileAttributes.Normal);
                flag = true;
            }
            File.WriteAllText(path, content);
            if(flag) File.SetAttributes(path, FileAttributes.Hidden);
        }
        public static string ReadAllFileText(string path)
        {
            if (!VerifyFile(path)) throw new FileNotFoundException("file not found");

            //скрытые файлы не хочет читать, поэтому пришлось костылить это
            bool flag = false;
            if (File.GetAttributes(path) == FileAttributes.Hidden)
            {
                File.SetAttributes(path, FileAttributes.Normal);
                flag = true;
            }

            File.SetAttributes(path, FileAttributes.Normal);
            string result = File.ReadAllText(path);
            if (flag) File.SetAttributes(path, FileAttributes.Hidden);
            return result;
        }
        public static void DeleteDirectoriesAndFiles(string path)
        {
            if (!VerifyDirectory(path)) throw new DirectoryNotFoundException("directory not found");

            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diA = di.GetDirectories();
            FileInfo[] fi = di.GetFiles();
            foreach (FileInfo f in fi)
            {
                if (f.Attributes == FileAttributes.Hidden) continue;
                f.Delete();
            }
            foreach (DirectoryInfo df in diA)
            {
                if(df.Attributes == (FileAttributes.Hidden|FileAttributes.Directory)) continue;
                DeleteDirectoriesAndFiles(df.FullName);
            }
            if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0)
                di.Delete();
                



        }

    }
}
