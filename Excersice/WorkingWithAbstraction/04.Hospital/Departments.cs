using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Departments
    {

        public Departments(string name)
        {
            this.Name = name;

            this.Rooms = new List<Room>();

            this.CreateRooms();
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public void AddPatientInRoom(Patient patient)
        {
            var currentRoom = this.Rooms
                .Where(x => !x.IsFull)
                .FirstOrDefault();

            if (currentRoom != null)
            {
                currentRoom.AddPatient(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in Rooms)
            {
                foreach (var patient in room.PatientsName)
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

    }
}
