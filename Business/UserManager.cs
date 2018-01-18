using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using Shared.Models;
using DAL;
using DAL.Mapper;

namespace Business
{
    public class UserManager : IUserManager
    {
        //private static IUserManager instance;

        private static UserRepository userRepository;

        public UserManager()
        { 
            runConfig();
            userRepository = new UserRepository();
        }

        public void runConfig()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
            });
        }

        //public static IUserManager Instance()
        //{
        //    if (instance == null && userRepository == null)
        //    {
        //        instance = new UserManager();
        //        userRepository = new UserRepository();
        //    }
        //    return instance;
        //}

        public UserModel GetUserById(int userid)
        {
            return userRepository.GetUserById(userid);
        }


        IEnumerable<UserModel> IUserManager.GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}