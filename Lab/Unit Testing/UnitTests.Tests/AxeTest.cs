using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    class AxeTest
    {
        [Test]
        public void WeaponLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10,10);
            Dummy dummy = new Dummy(10,10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints,Is.EqualTo(9),
                "Axe Durability doesnt't change after attack.");
        }
    }
}
