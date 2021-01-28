using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmerWebAPI.Models;
using FarmerWebAPI.Models.GetModels;
using FarmerWebAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FarmerWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/farmer")]
    public class FarmerController : Controller
    {
        private readonly FarmerDataBaseContext _context;
        private readonly FarmerService _service;

        public FarmerController(FarmerDataBaseContext context)
        {
            _context = context;
            _service = new FarmerService(_context);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addItem")]
        public IActionResult AddVegetableItem([FromForm] GetVegetable v)
        {
            Vegetable veg = new Vegetable();
            veg.Id = 6;
            veg.vegetable_type = v.itemName;
            veg.quantity = v.quantity;
            veg.unit_price = v.unitPrice;
            veg.expired_date = v.expireDate;
            veg.harvest_date = v.harvestDate;

            Boolean id = _service.AddVegetableItems(veg);
            if (id)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetOrders()
        {


            var result = _service.GetOrders();
            return Ok(result);


        }

        [Produces("application/json")]
        [HttpGet("getOrder/{id}")]
        public String GetTaskById(int id)
        {
            return _service.GetOrderByID(id);

        }

        [Produces("application/json")]
        [HttpGet("gettest")]
        public ActionResult Index()

        {

            using (var context = _context)

            {

                List<VegOrder> Employeelist = context.VegOrders.ToList();

            }

            return View();

        }


    }
}
