﻿using _01.Stealer.Models;
using System;

namespace _01.Stealer
{
    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("Hacker","username","password");

            Console.WriteLine(result);
        }
    }
}
