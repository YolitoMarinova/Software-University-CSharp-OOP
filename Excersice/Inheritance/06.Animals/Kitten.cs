namespace Animals
{
    public class Kitten : Cat
    {
        private const string KITTEN_GENDER = "Female";
        private const string KITTEN_SOUND = "Meow";
        public Kitten(string name, int age) 
            : base(name, age, KITTEN_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return KITTEN_SOUND;
        }

    }
}
