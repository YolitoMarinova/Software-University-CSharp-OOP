using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        var fields = classType.GetFields(BindingFlags.Instance
            | BindingFlags.Public | BindingFlags.Static
            | BindingFlags.NonPublic);

        var classInstance = Activator.CreateInstance(classType, new object[] { });


        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in fields.Where(n => requestedFields.Contains(n.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        var publicFields = classType.GetFields(BindingFlags.Instance
            |BindingFlags.Static
            |BindingFlags.Public);
        var privateGetters = classType.GetMethods(BindingFlags.Instance
            | BindingFlags.NonPublic)
            .Where(x=>x.Name.StartsWith("get"));
        var publicSetters = classType.GetMethods(BindingFlags.Instance
            |BindingFlags.Public)
            .Where(x=>x.Name.StartsWith("set"));

        StringBuilder sb = new StringBuilder();

        foreach (var field in publicFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var getter in privateGetters)
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        foreach (var setter in publicSetters)
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        var privateMethods = classType.GetMethods(BindingFlags.Instance
            | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }
}

