﻿namespace AutomatSellingDrink.DataAccess.Entities
{
    public class Coin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public bool IsAllowToDeposit { get; set; }
    }
}