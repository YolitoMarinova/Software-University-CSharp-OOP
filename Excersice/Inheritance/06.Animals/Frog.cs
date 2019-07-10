namespace Animals
{
    public class Frog : Animal
    {
        private const string FROG_SOUND = "Ribbit";

        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return FROG_SOUND;
        }
    }
}
