using _08.MilitaryElite.Enumerations;

namespace _08.MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier: IPrivate,ISoldier
    {
        Corps Corps { get; }
    }
}
