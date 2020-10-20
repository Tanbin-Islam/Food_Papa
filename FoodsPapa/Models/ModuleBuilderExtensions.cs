using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodsPapa.Models
{
    public static class ModuleBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasData(
                new Food { FoodId = 1, FoodName = "IceCream11", Price = 300, Type = FoodType.IceCream, CodeNumber="I-203", Picture ="Images/2a3b1b56-2ebe-4620-a258-1314cff3c33a.jpg" },
                new Food { FoodId = 2, FoodName = "Burger12", Price = 250, Type = FoodType.Chains, CodeNumber = "C-301", Picture = "Images/8d661e11-5b78-4ab9-95e3-3d7b1d7a7cf3.jpg" },
                 new Food { FoodId = 3, FoodName = "Water", Price = 300, Type = FoodType.SoftDrinks, CodeNumber = "W-103", Picture = "Images/2a3b1b56-2ebe-4620-a258-1314cff3c33a.jpg" },
                new Food { FoodId = 4, FoodName = "Indianfood", Price = 250, Type = FoodType.Indian, CodeNumber = "I-401", Picture = "Images/2a3b1b56-2ebe-4620-a258-1314cff3c33a.jpg" }
            );

         
        }


    }
}
