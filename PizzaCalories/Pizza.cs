using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaximumNumberOfToppings = 10;

        private const int MinSymbols = 1;

        private const int MaxSymbols = 15;

        private string pizzaName;

        private Dough pizzaDough;

        private readonly List<Topping> pizzaToppings;

        public Pizza(string name)
        {

            this.PizzaName = name;
            this.pizzaToppings = new List<Topping>();
        }

        public string PizzaName
        {

            get { return this.pizzaName; }

            private set
            {

                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value) ||
                    value.Length < MinSymbols ||
                    value.Length > MaxSymbols)
                {

                    throw new ArgumentException($"Pizza name should be between {MinSymbols} and {MaxSymbols} symbols.");

                }

                this.pizzaName = value;
            }

        }

        public Dough PizzaDough
        {

            get { return this.pizzaDough; }
            set { this.pizzaDough = value; }
        }

        public List<Topping> PizzaToppings
        {
            get { return this.pizzaToppings; }


        }

        public int NumberOfToppings => this.pizzaToppings.Count;

        public void AddTopping(Topping topping)
        {

            if (this.pizzaToppings.Count == MaximumNumberOfToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaximumNumberOfToppings}].");

            }

            this.PizzaToppings.Add(topping);

        }

        public double CalculatePizzaCalories()
        {

            double totalToppingCalories = this.PizzaToppings.Select(x => x.CalculateCalories()).Sum();

            return this.pizzaDough.CalculateCalories() + totalToppingCalories;
        }

    }
}
