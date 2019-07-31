using _06.ValidPerson.CustomExceptions;
using _06.ValidPerson.Models;
using System;

namespace _06.ValidPerson
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Student georgi = new Student("@@@123^", "gogo123@abv.bg");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine($"Exception thrown: {aoore.Message}");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine($"Exception thrown: {ipne.Message}");
            }
        }
    }
}
