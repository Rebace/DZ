using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_OOP;
using NUnit.Framework;

namespace ComputerTest
{
    public class ComputerTest
    {
        [Test]
        public void Motherboar_Check_PositiveTest()
        {
            //Arrange
            Motherboard motherboard;

            //Act
            motherboard = new Asus_PRIME_B365M_A();

            //Assert
            motherboard.Check();
        }
        [Test]
        public void Motherboar_Check_NegotiveTest()
        {
            //Arrange
            Motherboard motherboard;

            //Act
            motherboard = null;

            //Assert
            motherboard.Check();
        }
        [Test]
        public void Processor_Check_PositiveTest()
        {
            //Arrange
            Processor processor;

            //Act
            processor = new Intel_i5_8400();

            //Assert
            processor.Check();
        }
        [Test]
        public void Processor_Check_NegotiveTest()
        {
            //Arrange
            Processor processor;

            //Act
            processor = null;

            //Assert
            processor.Check();
        }
        [Test]
        public void RAM_Check_PositiveTest()
        {
            //Arrange
            RAM ram;

            //Act
            ram = new REGECC();

            //Assert
            ram.Check();
        }
        [Test]
        public void RAM_Check_NegotiveTest()
        {
            //Arrange
            RAM ram;

            //Act
            ram = null;

            //Assert
            ram.Check();
        }
        [Test]
        public void Videocard_Check_PositiveTest()
        {
            //Arrange
            Videocard videocard;

            //Act
            videocard = new MSI_GeForce_RTX_3060Ti_GAMING_X_8G_LHR();

            //Assert
            videocard.Check();
        }
        [Test]
        public void Videocard_Check_NegotiveTest()
        {
            //Arrange
            Videocard videocard;

            //Act
            videocard = null;

            //Assert
            videocard.Check();
        }
        [Test]
        public void Computer_CheckSocket_PositiveTest()
        {
            //Arrange
            Motherboard motherboard;
            Processor processor;

            //Act
            motherboard = new Asus_PRIME_B365M_A();
            processor = new Intel_i5_8400();

            //Assert
            if (motherboard.Socket != processor.Socket)
            {
                throw new ArgumentException("The processor does not fit the motherboard used, because the sockets do not match");
            }
        }
        [Test]
        public void Computer_CheckSocket_NegotiveTest()
        {
            //Arrange
            Motherboard motherboard;
            Processor processor;

            //Act
            motherboard = new HUANANZHI_X79();
            processor = new Intel_i5_8400();

            //Assert
            if (motherboard.Socket != processor.Socket)
            {
                throw new ArgumentException("The processor does not fit the motherboard used, because the sockets do not match");
            }
        }
        [Test]
        public void Computer_GetComputerComponentInfo_ReturnComponents_PositiveTest()
        {
            //Arrange + Act
            List<String> expected = new List<String>();
            expected.Add("Motherboard model: Asus PRIME B365M A");
            expected.Add("Processor model: Intel i5 8400");
            expected.Add("RAM model: Kingston Fury Beast");
            expected.Add("Videocard model: MSI GTX 1050 TI Gaming X 4G");
            List<IComponentCheck> components = new List<IComponentCheck>()
            {
                new Asus_PRIME_B365M_A(),
                new Intel_i5_8400(),
                new Kingston_Fury_Beast(),
                new MSI_GTX_1050_TI_Gaming_X_4G()
            };
            List<String> actual = new List<String>();
            foreach (IComputerComponent component in components)
            {
                actual.Add(component.GetComputerComponentInfo());
            }

            //Assert
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void Computer_ComputerWrite_ReturnComponents_PositiveTest()
        {
            //Arrange
            Computer computer;

            //Act
            computer = new Computer();

            //Assert
            computer.ComputerWrite();
        }
    }
}
