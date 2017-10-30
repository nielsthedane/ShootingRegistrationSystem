using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class PaymentTypes
    {
        public PaymentTypes()
        {
            this.Shooting = new HashSet<Shooting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shooting> Shooting { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
