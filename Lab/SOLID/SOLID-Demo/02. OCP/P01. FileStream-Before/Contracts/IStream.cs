namespace P01._FileStream_Before.Contracts
{
    public interface IStream
    {
        int Length { get; }
        int Sent { get; }
    }
}
