using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FarmerWebAPI.Models.GetModels
{
    public class GetVegetable 
    {
        public String itemName { get; set; }

        public int quantity { get; set; }

        public float unitPrice { get; set; }

        public DateTime expireDate { get; set; }

        public DateTime harvestDate { get; set; }
    }
}
