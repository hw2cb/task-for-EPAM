using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAwardsDAL
    {
        Award AddAward(string title);
        void RemoveAward(Guid Id);
        void EditAward(Guid id, string title);
        IEnumerable<Award> GetAwards();
        Award GetAward(Guid id);
        void Save(Award award);
        void SetPhoto(Guid id, string path);
    }
}
