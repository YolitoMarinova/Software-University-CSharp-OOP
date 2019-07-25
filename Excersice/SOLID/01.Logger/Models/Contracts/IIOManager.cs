namespace _01.Logger.Models.Contracts
{
    public interface IIOManager
    {
        string DirectoryPath { get; }
        string FilePath { get; }

        void EnsureDirectoryAndFileExist();

        string GetPath();
    }
}
