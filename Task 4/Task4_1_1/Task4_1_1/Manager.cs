using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task4_1_1
{
    internal class Manager
    {
        //клаасс отвечающий за работу с файлами
        public static bool Verify(string path)
        {
            return Directory.Exists(path);
        }
    }
}
