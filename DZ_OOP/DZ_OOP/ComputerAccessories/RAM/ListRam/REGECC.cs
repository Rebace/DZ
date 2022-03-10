using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class REGECC : RAM
    {
        public override string Model { get => "REGECC"; }
        public override string MemoryType { get => "DDR3"; }
        public override string MemoryCount { get => "4GB"; }

        public override string GetComputerComponentInfo()
        {
            return $"RAM model: { Model }";
        }
    }
}
