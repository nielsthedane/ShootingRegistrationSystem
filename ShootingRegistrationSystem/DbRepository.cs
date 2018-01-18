using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DAL.Mapper;
using Shared.Models;

namespace DAL
{
    public class DbRepository : IdbRepository
    {
        public void addNewShooting(UserModel user, ShootingTypesModel shootingType, PaymentTypesModel paymentType,
            CaliberModel caliber)
        {
            using (var db = new srsDBEntities())
            {
                Shooting newShooting = new Shooting()
                {
                    CreationDate = DateTime.Now,
                    ShootingType = AutoMapper.Mapper.Map<ShootingTypes>(shootingType).Id,
                    PaymentType = AutoMapper.Mapper.Map<PaymentTypes>(paymentType).Id,
                    Caliber = AutoMapper.Mapper.Map<Caliber>(caliber).Id

                };
                var dbUser = db.User.FirstOrDefault(i => i.Id == user.Id);
                dbUser.Shooting.Add(newShooting);
                db.SaveChanges();
            }
        }

        public IEnumerable<ShootingModel> GetAllShootings()
        {
            using (var db = new srsDBEntities())
            {
                var shootings = db.Shooting;
                return AutoMapper.Mapper.Map<IEnumerable<ShootingModel>>(shootings);
            }
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            using (var db = new srsDBEntities())
            {
                var users = db.User;
                return AutoMapper.Mapper.Map<IEnumerable<UserModel>>(users);
            }
        }

        public IEnumerable<ShootingTypesModel> GetAllShootingTypes()
        {
            using (var db = new srsDBEntities())
            {
                var shootingTypes = db.ShootingTypes;
                return AutoMapper.Mapper.Map<IEnumerable<ShootingTypesModel>>(shootingTypes);
            }
        }

        public IEnumerable<PaymentTypesModel> GetAllPaymentTypes()
        {
            using (var db = new srsDBEntities())
            {
                var paymentType = db.PaymentTypes;
                return AutoMapper.Mapper.Map<IEnumerable<PaymentTypesModel>>(paymentType);
            }
        }

        public IEnumerable<CaliberModel> GetAllCaliberTypes()
        {
            using (var db = new srsDBEntities())
            {
                var caliber = db.Caliber;
                return AutoMapper.Mapper.Map<IEnumerable<CaliberModel>>(caliber);
            }
        }

        public UserModel GetUserById(int userId)
        {
            UserModel user = null;
            using (var db = new srsDBEntities())
            {
                User dbUser = db.User.Where(i => i.Id == userId).FirstOrDefault();
                user = AutoMapper.Mapper.Map<UserModel>(dbUser);
                return user;
            }
        }
    }
}