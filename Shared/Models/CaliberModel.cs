using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class CaliberModel
    {
        public CaliberModel()
        {
            //this.Shooting = new HashSet<ShootingModel>();
            //this.User = new HashSet<UserModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        //public virtual ICollection<ShootingModel> Shooting { get; set; }

        //public virtual ICollection<UserModel> User { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
