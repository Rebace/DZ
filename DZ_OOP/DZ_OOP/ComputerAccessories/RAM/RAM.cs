using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public abstract class RAM : IComputerComponent, IComponentCheck
    {
        public abstract string Model { get; }
        public abstract string MemoryType { get; }
        public abstract string MemoryCount { get; }
        public void Check()
        {
            if (Model == null)
            {
                throw new ArgumentException("RAM should be not null");
            }
        }
        public abstract void GetComputerComponentInfo();
    }
}

