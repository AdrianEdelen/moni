using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models.ViewModels
{
    public class DashboardViewModel
    {
        public FPUser User { get; set; }
        public Household Household { get; set; }
        public List<Category> Category { get; set; }
        
    }
}
