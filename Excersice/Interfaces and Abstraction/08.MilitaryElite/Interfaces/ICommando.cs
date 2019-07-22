using _08.MilitaryElite.Models;
using System.Collections.Generic;

namespace _08.MilitaryElite.Interfaces
{
    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
