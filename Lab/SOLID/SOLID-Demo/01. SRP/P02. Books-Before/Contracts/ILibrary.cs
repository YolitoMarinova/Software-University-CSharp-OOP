using System.Collections.Generic;

namespace P02._Books_Before.Contracts
{
    public interface ILibrary
    {
        string Name { get; }

        IReadOnlyCollection<IBook> books { get; }

        int BookLocation();
    }
}
