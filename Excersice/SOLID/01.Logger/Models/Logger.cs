using System.Collections.Generic;
using System.Text;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Models
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders =>
            (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appnder in appenders)
            {
                if(appnder.Level<=error.Level)
                {
                    appnder.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString()); ;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
