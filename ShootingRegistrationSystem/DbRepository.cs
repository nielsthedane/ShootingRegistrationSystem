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
        public static void startAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Shooting, ShootingModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Caliber, CaliberModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<PaymentTypes, PaymentTypesModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<ShootingTypes, ShootingTypesModel>().ReverseMap().PreserveReferences();
            });
            AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();
        }

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

        public void changeShootsOnShooting(int shoots, int shootingId)
        {
            using (var db = new srsDBEntities())
            {
                Shooting shooting = db.Shooting.Where(i => i.Id == shootingId).First();
                shooting.Shoots = shoots;
                db.SaveChanges();

            }
        }

        public void startStopShooting(ShootingModel shootingModel)
        {
            using (var db = new srsDBEntities())
            {
                Shooting shooting = db.Shooting.Where(i => i.Id == shootingModel.Id).FirstOrDefault();
                if (shooting.isDone == true)
                {
                    shooting.isDone = false;
                } else { 
                shooting.isDone = true;
                }
                db.SaveChanges();
            }
        }

        public void addNewUser(UserModel userModel)
        {
            using (var db = new srsDBEntities())
            {
                User newUser = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName
                };

                var calibers = AutoMapper.Mapper.Map<IEnumerable<Caliber>>(userModel.Caliber);

                foreach (Caliber caliber in calibers)
                {
                    newUser.Caliber.Add(db.Caliber.Where(o => o.Name == caliber.Name).FirstOrDefault());
                }

                db.User.Add(newUser);
                db.SaveChanges();
            }
        }

        public IEnumerable<CaliberModel> getAllCalibers()
        {
            using (var db = new srsDBEntities())
            {
                var allCalibers = db.Caliber;
                return AutoMapper.Mapper.Map<IEnumerable<CaliberModel>>(allCalibers);
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