using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleAPI.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BicycleTypeId { get; set; }
        public BicycleType BicycleType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public bool IsRented { get; set; }
    }
}