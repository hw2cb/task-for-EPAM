using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDAL.Abstract
{
    public abstract class JsonDAO
    {
        protected void CheckFileUser(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                $"File not found");
            }
        }
    }
}
