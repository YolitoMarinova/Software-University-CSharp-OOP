//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] persons;
        private ExtendedDatabase extendetDatabase;

        [SetUp]
        public void Setup()
        {
            this.persons = new Person[]
                {
                    new Person(123456789987654321,"Pesho"),
                    new Person(987654321123456789,"Gosho")
                };

            this.extendetDatabase = new ExtendedDatabase(this.persons);
        }

        [Test]
        public void ConstructorAddPersonsCorrectly()
        {
            int expectedCount = 2;

            Assert.That(extendetDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddPersonCorrectly()
        {
            Person personToAdd = new Person(10, "LittleSkittle");

            this.extendetDatabase.Add(personToAdd);

            int expectedCount = 3;

            Assert.That(this.extendetDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void DoNotAddPersonCapacityFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                int id = i;
                string userName = ((char)i).ToString();
                Person personToAdd = new Person(id, userName);

                this.extendetDatabase.Add(personToAdd);
            }

            Assert.Throws<InvalidOperationException>(
                () => this.extendetDatabase.Add(new Person(80, "a")));
        }

        [Test]
        public void DoNotAddPersonWithExistUserName()
        {
            string dublicateuserName = this.persons[0].UserName;
            Person person = new Person(20256, dublicateuserName);

            Assert.Throws<InvalidOperationException>(
                () => this.extendetDatabase.Add(person));
        }

        [Test]
        public void DoNotAddPersonWhoIdIsAlredyRegister()
        {
            long dublicateId = this.persons[0].Id;
            Person person = new Person(dublicateId, "Sonqqqqqqqq");

            Assert.Throws<InvalidOperationException>(
                () => this.extendetDatabase.Add(person));
        }

        [Test]
        public void RemovePersonCorrectly()
        {
            this.extendetDatabase.Remove();

            int expectedCount = 1;

            Assert.That(this.extendetDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void DoNotRemovePersonWhenDatabaseIsEmpty()
        {
            int countToRemove = this.extendetDatabase.Count;

            for (int i = 0; i < countToRemove; i++)
            {
                this.extendetDatabase.Remove();
            }

            Assert.Throws<InvalidOperationException>(
                () => this.extendetDatabase.Remove());
        }

        [Test]
        public void FindPersonByCorrectlyUserName()
        {
            Person expectedPerson = this.persons[0];
            string correctUserName = expectedPerson.UserName;

            Person returnedPerson = this.extendetDatabase
                .FindByUsername(correctUserName);

            Assert.AreEqual(expectedPerson,returnedPerson);
        }
       
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void DoNotFindPersonWithEmptyOrNullUserName(string fakeUserName)
        {
            Assert.Throws<ArgumentNullException>(
                ()=>this.extendetDatabase.FindByUsername(fakeUserName));
        }

        [Test]
        public void DoNotFindPersonWitelUserNameThatNotExist()
        {
            string fakeUserName = "Mariq";

            Assert.Throws<InvalidOperationException>(
                () => this.extendetDatabase.FindByUsername(fakeUserName));
        }

        [Test]
        public void FindPersonByCorrectlyId()
        {
            Person expectedPerson = this.persons[0];
            long correctId = expectedPerson.Id;

            Person returnedPerson= this.extendetDatabase
                .FindById(correctId);

            Assert.AreEqual(expectedPerson, returnedPerson);
        }

        [Test]
        public void DoNotFindPersonWithNegativeId()
        {
            long negativeId = -123456789;

            Assert.Throws<ArgumentOutOfRangeException>(
                ()=>this.extendetDatabase.FindById(negativeId));
        }

        [Test]
        public void DoNotFindPersonWithIdWichNotExist()
        {
            long fakeId = 999;

            Assert.Throws<InvalidOperationException>(
                ()=>this.extendetDatabase.FindById(fakeId));
        }
    }
}