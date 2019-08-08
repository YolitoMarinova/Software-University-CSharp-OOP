//using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PersonTests
    {
        private Person person;

        [SetUp]
        public void SetUp()
        {
            this.person = new Person(123456789, "Dolly");
        }

        [Test]
        public void SetIdCorrectlyInConstructor()
        {
            int expexctedId = 123456789;

            Assert.That(this.person.Id, Is.EqualTo(expexctedId));
        }

        [Test]
        public void SetUserNameCorrectlyInConstructor()
        {
            string expectedUserName = "Dolly";

            Assert.That(this.person.UserName,Is.EqualTo(expectedUserName));
        }
    }
}
