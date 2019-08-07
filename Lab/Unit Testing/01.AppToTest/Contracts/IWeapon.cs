namespace _01.AppToTest.Contracts
{
    public interface IWeapon
    {
        int AttackPoints { get; }
        int DurabilityPoints { get; }
        void Attack(ITarget target);
    }
}
