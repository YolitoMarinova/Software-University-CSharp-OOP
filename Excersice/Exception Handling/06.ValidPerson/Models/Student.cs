using _06.ValidPerson.CustomExceptions;
using System.Linq;

namespace _06.ValidPerson.Models
{
    public class Student
    {
        private string name;

        public Student(string name,string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (!value.Any(x => char.IsLetter(x)))
                {
                    throw new InvalidPersonNameException();
                }

                this.name = value;
            }
        }
        public string Email { get; private set; }
    }
}
