using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[] { 1, 2, 3 });
        }

        [Test]
        public void ConstructorAddParamasCorrectly()
        {
            int expectedCount = 3;

            Assert.That(database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddElementCorrectly()
        {
            this.database.Add(4);

            int expectedCount = 4;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddElementsToAGivenRangeOfArray()
        {
            for (int i = 4; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(
                () => this.database.Add(17));
        }

        [Test]
        public void RemoveElementCorrectly()
        {
            this.database.Remove();

            int expectedCount = 2;

            Assert.That(this.database.Count,Is.EqualTo(expectedCount));
        }

        [Test]
        public void DoNotRemoveElementWhenCountIsZero()
        {
            int countToRemove = this.database.Count;

            for (int i = 0; i < countToRemove; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(
                ()=>this.database.Remove());
        }

        [Test]
        public void FetchReturnCoppyOfDatabase()
        {
            var currentData = new int[] { 1,2,3};
            var expectedCopyArray = this.database.Fetch();

            CollectionAssert.AreEqual(expectedCopyArray, currentData);
        }
    }
}