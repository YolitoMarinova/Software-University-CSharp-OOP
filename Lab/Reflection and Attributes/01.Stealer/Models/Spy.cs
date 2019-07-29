using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Stealer.Models
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type type = Type.GetType($"_01.Stealer.Models.{investigatedClass}");

            var fields = type.GetFields(BindingFlags.Instance 
                | BindingFlags.Public | BindingFlags.Static 
                | BindingFlags.NonPublic);

            var classInstance = Activator.CreateInstance(type, new object[] { });


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var field in fields.Where(n => requestedFields.Contains(n.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
