using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }

    }
}
