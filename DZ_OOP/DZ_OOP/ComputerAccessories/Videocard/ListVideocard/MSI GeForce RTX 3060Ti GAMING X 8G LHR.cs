using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class MSI_GeForce_RTX_3060Ti_GAMING_X_8G_LHR : Videocard
    {
        public override string Model { get => "MSI GeForce RTX 3060Ti GAMING X 8G LHR"; }
        public override int VRAM { get => 8; }

        public override string GetComputerComponentInfo()
        {
            return $"Videocard model: { Model }";
        }
    }
}

