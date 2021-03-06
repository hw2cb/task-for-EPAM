using BLL;
using BLL.Interfaces;
using DAL.Interfaces;
using JsonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;
        public static DependencyResolver Instance {
            get
            {
                if(_instance == null)
                    return new DependencyResolver();
                return _instance;
            }
        }
        private DependencyResolver()
        {

        }

        private IUsersDAL _userDao;
        public IUsersDAL UsersDao
        {
            get
            {
                if (_userDao == null)
                    _userDao = new JsonUsersDAO(AwardsDao);
                return _userDao;
            }
        }

        private IUsersDAL _userDaoSql;
        public IUsersDAL UsersDaoSql
        {
            get
            {
                if (_userDaoSql == null)
                    _userDaoSql = new SqlUsersDAO();
                return _userDaoSql;
            }
        }

        private IAwardsDAL _awardsDao;
        public IAwardsDAL AwardsDao
        {
            get
            {
                if (_awardsDao == null)
                    _awardsDao = new JsonAwardsDAO();
                return _awardsDao;
            }
        }


        private IUsersBLL _usersBLL;
        public IUsersBLL UsersBLL
        {
            get
            {
                if (_usersBLL == null)
                    _usersBLL = new UsersManager(UsersDao);
                    //_usersBLL = new UsersManager(UsersDaoSql);
                return _usersBLL;
            }
        }
        private IAwardsBLL _awardsBLL;
        public IAwardsBLL AwardsBLL
        {
            get
            {
                if (_awardsBLL == null)
                    _awardsBLL = new AwardsManager(AwardsDao);
                return _awardsBLL;
            }
        }
        private IAuthBLL _authBLL;
        public IAuthBLL AuthBLL
        {
            get
            {
                if (_authBLL == null)
                    _authBLL = new Auth(UsersBLL, UsersDao);
                return _authBLL;
            }
        }


    }
}
