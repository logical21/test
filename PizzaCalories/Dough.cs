using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2.0;

        private const double MinWeight = 1.0;

        private const double MaxWeight = 200.0;

        private string flourType;

        private string bakingTechnique;

        private double weight;

        private readonly Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        public Dough(string flourType, string bakingTechnique, double weight)
        {

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {

            get { return this.flourType; }

            private set
            {

                if (!this.flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");

                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {

            get { return this.bakingTechnique; }


            private set
            {

                if (!this.bakingTechniques.ContainsKey(value.ToLower()))
                {

                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
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

                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight:f0}..{MaxWeight:f0}].");

                }

                this.weight = value;
            }

        }

        public double CalculateCalories()
        {

            return (BaseCaloriesPerGram * this.Weight) * flourTypes[this.FlourType] * bakingTechniques[this.BakingTechnique];

        }
    }
}
