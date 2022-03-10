using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class Kingston_Fury_Beast : RAM
    {
        public override string Model { get => "Kingston Fury Beast"; }
        public override string MemoryType { get => "DDR4"; }
        public override string MemoryCount { get => "8GB"; }

        public override string GetComputerComponentInfo()
        {
            return $"RAM model: { Model }";
        }
    }
}
