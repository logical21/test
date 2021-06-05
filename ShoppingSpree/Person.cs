using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bagOfProducts;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");

                }

                this.name = value;
            }

        }

        public double Money
        {

            get { return this.money; }

            private set
            {
                if (value < 0)
                {

                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");

                }

                this.money = value;

            }
        }

        public IReadOnlyList<Product> BagOfProducts
        {

            get { return this.bagOfProducts.AsReadOnly(); }

        }


        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            var products = this.bagOfProducts.Select(x => x.Name);

            return $"{this.Name} - {string.Join(", ", products)}";
        }
    }
}
