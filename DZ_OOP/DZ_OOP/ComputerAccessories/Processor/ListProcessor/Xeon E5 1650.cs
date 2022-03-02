using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class Xeon_E5_1650 : Processor
    {
        public override string Model { get => "Xeon E5 1650"; }
        public override string Socket { get => "LGA 2011"; }
        public override int Cores { get => 6; }
        public override int Streams { get => 12; }

        public override void GetComputerComponentInfo()
        {
            Console.WriteLine($"Processor model: { Model }");
        }
    }
}
