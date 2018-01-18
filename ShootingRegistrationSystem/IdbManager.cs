using System.Collections.Generic;
using Shared.Models;

namespace DAL
{
    public interface IdbManager
    {
        void addNewShooting(UserModel user, ShootingTypesModel shootingType, PaymentTypesModel paymentType,
            CaliberModel caliber);

        IEnumerable<ShootingModel> GetAllShootings();
        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<ShootingTypesModel> GetAllShootingTypes();
        IEnumerable<PaymentTypesModel> GetAllPaymentTypes();
        IEnumerable<CaliberModel> GetAllCaliberTypes();
        UserModel GetUserById(int userId);
    }
}