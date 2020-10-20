using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodsPapa.Models;
using FoodsPapa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodsPapa.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodDbContext db;
        private readonly IHostingEnvironment host;

        public FoodController(FoodDbContext database, IHostingEnvironment hosting)
        {
            db = database;
            host = hosting;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
          
            var food = db.foods.ToList();
           
            return View(food);
         
        }
        public ViewResult Details(int id)
        {
            Food food = db.foods.FirstOrDefault(e => e.FoodId == id);
            return View(food);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Picture != null)
                {
                    string ext = Path.GetExtension(vm.Picture.FileName);
                    string uniqueFileName = Guid.NewGuid().ToString() + ext;
                    string staticPath = Path.Combine("Images", uniqueFileName);
                    string aPath = Path.Combine(host.WebRootPath, staticPath);

                    vm.Picture.CopyTo(new FileStream(aPath, FileMode.Create));

                    Food objFood = new Food
                    {
                        FoodName = vm.FoodName,
                        Type = vm.Type,
                        CodeNumber = vm.CodeNumber,
                        Price = vm.Price,
                        Picture = staticPath
                    };


                    db.foods.Add(objFood);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Edit(int id)
        {

            var vm = db.foods.FirstOrDefault(x => x.FoodId == id);
            FoodVM objFood = new FoodVM
            {
                FoodId = vm.FoodId,
                FoodName=vm.FoodName,
                Type = vm.Type,
                CodeNumber = vm.CodeNumber,
                Price = vm.Price,
                PicturePath = vm.Picture
            };
            return View(objFood);
        }


        [HttpPost]
        public IActionResult Edit(FoodVM vm)
        {
            if (ModelState.IsValid)
            {
                string staticPath = vm.PicturePath;

                if (vm.Picture != null)
                {
                    string ext = Path.GetExtension(vm.Picture.FileName);
                    string uniqueFileName = Guid.NewGuid().ToString() + ext;
                    staticPath = Path.Combine("Images", uniqueFileName);
                    string aPath = Path.Combine(host.WebRootPath, staticPath);

                    vm.Picture.CopyTo(new FileStream(aPath, FileMode.Create));

                    Food objFood = new Food
                    {
                        FoodId = vm.FoodId,
                        FoodName=vm.FoodName,
                        Type = vm.Type,
                        CodeNumber = vm.CodeNumber,
                        Price = vm.Price,
                        Picture = staticPath
                    };


                    db.Entry(objFood).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {

                    Food objFood = new Food
                    {
                        FoodId = vm.FoodId,
                        FoodName=vm.FoodName,
                        Type = vm.Type,
                        CodeNumber = vm.CodeNumber,
                        Price = vm.Price,
                        Picture = staticPath

                    };


                    db.Entry(objFood).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Delete(int id)
        {

            var vm = db.foods.FirstOrDefault(x => x.FoodId == id);
            db.foods.Remove(vm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}