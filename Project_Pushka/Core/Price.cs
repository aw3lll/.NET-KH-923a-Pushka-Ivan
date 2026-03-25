using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public struct Price
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}
