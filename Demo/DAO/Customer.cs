using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }   //Id is a key word, default PK  or using [Key] notation
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }

        public virtual ICollection<Order> Orders { get; set; } //must be defined virtual 
    }

}
