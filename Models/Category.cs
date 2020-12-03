using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
