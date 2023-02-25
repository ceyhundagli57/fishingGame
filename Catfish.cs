using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class Catfish : Fish
    {
        public Catfish(int probability) : base(probability)
        {
            MarketPrice = 10;
            Name = "catfish";
        }
    }
}
