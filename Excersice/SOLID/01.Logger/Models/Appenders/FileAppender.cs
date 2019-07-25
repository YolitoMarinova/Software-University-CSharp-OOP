using System;
using System.IO;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumeration;

namespace _01.Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender(ILayout layout,Level level,IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formatedMessage = this.File.Write(this.Layout,error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path,formatedMessage);

            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File Size: {this.File.Size}";
        }
    }
}
