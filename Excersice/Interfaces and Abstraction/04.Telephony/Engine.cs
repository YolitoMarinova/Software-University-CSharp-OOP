using _04.Telephony.Exceptions;
using _04.Telephony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
    public class Engine
    {
        private Smartphone smartphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public Engine(Smartphone smartphone)
        {
            this.smartphone = smartphone;
        }

        public void Run()
        {
            string[] phonesNumbers = Console.ReadLine().Split();
            string[] brows = Console.ReadLine().Split();

            CallNumbers(phonesNumbers);
            BrowseURLs(brows);
        }

        private void BrowseURLs(string[] brows)
        {
            foreach (var url in brows)
            {
                try
                {
                    Console.WriteLine(this.smartphone.BrowsInWWW(url));
                }
                catch (InvalidURLException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }

        private void CallNumbers(string[] phonesNumbers)
        {
            foreach (var number in phonesNumbers)
            {
                try
                {

                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
            }
        }
    }
}
