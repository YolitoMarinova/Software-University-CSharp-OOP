using _01.Logger.Models.Enumeration;

namespace _01.Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }

        void Append(IError error);
    }
}
