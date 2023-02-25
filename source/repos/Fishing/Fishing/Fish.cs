using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class Fish
    {
        public string Name { get; set; }

        public int MarketPrice { get; set; }

        public int BiteProbability { get; set; }

        public Fish(int probability) => this.BiteProbability = probability;

        internal virtual bool BitesBait(FishingRod fishingRod, int chance) => chance < this.BiteProbability + fishingRod.Buff;

        internal bool IsCaught(string input) => input == "1";

        internal void PrintDetails() => Console.WriteLine(this.Name);
    }
}