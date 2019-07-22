using _08.MilitaryElite.Enumerations;

namespace _08.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        States State { get; }

        void CompleteMission();
    }
}
