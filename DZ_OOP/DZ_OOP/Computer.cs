using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_OOP;

namespace DZ_OOP
{
    public class Computer
    {
        public void ComputerWrite()
        {
            try
            {
                List<IComponentCheck> components = new List<IComponentCheck>()
                {
                    new Asus_PRIME_B365M_A(),
                    new Intel_i5_8400(),
                    new Kingston_Fury_Beast(),
                    new MSI_GTX_1050_TI_Gaming_X_4G()
                };
                foreach (IComponentCheck component in components)
                {
                    component.Check();
                }
                if (((Motherboard)components[0]).Socket != ((Processor)components[1]).Socket)
                {
                    throw new ArgumentException("The processor does not fit the motherboard used, because the sockets do not match");
                }
                foreach (IComputerComponent component in components)
                {
                    Console.WriteLine(component.GetComputerComponentInfo());
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
