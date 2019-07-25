using _01.Logger.Factories;
using _01.Logger.Models.Contracts;
using System;
using System.Linq;

namespace _01.Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command!="END")
            {
                string[] erroeArgs = command
                    .Split("|")
                    .ToArray();

                string level = erroeArgs[0];
                string date = erroeArgs[1];
                string message = erroeArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date,level,message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.logger.Log(error);
            }

            Console.WriteLine(this.logger.ToString()); ;
        }
    }
}
