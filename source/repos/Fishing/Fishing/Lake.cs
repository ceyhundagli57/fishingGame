using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    public class Lake
    {
        public string Name { get; set; }
        public List<Fish> AvailableFishes { get; set; }
        public Lake(string name, List<Fish> Fl) { 

            this.Name = name;
            this.AvailableFishes = Fl;
        }
    }
}
