using System;
using System.IO;
using System.Linq;
using System.Globalization;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumeration;
using _01.Logger.Models.IOManagment;

namespace _01.Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string CURRENT_DIRECTORY = "\\logs\\";
        private const string CURRENT_PATH = "log.txt";

        private string curretnPath;
        private IOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(CURRENT_DIRECTORY,CURRENT_PATH);
            this.curretnPath = this.IOManager.GetPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = curretnPath + CURRENT_DIRECTORY + CURRENT_PATH;
        }

        public string Path { get; }

        public ulong Size => GetFIleSize();


        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedMessage=String.Format(format,
                dateTime.ToString(DateTimeFormats.LoggerFormat,
                CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            return formatedMessage;
        }
        private ulong GetFIleSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(x => Char.IsLetter(x))
                .Sum(x => (int)x);

            return size;
        }
    }
}
