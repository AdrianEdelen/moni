using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CategoryItemId { get; set; }
        public int BankAccountId { get; set; }
        public string PortalUserId { get; set; }
        public DateTimeOffset Created { get; set; }
        public int Type { get; set; }
        public string Memo { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Amount { get; set; }
        public Boolean IsDeleted { get; set; }


    }
}
