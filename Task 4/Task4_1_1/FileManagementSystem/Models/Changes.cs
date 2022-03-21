using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Models
{
    public class Changes
    {
        //модель текущих изменений, после выхода из режима наблюдения, происходит уведомление об измененных файлах и выбор сохранять ли
        public DateTime DateTime { get; }
        public string FullPathChangesFile { get; }
        public string TypeChange { get; }
        public Changes(DateTime dateTime, string fullPathToChangesFile, string typeChange)
        {
            DateTime = dateTime;
            FullPathChangesFile = fullPathToChangesFile;
            TypeChange = typeChange;
        }
        public override string ToString()
        {
            return $"{DateTime.TimeOfDay}, file change: {FullPathChangesFile}, type change: {TypeChange}";
        }
    }
}
