namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            FamilyCar familyCar = new FamilyCar(100,10);

           // System.Console.WriteLine(familyCar.FuelConsumption);

            SportCar sportCar = new SportCar(100,20);

            System.Console.WriteLine(sportCar.FuelConsumption);
        }
    }
}
