using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class OrderOnline
    {[Key]
        public int OrderId { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [Required, StringLength(500)]
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Type {get; set; }
        public string FoodCode { get; set; }
      
    }
}
