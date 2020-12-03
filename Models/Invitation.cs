using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Expires { get; set; }
        public Boolean Accepted { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid Code { get; set; }

    }
}
