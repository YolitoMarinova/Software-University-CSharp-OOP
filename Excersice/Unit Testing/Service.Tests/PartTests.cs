using NUnit.Framework;
//using Service.Models.Contracts;
//using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private IPart phonePart;
        private IPart laptopPart;
        private IPart pcPart;

        [SetUp]
        public void Setup()
        {
            
            this.phonePart = new PhonePart("protector",30);
            this.laptopPart = new LaptopPart("SSDDisk",300);
            this.pcPart = new PCPart("mouse",10);
        }

        [Test]
        public void PhonePartConstructorWorksCorrecltyWithDefaultFalseValueOfBroken()
        {
            string expectedName = "protector";
            decimal expectedPrice = 30m*1.3m;
            bool expectedBrokenCondition = false;

            Assert.That(this.phonePart.Name,Is.EqualTo(expectedName));
            Assert.That(this.phonePart.Cost,Is.EqualTo(expectedPrice));
            Assert.That(this.phonePart.IsBroken,Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        public void PhonePartConstructorWorksCorrecltyWithTrueValueOfBroken()
        {
            string expectedName = "protector";
            decimal expectedPrice = 30m * 1.3m;
            bool expectedBrokenCondition = true;

            PhonePart brokenPhone = new PhonePart("protector", 30,true);

            Assert.That(brokenPhone.Name, Is.EqualTo(expectedName));
            Assert.That(brokenPhone.Cost, Is.EqualTo(expectedPrice));
            Assert.That(brokenPhone.IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PhoneNameSetterDoNotSetNullOrEmptyValue(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => new PhonePart(invalidName,20)); ;
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void PhoneCostSetterDoNotSetZeroOrNegtaiveValue(decimal invalidCost)
        {
            Assert.Throws<ArgumentException>(
                () => new PhonePart("protektor",invalidCost)); ;
        }

        [Test]
        public void PhoneRepairWorksCorrectly()
        {
            bool expectedBrokenCondicion = false;

            this.phonePart.Repair();

            Assert.That(this.phonePart.IsBroken,Is.EqualTo(expectedBrokenCondicion));
        }

        [Test]
        public void PhoneReportWorksCorrectly()
        {
            string expectedResult= $"{this.phonePart.Name} - {this.phonePart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {this.phonePart.IsBroken}";

            Assert.That(this.phonePart.Report(),Is.EqualTo(expectedResult));
        }

        [Test]
        public void LaptopPartConstructorWorksCorrecltyWithDefaultFalseValueOfBroken()
        {
            string expectedName = "SSDDisk";
            decimal expectedPrice = 300m * 1.5m;
            bool expectedBrokenCondition = false;

            Assert.That(this.laptopPart.Name, Is.EqualTo(expectedName));
            Assert.That(this.laptopPart.Cost, Is.EqualTo(expectedPrice));
            Assert.That(this.laptopPart.IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        public void LaptopPartConstructorWorksCorrecltyWithTrueValueOfBroken()
        {
            string expectedName = "SSDDisk";
            decimal expectedPrice = 300m * 1.5m;
            bool expectedBrokenCondition = true;

            LaptopPart brokenLaptop = new LaptopPart("SSDDisk", 300, true);

            Assert.That(brokenLaptop.Name, Is.EqualTo(expectedName));
            Assert.That(brokenLaptop.Cost, Is.EqualTo(expectedPrice));
            Assert.That(brokenLaptop.IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void LaptopNameSetterDoNotSetNullOrEmptyValue(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => new LaptopPart(invalidName, 300)); ;
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void LaptopCostSetterDoNotSetZeroOrNegtaiveValue(decimal invalidCost)
        {
            Assert.Throws<ArgumentException>(
                () => new LaptopPart("SSDDisk", invalidCost)); ;
        }

        [Test]
        public void LaptopRepairWorksCorrectly()
        {
            bool expectedBrokenCondicion = false;

            this.laptopPart.Repair();

            Assert.That(this.laptopPart.IsBroken, Is.EqualTo(expectedBrokenCondicion));
        }

        [Test]
        public void LaptopReportWorksCorrectly()
        {
            string expectedResult = $"{this.laptopPart.Name} - {this.laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {this.laptopPart.IsBroken}";

            Assert.That(this.laptopPart.Report(), Is.EqualTo(expectedResult));
        }


        [Test]
        public void PCPartConstructorWorksCorrecltyWithDefaultFalseValueOfBroken()
        {
            string expectedName = "mouse";
            decimal expectedPrice = 10m * 1.2m;
            bool expectedBrokenCondition = false;

            Assert.That(this.pcPart.Name, Is.EqualTo(expectedName));
            Assert.That(this.pcPart.Cost, Is.EqualTo(expectedPrice));
            Assert.That(this.pcPart.IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        public void PCPartConstructorWorksCorrecltyWithTrueValueOfBroken()
        {
            string expectedName = "mouse";
            decimal expectedPrice = 10m * 1.2m;
            bool expectedBrokenCondition = true;

            PCPart brokenPC = new PCPart("mouse", 10, true);

            Assert.That(brokenPC.Name, Is.EqualTo(expectedName));
            Assert.That(brokenPC.Cost, Is.EqualTo(expectedPrice));
            Assert.That(brokenPC.IsBroken, Is.EqualTo(expectedBrokenCondition));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PCNameSetterDoNotSetNullOrEmptyValue(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => new PCPart(invalidName, 10)); ;
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void PCCostSetterDoNotSetZeroOrNegtaiveValue(decimal invalidCost)
        {
            Assert.Throws<ArgumentException>(
                () => new PCPart("mouse", invalidCost)); ;
        }

        [Test]
        public void PCRepairWorksCorrectly()
        {
            bool expectedBrokenCondicion = false;

            this.pcPart.Repair();

            Assert.That(this.pcPart.IsBroken, Is.EqualTo(expectedBrokenCondicion));
        }

        [Test]
        public void PCReportWorksCorrectly()
        {
            string expectedResult = $"{this.pcPart.Name} - {this.pcPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {this.pcPart.IsBroken}";

            Assert.That(this.pcPart.Report(), Is.EqualTo(expectedResult));
        }
    }
}