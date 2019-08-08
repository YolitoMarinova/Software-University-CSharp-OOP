using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WarriorConstructorSetCorrectly()
        {
            string expectedName = "Gochko";
            int expectedDamage = 10;
            int expectedHP = 100;

            Warrior warrior = new Warrior("Gochko", 10, 100);

            Assert.NotNull(warrior, "Warrior constructor created NULL instance.");
            Assert.That(warrior.Name, Is.EqualTo(expectedName), "Name does not set correct in constructor.");
            Assert.That(warrior.Damage, Is.EqualTo(expectedDamage), "Damage does not set correct in constructor.");
            Assert.That(warrior.HP, Is.EqualTo(expectedHP), "HP does not set correct in constructor.");
        }

        [Test]
        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void NameDoNotSetWithEmptyNullOrWhiteSpaceString(string uncorrectName)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(uncorrectName, 10, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamageDoNotSetWithZeroOrNegativeNumber(int uncorrectDamage)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Gochko", uncorrectDamage, 100)); ;
        }

        [Test]
        public void HPDoNotSetWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Gochko", 10, -1));
        }

        [Test]
        public void WarriorAttackCorrectlyEnemy()
        {
            int expectedAttackerHP = 95;
            int expectedDefenderHP = 80;

            Warrior attacker = new Warrior("Gochko", 10, 100);
            Warrior defender = new Warrior("Stefan", 5, 90);
            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHP));
            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHP));
        }

        [Test]
        public void EnemyDiesIfDamageIsBiggerThanHisHP()
        {
            int expectedAttackerHP = 55; ;
            int expectedDefenderHP = 0;

            Warrior attacker = new Warrior("Gochko", 50, 100);
            Warrior defender = new Warrior("Mariq", 45, 40);

            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHP));
            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHP));
        }

        [Test]
        public void WarriorDoNotAttackWithHPThatIsUnderMinimum()
        {
            Warrior attacker = new Warrior("Gochko", 10, 25);
            Warrior defender = new Warrior("Stefan", 5, 45);

            Assert.Throws<InvalidOperationException>(
                ()=> attacker.Attack(defender));
        }

        [Test]
        public void WarriorDoNotAttackEnemyWhoHasHPThatIsUnderMinimum()
        {
            Warrior attacker = new Warrior("Gochko", 10, 45);
            Warrior defender = new Warrior("Stefan", 5, 25);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }

        [Test]
        public void WarriorCanNotFightWithEnemyWichDamageIsBiggerThanWarriorHP()
        {
            Warrior attacker = new Warrior("Gochko", 10, 35);
            Warrior defender = new Warrior("Stefan", 40, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }
    }
}