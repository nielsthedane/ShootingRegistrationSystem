using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.Caliber = new HashSet<CaliberModel>();
            this.Shooting = new HashSet<ShootingModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<CaliberModel> Caliber { get; set; }
        public virtual ICollection<ShootingModel> Shooting { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
