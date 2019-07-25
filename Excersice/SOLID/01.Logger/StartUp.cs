using _01.Logger.Core;
using _01.Logger.Factories;
using _01.Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Logger
{
    public class StartUp
    {
        public static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Logger.Models.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount,
            ICollection<IAppender> appenders,
            AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string type = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string level = "INFO";

                if (appendersInfo.Length == 3)
                {
                    level = appendersInfo[2];
                }

                IAppender appender;

                try
                {
                    appender = appenderFactory.GetAppender(type, layoutType, level);

                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
