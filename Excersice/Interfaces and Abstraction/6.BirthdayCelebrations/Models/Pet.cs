using _06.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name,string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }
        public string Birthday { get; }
    }
}
