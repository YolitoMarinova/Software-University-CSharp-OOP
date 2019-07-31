using System;

namespace _06.ValidPerson.Models
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstname,string lastName,int age)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value",
                        "First name cannot be null or empty!");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value",
                        "Last name cannot be null or empty!");
                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "Age should be in the range [0 - 120]!");
                }

                this.age = value;
            }
        }
    }
}
