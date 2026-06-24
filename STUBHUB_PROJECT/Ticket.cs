using System;

namespace STUBHUB_PROJECT
{
    public class Ticket
    {
        public int TierID { get; set; }
        public string TierName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }
}