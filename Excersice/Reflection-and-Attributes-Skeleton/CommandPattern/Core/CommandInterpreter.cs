using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter 
        : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX= "Command";

        public string Read(string args)
        {
            string[] commandInfo = args
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string typeName = commandInfo[0] + COMMAND_POSTFIX;

            string[] commandArgs=commandInfo
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type type = types.FirstOrDefault(x => x.Name == typeName);                       
                                    
            ICommand command = (ICommand)Activator.CreateInstance(type);
            var result=command.Execute(commandArgs);

            return result;
        }
    }
}
