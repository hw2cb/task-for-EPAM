using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAwardsBLL
    {
        Award AddAward(string title, string pathToPhoto);
        void RemoveAward(Guid Id);
        void EditAward(Guid id, string title);
        IEnumerable<Award> GetAwards();
        Award GetAward(Guid id);
        void SetPhoto(Guid id, string path);
    }
}
