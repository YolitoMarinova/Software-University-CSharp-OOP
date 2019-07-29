using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.Public
            | BindingFlags.NonPublic)
            .Where(m => m.CustomAttributes
            .Any(x=>x.AttributeType==typeof(AuthorAttribute)));


        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes(false);

            foreach (AuthorAttribute attr in attributes)
            {
                Console.WriteLine($"{method.Name} is written by {attr.Name}");
            }
        }
    }
}
