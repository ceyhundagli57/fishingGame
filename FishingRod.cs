using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class FishingRod
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Buff { get; set; }

        public FishingRod(string name, int price, int buff) {
        
            this.Name = name;
            this.Price = price;
            this.Buff = buff;
        }
    }
}
