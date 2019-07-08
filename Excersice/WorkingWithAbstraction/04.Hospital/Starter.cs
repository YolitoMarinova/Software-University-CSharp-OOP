using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Starter
    {
        private Hospital hospital;

        public Starter()
        {
            this.hospital = new Hospital();
        }

        public void Start()
        {
            string command = Console.ReadLine();

            while (command!="Output")
            {
                string[] input = command.Split();

                var department = input[0];
                var firstName = input[1];
                var secondName = input[2];
                var patientName = input[3];
                var fullName = firstName + " " + secondName;

                this.hospital.AddDoctor(firstName, secondName);
                this.hospital.AddDepartment(department);
                this.hospital.AddPatient(fullName, department, patientName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command!="End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 1)
                {
                    string departmentName = input[0];

                    Departments currentDepartment = this.hospital.Departments.FirstOrDefault(x => x.Name == departmentName);
                    Console.WriteLine(currentDepartment);
                }
                else if (input.Length == 2)
                {
                    bool isRoom = int.TryParse(input[1], out int targetRoom);

                    if (isRoom)
                    {
                        string departmentName = input[0];

                        Room currentRoom = this.hospital.Departments.FirstOrDefault(x => x.Name == departmentName).Rooms[targetRoom - 1];
                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        string fullName = input[0] + " " + input[1];
                        Doctor currentDoctor = this.hospital.Doctors.FirstOrDefault(x => x.FullName == fullName);
                        Console.WriteLine(currentDoctor);
                    }
                }

                command = Console.ReadLine();
            }

            
        }
    }
}
