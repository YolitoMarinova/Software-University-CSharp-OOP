namespace _03.Ferrarii.Interfaces
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }
        string UseBrakes();
        string PushTheGas();
    }
}
