using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmerWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmerWebAPI.Service
{
    public class FarmerService 
    {
        private readonly FarmerRepository _service;


        private readonly FarmerDataBaseContext _context;

        public FarmerService(FarmerDataBaseContext context)
        {
            _context = context;
            _service = new FarmerRepository(_context);
        }

        public Boolean AddVegetableItems(Vegetable v)
        {
            return _service.AddVegetableItems(v);
        }

        public IEnumerable<VegOrder> GetOrders()
        {

            return _service.GetOrders();

        }
        public String GetOrderByID(int id)
        {
            return _service.GerOrderByID(id);

        }


    }
}
