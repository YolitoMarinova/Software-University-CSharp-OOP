using _08.MilitaryElite.Enumerations;
using _08.MilitaryElite.Exceptions;
using _08.MilitaryElite.Interfaces;
using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                string type = commandArgs[0];
                int id = int.Parse(commandArgs[1]);
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    Private @private = new Private(id, firstName, lastName, salary);

                    this.army.Add(@private);
                }
                else if (type == "LieutenantGeneral")
                {
                    int[] privatesId = commandArgs
                        .Skip(5)
                        .Select(int.Parse)
                        .ToArray();

                    LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var pid in privatesId)
                    {
                        ISoldier soldierToAdd = this.army
                            .First(s => s.Id == pid);

                        lieutenant.AddPrivate((Private)soldierToAdd);
                    }

                    this.army.Add(lieutenant);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        string[] repairArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        for (int i = 0; i < repairArgs.Length; i += 2)
                        {
                            string partName = repairArgs[i];
                            int hoursWorked = int.Parse(repairArgs[i + 1]);

                            IRepair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsExceptions ice)
                    {

                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        ICommando comando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionsArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missionsArgs.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missionsArgs[i];
                                string state = missionsArgs[i + 1];

                                IMission mission = new Mission(codeName, state);

                                comando.AddMission(mission);
                            }
                            catch (InvalidStatesExceptions ise)
                            {

                            }


                        }

                        this.army.Add(comando);
                    }
                    catch (InvalidCorpsExceptions ice)
                    {
                        continue;
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id,firstName,lastName,codeNumber);

                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
