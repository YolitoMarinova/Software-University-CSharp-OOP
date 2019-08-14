namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;
        private string validParkSpot;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Fiat", "X 1234 56");
            this.softPark = new SoftPark();
            validParkSpot = "A3";
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            int expectedCountOfCarsInParking = 12;

            Assert.IsNotNull(this.softPark.Parking);
            Assert.That(this.softPark.Parking.Count, Is.EqualTo(expectedCountOfCarsInParking));
        }

        [Test]
        public void AddCarInParkingCorrectly()
        {
            string expectedResult = "Car:X 1234 56 parked successfully!";

            string result=this.softPark.ParkCar(validParkSpot, car);

            Assert.IsNotNull(this.softPark.Parking[validParkSpot]);
            Assert.That(result,Is.EqualTo(expectedResult));
        }

        [Test]
        public void DoNotParkCarIfParkSpotDoNotExist()
        {
            string invalidParkSpot = "A333";

            Assert.Throws<ArgumentException>(
                ()=>this.softPark.ParkCar(invalidParkSpot,car));
        }

        [Test]
        public void DoNotParkCarIfParkSpotIsAlreadyTaken()
        {
            this.softPark.ParkCar(validParkSpot,car);

            Car seconCar = new Car("Honda","PB 1235 45");

            Assert.Throws<ArgumentException>(
                ()=>this.softPark.ParkCar(validParkSpot,seconCar));
        }

        [Test]
        public void DoNotParkIfCarIsAlreadyPark()
        {
            string secondValidParkSpot = "A4";

            this.softPark.ParkCar(validParkSpot,car);

            Assert.Throws<InvalidOperationException>(
                ()=>this.softPark.ParkCar(secondValidParkSpot,car));
        }

        [Test]
        public void RemoveCarCorrectly()
        {
            string expectedResult = "Remove car:X 1234 56 successfully!";

            this.softPark.ParkCar(validParkSpot,car);

            string result = this.softPark.RemoveCar(validParkSpot,car);

            Assert.IsNull(this.softPark.Parking[validParkSpot]);
            Assert.That(result,Is.EqualTo(expectedResult));
        }

        [Test]
        public void DoNotRemoveIfParkSpotIsNotExist()
        {
            string invalidParkSpot = "A5";

            this.softPark.ParkCar(validParkSpot,car);

            Assert.Throws<ArgumentException>(
                ()=>this.softPark.RemoveCar(invalidParkSpot,car));
        }

        [Test]
        public void DoNotRemoveCarIfDoesNotExistInGivenParkSpot()
        {
            Assert.Throws<ArgumentException>(
                ()=>this.softPark.RemoveCar(validParkSpot,car));
        }
    }
}