using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class Intel_i5_8400 : Processor
    {
        public override string Model { get => "Intel i5 8400"; }
        public override string Socket { get => "LGA 1151 v2"; }
        public override int Cores { get => 6; }
        public override int Streams { get => 6; }

        public override void GetComputerComponentInfo()
        {
            Console.WriteLine($"Processor model: { Model }");
        }
    }
}

