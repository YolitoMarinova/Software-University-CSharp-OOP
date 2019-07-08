using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.CarsSalesman
{
    public class Starter
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        public void Start()
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = this.CreateEngine(parameters);
                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            if (parameters.Length == 3)
            {
                bool isWeight = int.TryParse(parameters[2], out int weight);

                if (isWeight)
                {
                    return new Car(model, engine, weight);
                }
                else
                {
                    string color = parameters[2];
                    return new Car(model, engine, color);
                }
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                return new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                return new Car(model, engine);
            }
        }

        private Engine CreateEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            if (parameters.Length == 3)
            {
                bool isDisplacement = int.TryParse(parameters[2], out int displacement);

                if (isDisplacement)
                {
                    return new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = parameters[2];
                    return new Engine(model, power, efficiency);
                }
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                return new Engine(model, power, int.Parse(parameters[2]), efficiency);
            }
            else
            {
               return new Engine(model, power);
            }
        }
    }
}
