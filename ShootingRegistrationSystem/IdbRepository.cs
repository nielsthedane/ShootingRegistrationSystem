using System.Collections.Generic;
using Shared.Models;

namespace DAL
{
    public interface IdbRepository
    {
        void addNewShooting(UserModel user, ShootingTypesModel shootingType, PaymentTypesModel paymentType,
            CaliberModel caliber);

        void changeShootsOnShooting(int shoots, int shootingId);
        void startStopShooting(ShootingModel shootingModel);
        void addNewUser(UserModel userModel);
        IEnumerable<CaliberModel> getAllCalibers();
        IEnumerable<ShootingModel> GetAllShootings();
        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<ShootingTypesModel> GetAllShootingTypes();
        IEnumerable<PaymentTypesModel> GetAllPaymentTypes();
        IEnumerable<CaliberModel> GetAllCaliberTypes();
        UserModel GetUserById(int userId);
    }
}