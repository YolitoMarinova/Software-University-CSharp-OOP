using _01.AppToTest;
using _01.AppToTest.Contracts;
using Moq;
using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class HeroTest
    {
        private const string HeroName = "Yoana";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero(HeroName, fakeWeapon.Object);

            fakeTarget
                .Setup(p => p.Health).Returns(0);
            fakeTarget
                .Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget
                .Setup(p=>p.IsDead()).Returns(true);

            fakeTarget
                .Setup(p => p.Health).Returns(0);

            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20),
                "Hero doesn't gains XP when target dies.");
        }
    }
}
