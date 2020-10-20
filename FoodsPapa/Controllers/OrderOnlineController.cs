using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodsPapa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodsPapa.Controllers
{
    public class OrderOnlineController : Controller
    {
        private readonly FoodDbContext _entities;

        public OrderOnlineController(FoodDbContext context)
        {
            _entities = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult OrderList()
        {
            var data = _entities.orderOnlines.ToList();

            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        public JsonResult AddOrder([FromBody]OrderOnline order)
        {
            var o = order;
            _entities.orderOnlines.Add(order);
            _entities.SaveChanges();
            var p = _entities.orderOnlines.ToList();
            return Json(p, new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
        public JsonResult UpdateOrder([FromBody]OrderOnline order)
        {
            var odr = _entities.orderOnlines.FirstOrDefault(x => x.OrderId == order.OrderId); /* modify */
            odr.CustomerName = order.CustomerName;
            odr.Address = order.Address;
            odr.Phone = order.Phone;
            odr.Type = order.Type;
            odr.FoodCode = order.FoodCode;
            _entities.Entry(odr).State = EntityState.Modified; /* add */
            _entities.SaveChanges();
            var o = _entities.orderOnlines.ToList(); /*add */
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());


        }

        public string DeleteOrder(int? id)
        {
            var data = _entities.orderOnlines
                   .Where(x => x.OrderId == id)
                   .Select(x => x)
                   .FirstOrDefault();

            if (data != null)
            {
                _entities.orderOnlines.Remove(data);
                _entities.SaveChanges();
            }

            return "Delete Success full";
        }
    }
}