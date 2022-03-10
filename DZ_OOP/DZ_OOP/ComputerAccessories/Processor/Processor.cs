using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public abstract class Processor : IComputerComponent, IComponentCheck
    {
        public abstract string Model { get; }
        public abstract string Socket { get; }
        public abstract int Cores { get; }
        public abstract int Streams { get; }
        public void Check()
        {
            if (Model == null)
            {
                throw new ArgumentException("Processor should be not null");
            }
            if (Cores < 1)
            {
                throw new ArgumentException("Cores < 0");
            }
            if (Streams < 1)
            {
                throw new ArgumentException("Streams < 0");
            }
        }
        public abstract string GetComputerComponentInfo();
    }
}
