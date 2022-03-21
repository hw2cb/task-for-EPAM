using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementSystem.Enums;

namespace FileManagementSystem
{
    public class Configuration
    {
        public static WorkMode WorkMode { get; set; } = WorkMode.None;
        public static string PathToDirectory { get; set; } = String.Empty;
    }
}
