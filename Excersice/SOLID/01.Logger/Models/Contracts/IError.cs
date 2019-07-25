using System;
using _01.Logger.Models.Enumeration;

namespace _01.Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
