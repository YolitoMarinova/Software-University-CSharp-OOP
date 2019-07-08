using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Room
    {
        public Room()
        {
            this.PatientsName = new List<Patient>();
        }

        public List<Patient> PatientsName { get; set; }

        public bool IsFull
            => this.PatientsName.Count >= 3;

        public void AddPatient(Patient patient)
        {
            if (this.PatientsName.Count < 3)
            {
                this.PatientsName.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in PatientsName.OrderBy(x=>x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
