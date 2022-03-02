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
