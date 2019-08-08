//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Dacia", "Sandero", 3, 50);
        }

        [Test]
        public void CarConstructorSetCorrectly()
        {
            string expectedMake = "Dacia";
            string expectedModel = "Sandero";
            double expectedFuelConsumprion = 3;
            double expextedFuelCapacity = 50;
            double expectedFuelAmount = 0;

            Assert.NotNull(this.car, "Parameters didnt set to Car. Car is set to null.");
            Assert.That(this.car.Make, Is.EqualTo(expectedMake), "Make is not set correctly.");
            Assert.That(this.car.Model, Is.EqualTo(expectedModel), "Model is not set correctly.");
            Assert.That(this.car.FuelConsumption, Is.EqualTo(expectedFuelConsumprion), "FuelConsumption is not set correctly.");
            Assert.That(this.car.FuelCapacity, Is.EqualTo(expextedFuelCapacity), "FuelCapacity is not set correctly.");
            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedFuelAmount), "FuelAmount is not set correctly.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterDoNotSetNullOrEmpty(string uncorretcMake)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(uncorretcMake, "Sandero", 3, 50));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterDoNotSetNullOrEmpty(string uncorretcModel)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Dacia", uncorretcModel, 3, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumtionDoNotSetIfConsumptionIsNegative(double uncorrectFuelConsumption)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Dacia", "Sandero", uncorrectFuelConsumption, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityDoNotSetIfConsumptionIsNegative(double uncorrectFuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Dacia", "Sandero", 3, uncorrectFuelCapacity));
        }

        [Test]
        public void RefuelCarCorrectly()
        {
            double expectedAmount = 10;

            this.car.Refuel(10);

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedAmount));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CanNotRefuelWithNegativeOrZeroFuel(double uncorrectFuel)
        {
            Assert.Throws<ArgumentException>(
                () => this.car.Refuel(uncorrectFuel));
        }

        [Test]
        public void RefuelFuelInRangeOfCapacity()
        {
            int expectedAmount = 50;

            this.car.Refuel(60);

            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedAmount));
        }

        [Test]
        public void DriveCorrectly()
        {
            double expectedAmount = 4.85;

            this.car.Refuel(5);
            this.car.Drive(5);

            Assert.That(this.car.FuelAmount,Is.EqualTo(expectedAmount));
        }

        [Test]
        public void DoNotDriveWithNotEnoughAmount()
        {
            Assert.Throws<InvalidOperationException>(
                ()=>this.car.Drive(5));
        }
    }
}