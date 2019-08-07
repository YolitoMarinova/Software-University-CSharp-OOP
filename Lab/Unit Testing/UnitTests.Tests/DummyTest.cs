using NUnit.Framework;
using System;

namespace UnitTests.Tests
{
    [TestFixture]
    class DummyTest
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10,10);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            dummy.TakeAttack(5);

            
            Assert.That(dummy.Health,Is.EqualTo(5),
                "Dummy doesnt lose health after attack.");
        }

        [Test]
        public void DeadDummyThrowsExceptionAttack()
        {
            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(()=> dummy.TakeAttack(0),
                "Dummy doesn't throw Exception when die.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            dummy.TakeAttack(10);

            int expirience=dummy.GiveExperience();

            Assert.That(expirience, Is.EqualTo(10),
                "When is dead, dummy didn't return experience.");
        }

        [Test]
        public void AliveDummyCantGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),
                "Dummy is alive, but return experience.");
        }
    }
}
