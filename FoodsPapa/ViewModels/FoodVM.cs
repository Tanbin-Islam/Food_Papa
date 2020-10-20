using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public class FoodVM
    {
        [Key]
        public int FoodId { get; set; }
        [Required, StringLength(50)]
        public string FoodName { get; set; }
        public FoodType Type { get; set; }
        public string CodeNumber { get; set; }
        public decimal Price { get; set; }
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
    }
}
