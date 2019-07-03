namespace _03.StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
        public double Grade
        {
            get { return grade; }
            private set { grade = value; }
        }
        public Student(string name, int age, double grade)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }

        public override string ToString()
        {
           return $"{name} is {age} years old.";
        }
    }
}