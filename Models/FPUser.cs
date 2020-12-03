using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace moni.Models
{
    public class FPUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "avatar")]
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
        public int HouseholdId { get; set; }

    }
}
