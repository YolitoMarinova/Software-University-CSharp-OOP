using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumeration;
using System;
using System.Globalization;

namespace _01.Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int messagesAppended;

        public ConsoleAppender(ILayout layout,Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formatedMessage = String.Format(format,
                dateTime.ToString(DateTimeFormats.LoggerFormat,
                CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formatedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
