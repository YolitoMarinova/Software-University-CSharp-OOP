using NUnit.Framework;
//using Service.Models.Contracts;
//using Service.Models.Devices;
//using Service.Models.Parts;
using System;
using System.Linq;

namespace Service.Tests
{
    public class DeviceTests
    {
        private IRepairable phone;
        private IRepairable laptop;
        private IRepairable pc;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("Samsung");
            this.laptop = new Laptop("Dell");
            this.pc = new PC("LG");
        }

        [Test]
        public void PhoneConstructorWorksCorrectly()
        {
            string expectedMake = "Samsung";

            Assert.NotNull(this.phone.Parts);
            Assert.That(this.phone.Make,Is.EqualTo(expectedMake));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PhoneMakeSetterDoNotSettNullOrEmptyName(string invalidMake)
        {
            Assert.Throws<ArgumentException>(
                ()=> new Phone(invalidMake));
        }

        [Test]
        public void PhoneDeviceAddPartCorrectly()
        {
            var expectedCount = 1;

            this.phone.AddPart(new PhonePart("part",20));

            Assert.AreEqual(expectedCount,this.phone.Parts.Count);
        }

        [Test]
        public void PhoneDiviceDoNotAddLaptopPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.phone.AddPart(new LaptopPart("part",20))); ;
        }

        [Test]
        public void PhoneDiviceDoNotAddPCPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.phone.AddPart(new PCPart("part", 20))); ;
        }

        [Test]
        public void PhoneDeviceDoNotAddPartIfAlredyExist()
        {
            this.phone.AddPart(new PhonePart("part", 20));

            Assert.Throws<InvalidOperationException>(
                ()=> this.phone.AddPart(new PhonePart("part", 20)));
        }

        [Test]
        public void PhoneDeviceRemoCorrectly()
        {
            int expectedCount = 0;

            this.phone.AddPart(new PhonePart("part", 20));
            this.phone.RemovePart("part");

            Assert.That(this.phone.Parts.Count,Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PhoneDiviceDoNotRemovePartIfNameIsNullOrEmpty(string invalidName)
        {
            this.phone.AddPart(new PhonePart("part", 20));

            Assert.Throws<ArgumentException>(
                ()=>this.phone.RemovePart(invalidName));
        }

        [Test]
        public void PhoneDiviceDoNotRemovePartIfDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                ()=> this.phone.RemovePart("name"));
        }

        [Test]
        public void PhoneDeviceRepaiPartCorrectly()
        {
            bool expectedBrokenCondition = false;

            this.phone.AddPart(new PhonePart("part", 20,true));

            this.phone.RepairPart("part");

            Assert.That(this.phone.Parts.First().IsBroken,Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PhoneDeviceDoNotRepairPartIfNameIsNullOrEmpty(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                ()=>this.phone.RepairPart(invalidName));
        }

        [Test]
        public void PhoneDeviceCanNotRepairPartWichDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.phone.RepairPart("name"));
        }

        [Test]
        public void PhoneDeviceCanNotRepairPartWichIsNotBroken()
        {
            this.phone.AddPart(new PhonePart("part", 20));

            Assert.Throws<InvalidOperationException>(
                () => this.phone.RepairPart("name"));
        }               

        [Test]
        public void LaptopConstructorWorksCorrectly()
        {
            string expectedMake = "Dell";

            Assert.NotNull(this.laptop.Parts);
            Assert.That(this.laptop.Make, Is.EqualTo(expectedMake));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void LaptopMakeSetterDoNotSettNullOrEmptyName(string invalidMake)
        {
            Assert.Throws<ArgumentException>(
                () => new Phone(invalidMake));
        }

        [Test]
        public void LaptopDeviceAddPartCorrectly()
        {
            var expectedCount = 1;

            this.laptop.AddPart(new LaptopPart("part", 200));

            Assert.AreEqual(expectedCount, this.laptop.Parts.Count);
        }

        [Test]
        public void LaptopDiviceDoNotAddPhonePart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.laptop.AddPart(new PhonePart("part", 20))); ;
        }

        [Test]
        public void LaptopDiviceDoNotAddPCPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.laptop.AddPart(new PCPart("part", 20))); ;
        }

        [Test]
        public void LaptopDeviceDoNotAddPartIfAlredyExist()
        {
            this.laptop.AddPart(new LaptopPart("part", 200));

            Assert.Throws<InvalidOperationException>(
                () => this.laptop.AddPart(new LaptopPart("part", 200)));
        }

        [Test]
        public void LaptopDeviceRemoCorrectly()
        {
            int expectedCount = 0;

            this.laptop.AddPart(new LaptopPart("part", 200));
            this.laptop.RemovePart("part");

            Assert.That(this.laptop.Parts.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void LaptopDiviceDoNotRemovePartIfNameIsNullOrEmpty(string invalidName)
        {
            this.laptop.AddPart(new LaptopPart("part", 200));

            Assert.Throws<ArgumentException>(
                () => this.laptop.RemovePart(invalidName));
        }

        [Test]
        public void LaptopDiviceDoNotRemovePartIfDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.laptop.RemovePart("name"));
        }

        [Test]
        public void LaptopDeviceRepaiPartCorrectly()
        {
            bool expectedBrokenCondition = false;

            this.laptop.AddPart(new LaptopPart("part", 200,true));

            this.laptop.RepairPart("part");

            Assert.That(this.laptop.Parts.First().IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void LaptopDeviceDoNotRepairPartIfNameIsNullOrEmpty(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => this.laptop.RepairPart(invalidName));
        }

        [Test]
        public void LaptopDeviceCanNotRepairPartWichDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.laptop.RepairPart("name"));
        }

        [Test]
        public void LaptopDeviceCanNotRepairPartWichIsNotBroken()
        {
            this.laptop.AddPart(new LaptopPart("part", 200));

            Assert.Throws<InvalidOperationException>(
                () => this.laptop.RepairPart("name"));
        }

        [Test]
        public void PCConstructorWorksCorrectly()
        {
            string expectedMake = "LG";

            Assert.NotNull(this.pc.Parts);
            Assert.That(this.pc.Make, Is.EqualTo(expectedMake));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PCMakeSetterDoNotSettNullOrEmptyName(string invalidMake)
        {
            Assert.Throws<ArgumentException>(
                () => new PC(invalidMake));
        }

        [Test]
        public void PCDeviceAddPartCorrectly()
        {
            var expectedCount = 1;

            this.pc.AddPart(new PCPart("part", 100));

            Assert.AreEqual(expectedCount, this.pc.Parts.Count);
        }

        [Test]
        public void PCDiviceDoNotAddPhonePart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.pc.AddPart(new PhonePart("part", 20))); ;
        }

        [Test]
        public void PCDiviceDoNotAddLaptopPart()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.pc.AddPart(new LaptopPart("part", 20))); ;
        }

        [Test]
        public void PCDeviceDoNotAddPartIfAlredyExist()
        {
            this.pc.AddPart(new PCPart("part", 100));

            Assert.Throws<InvalidOperationException>(
                () => this.pc.AddPart(new PCPart("part", 100)));
        }

        [Test]
        public void PCDeviceRemoCorrectly()
        {
            int expectedCount = 0;

            this.pc.AddPart(new PCPart("part", 100));
            this.pc.RemovePart("part");

            Assert.That(this.pc.Parts.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PCDiviceDoNotRemovePartIfNameIsNullOrEmpty(string invalidName)
        {
            this.pc.AddPart(new PCPart("part", 100));

            Assert.Throws<ArgumentException>(
                () => this.pc.RemovePart(invalidName));
        }

        [Test]
        public void PCDiviceDoNotRemovePartIfDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.pc.RemovePart("name"));
        }

        [Test]
        public void PCDeviceRepaiPartCorrectly()
        {
            bool expectedBrokenCondition = false;

            this.pc.AddPart(new PCPart("part", 100,true));

            this.pc.RepairPart("part");

            Assert.That(this.pc.Parts.First().IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PCDeviceDoNotRepairPartIfNameIsNullOrEmpty(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => this.pc.RepairPart(invalidName));
        }

        [Test]
        public void PCDeviceCanNotRepairPartWichDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.pc.RepairPart("name"));
        }

        [Test]
        public void PCDeviceCanNotRepairPartWichIsNotBroken()
        {
            this.pc.AddPart(new PCPart("part", 100));

            Assert.Throws<InvalidOperationException>(
                () => this.pc.RepairPart("name"));
        }
    }
}
