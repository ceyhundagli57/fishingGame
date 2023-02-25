using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fishing
{
    public class Yellowtail : Fish
    {
        public Yellowtail(int probability) : base(probability)
        {
            MarketPrice = 100;
            Name = "Yellowtail";
        }
    }
}
