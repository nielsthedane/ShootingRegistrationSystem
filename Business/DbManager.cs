using System.Collections.Generic;
using Shared.Models;
using DAL;

namespace Business
{
    public class DbManager : IdbManager
    {

        public static void startAutoMapper()
        {
            DbRepository.startAutoMapper();
        }

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

        public void changeShootsOnShooting(int shoots, int shootingId)
        {
            dbRepository.changeShootsOnShooting(shoots, shootingId);
        }

        public void startStopShooting(ShootingModel shootingModel)
        {
            dbRepository.startStopShooting(shootingModel);
        }

        public void addNewUser(UserModel userModel)
        {
            dbRepository.addNewUser(userModel);
        }

        public IEnumerable<CaliberModel> getAllCalibers()
        {
            return dbRepository.getAllCalibers();
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