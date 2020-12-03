using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal TargetAmount { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal ActualAmount { get; set; }
    }
}
