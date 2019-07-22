using _08.MilitaryElite.Enumerations;
using _08.MilitaryElite.Exceptions;
using _08.MilitaryElite.Interfaces;
using System;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            ParseState(state);
        }

        public string CodeName { get; private set; }

        public States State { get; private set; }

        public void CompleteMission()
        {
            
            this.State = States.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
        private void ParseState(string stateStr)
        {
            States state;

            bool isValidState = Enum.TryParse<States>(stateStr, out state);

            if (!isValidState)
            {
                throw new InvalidStatesExceptions();
            }

            this.State = state;
        }
    }
}
