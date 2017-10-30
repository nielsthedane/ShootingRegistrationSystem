using ShootingRegistrationSystem;
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
    }
}
