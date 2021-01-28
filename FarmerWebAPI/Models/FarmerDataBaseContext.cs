using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmerWebAPI.Models
{
    public class FarmerDataBaseContext: DbContext
    {
        // private FarmerDataBaseContext context;

        //public FarmerDataBaseContext(DbContextOptions<FarmerDataBaseContext> options) : base(options)
        public FarmerDataBaseContext(DbContextOptions<FarmerDataBaseContext> options) : base(options)
        {

        }

        /*public FarmerDataBaseContext(FarmerDataBaseContext context)
        {
            this.context = context;
        }
        */
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<VegOrder> VegOrders { get; set; }


    }
}
