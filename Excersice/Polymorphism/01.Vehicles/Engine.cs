using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles
{
    public class Engine
    {
        public void Run()
        {
            Car car = CreateCar();
            Truck truck = CreateTruck();
            
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = commandArgs[0];
                    string vechicleType = commandArgs[1];

                    switch (command)
                    {
                        case "Drive":
                            double distance = double.Parse(commandArgs[2]);

                            if (vechicleType == "Car")
                            {
                                Console.WriteLine(car.Drive(distance));
                            }
                            else if (vechicleType == "Truck")
                            {
                                Console.WriteLine(truck.Drive(distance));
                            }
                            break;
                        case "Refuel":
                            double fuelAmount = double.Parse(commandArgs[2]);

                            if (vechicleType == "Car")
                            {
                                car.Refuel(fuelAmount);
                            }
                            else if (vechicleType == "Truck")
                            {
                                truck.Refuel(fuelAmount);
                            }
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
                
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private Truck CreateTruck()
        {
            string[] truckInput = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(truckInput[1]);
            double litersPerKm = double.Parse(truckInput[2]);

            return new Truck(fuelQuantity, litersPerKm);
        }

        private Car CreateCar()
        {
            string[] carInput = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(carInput[1]);
            double litersPerKm = double.Parse(carInput[2]);

            return new Car(fuelQuantity,litersPerKm);
        }
    }
}
