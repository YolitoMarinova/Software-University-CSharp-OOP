using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Interfaces;

namespace _08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName,
            string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
            =>  this.privates;

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var prv in Privates)
            {
                sb.AppendLine(prv.ToString());
            }

            return sb.ToString().TrimEnd(); ;
        }
    }
}
