using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2.0;

        private const double MinWeight = 1.0;

        private const double MaxWeight = 50.0;

        private string toppingType;

        private double weight;

        private readonly Dictionary<string, double> toppingTypes = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 },
        };

        public Topping(string toppingType, double weight)
        {

            this.ToppingType = toppingType;
            this.Weight = weight;

        }

        public string ToppingType
        {

            get { return this.toppingType; }

            private set
            {

                if (!this.toppingTypes.ContainsKey(value.ToLower()))
                {

                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }

                this.toppingType = value.ToLower();
            }
        }

        public double Weight
        {

            get { return this.weight; }

            private set
            {

                if (value < MinWeight ||
                    value > MaxWeight)
                {

                    throw new ArgumentException($"{FormatText(this.toppingType)} weight should be in the range[{MinWeight:f0}..{MaxWeight:f0}].");

                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {

            return (BaseCaloriesPerGram * this.weight) * toppingTypes[this.toppingType];

        }

        private string FormatText(string text)
        {
            StringBuilder formatedText = new StringBuilder();

            formatedText.Append(text[0].ToString().ToUpper());
            if (text.Length > 1)
            {
                formatedText.Append(text.Substring(1));
            }

            return formatedText.ToString();
        }
    }
}
