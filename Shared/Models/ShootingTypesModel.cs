using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ShootingTypesModel
    {
      
        public ShootingTypesModel()
        {
            //this.Shooting = new HashSet<ShootingModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //public virtual ICollection<ShootingModel> Shooting { get; set; }

        public override string ToString()
        {
            return Name + " Pris: " + Price;
        }
    }
}
