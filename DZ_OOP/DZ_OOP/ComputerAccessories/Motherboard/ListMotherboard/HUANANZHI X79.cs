using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class HUANANZHI_X79 : Motherboard
    {
        public override string Model { get => "HUANANZHI X79"; }
        public override string Socket { get => "LGA 2011"; }
        public override string MemoryType { get => "DDR3"; }
        public override int MemorySlotsCount { get => 4; }

        public override void GetComputerComponentInfo()
        {
            Console.WriteLine($"Motherboard model: { Model }");
        }
    }
}
