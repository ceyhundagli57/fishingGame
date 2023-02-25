using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fishing
{
    public class Albacore : Fish
    {
        public Albacore(int probability) : base(probability)
        {
            MarketPrice = 50;
            Name = "albacore";
        }
    }
}
