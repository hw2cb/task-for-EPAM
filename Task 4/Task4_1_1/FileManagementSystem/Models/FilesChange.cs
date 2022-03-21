using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    public class FilesChange
    {
        //диапазон изменений
        public DateTime StartChange { get; set; }
        public DateTime EndChange { get; set; }
        //
        public Guid Id { get; set; }
        public string PathTo { get; set; }
        //пустой конструктор для правильной десериализации, иначе обновлял PathTo
        public FilesChange() { }
        public FilesChange(string pathTo, DateTime startObserv)
        {
            
            Id = Guid.NewGuid();
            StartChange = startObserv;
            EndChange = DateTime.Now;
            //EndChange = new DateTime(DateTime.Now.Year,
                //DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            PathTo = Path.Combine(pathTo, Id.ToString());
        }
    }
}
