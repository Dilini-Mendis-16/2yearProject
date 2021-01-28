using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmerWebAPI.Models.GetModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmerWebAPI.Models
{
    public class FarmerRepository 
    {
        private readonly FarmerDataBaseContext _context;
        public FarmerRepository(FarmerDataBaseContext context)
        {
            _context = context;
        }

        public Boolean AddVegetableItems(Vegetable veg)
        {
            try
            {
                _context.Vegetables.Add(veg);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<VegOrder> GetOrders()
        {
            List<VegOrder> test = _context.VegOrders.ToList();
                /*.Where(e => e.Is_active == 1 )
              .ToList();**/
            return test;

        }

        public String GerOrderByID(int id)
        {



            var test = _context.VegOrders
                .Where(et => et.Order_id == id)
                .Select(et => et.Order_name)
                .FirstOrDefault();
            return test;

        }

        public static implicit operator FarmerRepository(FarmerDataBaseContext v)
        {
            throw new NotImplementedException();
        }
    }
}
