using _01.Logger.Models.Contracts;
using System.IO;

namespace _01.Logger.Models.IOManagment
{
    public class IOManager : IIOManager
    {
        private string path;
        private string directory;
        private string fileName;

        public IOManager()
        {
            this.path = this.GetPath();
        }

        public IOManager(string directory, string fileName)
            : this()
        {
            this.directory = directory;
            this.fileName = fileName;
        }

        public string DirectoryPath 
            => this.path + this.directory;

        public string FilePath 
            => this.DirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.DirectoryPath))
            {
                Directory.CreateDirectory(this.DirectoryPath);
            }

            File.WriteAllText(this.FilePath,"");
        }

        public string GetPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
