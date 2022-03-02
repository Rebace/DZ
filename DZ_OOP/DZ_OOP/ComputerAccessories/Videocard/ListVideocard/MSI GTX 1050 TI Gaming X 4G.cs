using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_OOP
{
    public class MSI_GTX_1050_TI_Gaming_X_4G : Videocard
    {
        public override string Model { get => "MSI GTX 1050 TI Gaming X 4G"; }
        public override int VRAM { get => 4; }

        public override void GetComputerComponentInfo()
        {
            Console.WriteLine($"Videocard model: { Model }");
        }
    }
}

