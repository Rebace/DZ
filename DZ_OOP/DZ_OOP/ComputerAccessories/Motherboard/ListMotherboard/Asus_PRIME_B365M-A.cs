using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class Asus_PRIME_B365M_A : Motherboard
    {
        public override string Model { get => "Asus PRIME B365M A"; }
        public override string Socket { get => "LGA 1151 v2"; }
        public override string MemoryType { get => "DDR4"; }
        public override int MemorySlotsCount { get => 4; }

        public override string GetComputerComponentInfo()
        {
            return $"Motherboard model: { Model }";
        }
    }
}
