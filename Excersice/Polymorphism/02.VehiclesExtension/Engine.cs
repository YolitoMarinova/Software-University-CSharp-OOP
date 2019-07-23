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
            Bus bus = CreateBus();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = commandArgs[0];
                    string vechicleType = commandArgs[1];

                    if (command == "Drive")
                    {
                        double distance = double.Parse(commandArgs[2]);

                        if (vechicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vechicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (vechicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(commandArgs[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                    else if (command == "Refuel")
                    {
                        double fuelAmount = double.Parse(commandArgs[2]);

                        if (vechicleType == "Car")
                        {
                            car.Refuel(fuelAmount);
                        }
                        else if (vechicleType == "Truck")
                        {
                            truck.Refuel(fuelAmount);
                        }
                        else if (vechicleType == "Bus")
                        {
                            bus.Refuel(fuelAmount);
                        }
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
            Console.WriteLine(bus.ToString());
        }

        private Bus CreateBus()
        {
            string[] busArgs = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(busArgs[1]);
            double litersPerKm = double.Parse(busArgs[2]);
            double tankCapacity = double.Parse(busArgs[3]);

            return new Bus(fuelQuantity, litersPerKm,tankCapacity);
        }

        private Truck CreateTruck()
        {
            string[] truckArgs = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(truckArgs[1]);
            double litersPerKm = double.Parse(truckArgs[2]);
            double tankCapacity = double.Parse(truckArgs[3]);

            return new Truck(fuelQuantity, litersPerKm, tankCapacity);
        }

        private Car CreateCar()
        {
            string[] carArgs = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            double fuelQuantity = double.Parse(carArgs[1]);
            double litersPerKm = double.Parse(carArgs[2]);
            double tankCapacity = double.Parse(carArgs[3]);

            return new Car(fuelQuantity, litersPerKm, tankCapacity);
        }
    }
}
