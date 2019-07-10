namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TOMCAT_GENDER = "Male";
        private const string TOMCAT_SOUND = "MEOW";
        public Tomcat(string name, int age) 
            : base(name, age, TOMCAT_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return TOMCAT_SOUND;
        }
    }
}
