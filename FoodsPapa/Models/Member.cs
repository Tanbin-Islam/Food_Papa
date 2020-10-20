using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class Member
    {[Key]
        public int MemberId { get; set; }
        [Required, StringLength(50)]
        public string MemberName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(500)]
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Image { get; set; }
    
    }
}
