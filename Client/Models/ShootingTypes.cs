using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class ShootingTypes
    {
      
        public ShootingTypes()
        {
            this.Shooting = new HashSet<Shooting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Shooting> Shooting { get; set; }

        public override string ToString()
        {
            return Name + " Pris: " + Price;
        }
    }
}
