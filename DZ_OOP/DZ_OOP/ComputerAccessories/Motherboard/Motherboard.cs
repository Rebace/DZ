using DZ_OOP;

namespace DZ_OOP
{
    public abstract class Motherboard : IComputerComponent, IComponentCheck
    {
        public abstract string Model { get; }
        public abstract string Socket { get; }
        public abstract string MemoryType { get; }
        public abstract int MemorySlotsCount { get; }

        public void Check()
        {
            if (Model == null)
            {
                throw new ArgumentException("Motherboard should be not null");
            }
            if (MemorySlotsCount < 1)
            {
                throw new ArgumentException("Motherboard slots count < 0");
            }
        }

        public abstract void GetComputerComponentInfo();
    }
}
