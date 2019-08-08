using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructorSetCorrectlyCollectionOfWarriors()
        {
            Assert.NotNull(this.arena.Warriors);
        }

        [Test]
        public void ArenaEnrollWarriorCorrectly()
        {
            Warrior firstWarrior = new Warrior("Gochko", 380, 932);

            this.arena.Enroll(firstWarrior);

            CollectionAssert.Contains(this.arena.Warriors,firstWarrior);
        }

        [Test]
        public void WarriorsCountWorksCorrectly()
        {
            int expectedCount = 1;

            Warrior firstWarrior = new Warrior("Gochko", 380, 932);

            this.arena.Enroll(firstWarrior);

            Assert.That(this.arena.Count,Is.EqualTo(expectedCount));
        }

        [Test]
        public void ArenaDoNotEnrollWarriorWithNameThatIsAlredyEnrolled()
        {
            Warrior firstWarrior = new Warrior("Gochko", 380, 932);

            this.arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(
                ()=>this.arena.Enroll(firstWarrior));
        }

        [Test]
        public void WarriorsFightCorrectly()
        {

            Warrior firstWarrior = new Warrior("Gochko", 380, 932);
            Warrior secondWarrior = new Warrior("Yolito", 330, 1300);

            int expectedHP = 602;

            this.arena.Enroll(firstWarrior);
            this.arena.Enroll(secondWarrior);

            this.arena.Fight(firstWarrior.Name,secondWarrior.Name);

            Assert.That(firstWarrior.HP,Is.EqualTo(expectedHP));

        }

        [Test]
        public void NullWarriorAttackerDoNotFight()
        {

            Warrior firstWarrior = new Warrior("Gochko", 380, 932);
            Warrior secondWarrior = new Warrior("Yolito", 330, 1300);

            this.arena.Enroll(secondWarrior);


            Assert.Throws<InvalidOperationException>(
                ()=>this.arena.Fight(firstWarrior.Name,secondWarrior.Name));
        }

    }
}
