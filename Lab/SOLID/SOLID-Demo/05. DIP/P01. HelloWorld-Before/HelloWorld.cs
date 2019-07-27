using System;

namespace P01._HelloWorld
{
    public class HelloWorld
    {
        public HelloWorld(int hour)
        {
            this.CurrentHour = hour;
        }

        public int CurrentHour { get; set;}

        public string Greeting(string name)
        {
            if (this.CurrentHour < 12)
            {
                return "Good morning, " + name;
            }

            if (this.CurrentHour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
