using System;
using System.Collections.Generic;
using System.Text;

namespace _03.StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public Dictionary<string, Student> Students
        {
            get { return students; }
            private set { students = value; }
        }
        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] commandsInfo = Console.ReadLine().Split();

            string command = commandsInfo[0];
            

            if (command == "Create")
            {
                var studentName = commandsInfo[1];
                var age = int.Parse(commandsInfo[2]);
                var grade = double.Parse(commandsInfo[3]);

                if (!students.ContainsKey(studentName))
                {
                    var student = new Student(studentName, age, grade);
                    Students[studentName] = student;
                }
            }
            else if (command == "Show")
            {
                var studentName = commandsInfo[1];

                if (Students.ContainsKey(studentName))
                {
                    var student = Students[studentName];
                    string result = student.ToString();

                    if (student.Grade >= 5.00)
                    {
                        result += " Excellent student.";
                    }
                    else if (student.Grade < 5.00
                        && student.Grade >= 3.50)
                    {
                        result += " Average student.";
                    }
                    else
                    {
                        result += " Very nice person.";
                    }

                    Console.WriteLine(result);
                }

            }
            else if (commandsInfo[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
