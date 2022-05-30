using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AwardsManager : IAwardsBLL
    {
        private IAwardsDAL _jsonDAL;
        //TODO: Configuration
        public AwardsManager(IAwardsDAL jsonDAL)
        {
            _jsonDAL = jsonDAL;
        }

        public Award AddAward(string title, string namePhoto)
        {
            Award award = _jsonDAL.AddAward(title);
            SetPhoto(award.Id, namePhoto);
            return award;
        }

        public void EditAward(Guid id, string title)
        {
            _jsonDAL.EditAward(id, title);
        }

        public Award GetAward(Guid id)
        {
            return _jsonDAL.GetAward(id);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _jsonDAL.GetAwards();
        }

        public void RemoveAward(Guid Id)
        {
            _jsonDAL.RemoveAward(Id);
        }

        public void SetPhoto(Guid id, string path)
        {
            _jsonDAL.SetPhoto(id, path);
        }

    }
}
