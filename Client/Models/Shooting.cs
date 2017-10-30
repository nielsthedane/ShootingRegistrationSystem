﻿using ShootingRegistrationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class Shooting
    {
        public Shooting()
        {
            this.User = new HashSet<User>();
        }

        public int Id { get; set; }
        public int ShootingType { get; set; }
        public Nullable<int> Shoots { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int PaymentType { get; set; }
        public int Caliber { get; set; }

        public virtual Caliber Caliber1 { get; set; }
        public virtual PaymentTypes PaymentTypes { get; set; }
        public virtual ShootingTypes ShootingTypes { get; set; }
        public virtual ICollection<User> User { get; set; }

        
        //public override string ToString()
        //{
        //    User user = new User();
        //    Shooting shooting = new Shooting();
        //    ShootingTypes shootingType = new ShootingTypes();

        //    using (var db = new srsDBEntities())
        //    {
        //        shooting = db.Shooting.Where(i => i.Id == this.Id).FirstOrDefault();
        //        int userId = shooting.User.First().Id;
        //        user = db.User.Where(i => i.Id == userId).FirstOrDefault();
        //        shootingType = db.ShootingTypes.Where(k => k.Id == shooting.ShootingType).FirstOrDefault();
        //    }
        //    return "Navn: " + user.FirstName + "  " + user.LastName + " Skydning: " + shootingType.Name + " Startet: " + CreationDate;
        //}
        
    }
}
