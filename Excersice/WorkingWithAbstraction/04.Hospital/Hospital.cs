using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Hospital
    { 
        public Hospital()
        {
            this.Doctors = new List<Doctor>();
            this.Departments = new List<Departments>();
        }

        public List<Doctor> Doctors { get; set; }

        public List<Departments> Departments { get; set; }
        
        public void AddDoctor(string firstName, string secondName)
        {
            if (!this.Doctors.Any(x => x.FirstName == firstName && x.SecondName == secondName))
            {
                var doctor = new Doctor(firstName, secondName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(x => x.Name == name))
            {
                var department = new Departments(name);
                this.Departments.Add(department);
            }
        }

        public void AddPatient(string doctorName,string departmentName, string patientName)
        {
            var doctor = this.Doctors.FirstOrDefault(x => x.FullName == doctorName);
            var department = this.Departments.FirstOrDefault(x => x.Name == departmentName);

            var patient = new Patient(patientName);
            doctor.Patients.Add(patient);
            department.AddPatientInRoom(patient);
        }
    }
}
