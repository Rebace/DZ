using DZ_OOP;

namespace DZ_OOP
{
    public abstract class Videocard : IComputerComponent, IComponentCheck
    {
        public abstract string Model { get; }
        public abstract int VRAM { get; }
        public void Check()
        {
            if (Model == null)
            {
                throw new ArgumentException("Motherboard should be not null");
            }
            if (VRAM < 1)
            {
                throw new ArgumentException("VRAM < 0");
            }
        }

        public abstract void GetComputerComponentInfo();
    }
}

