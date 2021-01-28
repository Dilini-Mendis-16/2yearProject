using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerWebAPI.Models
{
    public class Vegetable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public String vegetable_type { get; set; }

         public int quantity  { get; set; }

         public  float unit_price { get;set; }

         public DateTime expired_date { get; set; }

        public  DateTime harvest_date { get; set; }
        //public int available_stock { get; set; }
            


        }
}
