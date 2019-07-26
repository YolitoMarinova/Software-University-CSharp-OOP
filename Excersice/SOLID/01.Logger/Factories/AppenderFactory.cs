using _01.Logger.Exceptions;
using _01.Logger.Models.Appenders;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumeration;
using _01.Logger.Models.Files;
using System;

namespace _01.Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layputType, string levelString)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new IinvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layputType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level); ;
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();

                appender = new FileAppender(layout, level, file); 
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
