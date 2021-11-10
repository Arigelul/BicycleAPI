﻿using System;
using System.Collections.Generic;
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
        public decimal Price { get; set; }
        public bool IsRented { get; set; }
    }
}