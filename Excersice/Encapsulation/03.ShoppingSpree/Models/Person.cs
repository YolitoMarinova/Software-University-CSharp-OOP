using _03.ShoppingSpree.ExceptionMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Exceptions.NameCannotBeEmptyException);
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Exceptions.MoneyCannotBeNegativeNumber);
                }

                this.money = value;
            }
        }
        public List<Product> Bag { get; private set; }

        public void AddProduct(Product product)
        {
            if (this.money - product.Cost >= 0)
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.Bag.Add(product);
                this.money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.Bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ",this.Bag)}";
        }
    }
}
