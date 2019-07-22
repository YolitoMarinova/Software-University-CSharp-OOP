using System;
using _08.MilitaryElite.Interfaces;
using _08.MilitaryElite.Exceptions;
using _08.MilitaryElite.Enumerations;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool isValidCorp = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!isValidCorp)
            {
                throw new InvalidCorpsExceptions();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");

            return sb.ToString().TrimEnd();
        }
    }
}
