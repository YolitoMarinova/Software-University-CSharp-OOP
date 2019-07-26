using _01.Logger.Models.Contracts;
using System.IO;

namespace _01.Logger.Models.IOManagment
{
    public class IOManager : IIOManager
    {
        private string path;
        private string directory;
        private string file;

        public IOManager()
        {
            this.path = this.GetPath();
        }

        public IOManager(string directory, string file)
            : this()
        {
            this.directory = directory;
            this.file = file;
        }

        public string DirectoryPath 
            => this.path + this.directory;

        public string FilePath 
            => this.DirectoryPath + this.file;

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
