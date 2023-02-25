using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fishing
{
    public class Bluefin : Fish
    {
        public Bluefin(int probability) : base(probability)
        {
            MarketPrice = 500;
            Name = "bluefin";
        }

    }
}
