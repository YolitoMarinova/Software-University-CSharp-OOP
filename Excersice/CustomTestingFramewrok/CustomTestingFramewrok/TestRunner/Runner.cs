using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;
using CustomTestingFramework.TestRunner.Contracts;
using CustomTestingFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomTestingFramework.TestRunner
{
    public class Runner : IRunner
    {
        private readonly ICollection<string> resultInfo;

        public Runner()
        {
            this.resultInfo = new List<string>();
        }

        public List<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                .LoadFrom(assemblyPath)
                .GetTypes()
                .Where(x=>x.HasAttribute<TestClassAttribute>())
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                    .GetMethods()
                    .Where(x => x.HasAttribute<TestMethodAttribute>())
                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        testMethod.Invoke(testClassInstance, null);

                        resultInfo.Add($"Method: {testMethod.Name} - passed!");
                    }
                    catch (TestException)
                    {
                        resultInfo.Add($"Method: {testMethod.Name} - failed!");
                    }
                    catch
                    {
                        resultInfo.Add($"Method: {testMethod.Name} - unexpected error occured!");
                    }
                }
            }

            return resultInfo.ToList();
        }
    }
}
