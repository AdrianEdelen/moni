using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Greeting { get; set; }
        public DateTimeOffset Established { get; set; }

    }
}
