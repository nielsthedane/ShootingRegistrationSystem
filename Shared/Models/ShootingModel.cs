using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Models
{
    public class ShootingModel
    {
        public ShootingModel()
        {
            this.User = new HashSet<UserModel>();
        }

        public int Id { get; set; }
        public int ShootingType { get; set; }
        public Nullable<int> Shoots { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int PaymentType { get; set; }
        public int Caliber { get; set; }
        public bool isDone { get; set; }

        public virtual CaliberModel Caliber1 { get; set; }
        public virtual PaymentTypesModel PaymentTypes { get; set; }
        public virtual ShootingTypesModel ShootingTypes { get; set; }
        public virtual ICollection<UserModel> User { get; set; }

        public override string ToString()
        {
            var user = User.FirstOrDefault();
            return user.FirstName + " " + user.LastName;
        }
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
