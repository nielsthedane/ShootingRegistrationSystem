using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using Shared.Models;
using DAL;
using DAL.Mapper;

namespace DAL
{
    public class DbManager : IdbManager
    {

        private static IdbRepository dbRepository;

        public DbManager()
        { 
            dbRepository = new DbRepository();
        }

        public void addNewShooting(UserModel user, ShootingTypesModel shootingType, PaymentTypesModel paymentType,
            CaliberModel caliber)
        {
            dbRepository.addNewShooting(user,shootingType,paymentType,caliber);
        }

        public IEnumerable<ShootingModel> GetAllShootings()
        {
            return dbRepository.GetAllShootings();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return dbRepository.GetAllUsers();
        }

        public IEnumerable<ShootingTypesModel> GetAllShootingTypes()
        {
            return dbRepository.GetAllShootingTypes();
        }

        public IEnumerable<PaymentTypesModel> GetAllPaymentTypes()
        {
            return dbRepository.GetAllPaymentTypes();
        }

        public IEnumerable<CaliberModel> GetAllCaliberTypes()
        {
            return dbRepository.GetAllCaliberTypes();
        }

        public UserModel GetUserById(int userid)
        {
            return dbRepository.GetUserById(userid);
        }


    }
}