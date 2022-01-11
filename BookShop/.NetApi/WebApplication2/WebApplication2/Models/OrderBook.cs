﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class OrderBook
    {
        public int OrderBookId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
