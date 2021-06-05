using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Pizza pizza;
            Dough dough;

            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];

                pizza = new Pizza(pizzaName);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;

            }

            try
            {
                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string flourType = doughInfo[1];

                string bakingTechnique = doughInfo[2];

                double weight = double.Parse(doughInfo[3]);

                dough = new Dough(flourType, bakingTechnique, weight);

                pizza.PizzaDough = dough;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;

            }

            string toppingInfo = Console.ReadLine();

            while (toppingInfo != "END")
            {

                try
                {
                    string[] toppingInfoArray = toppingInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                    string toppingType = toppingInfoArray[1];
                    double toppingWeight = double.Parse(toppingInfoArray[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;


                }


                toppingInfo = Console.ReadLine();
            }


            try
            {
                Console.WriteLine($"{pizza.PizzaName} - {pizza.CalculatePizzaCalories():f2} Calories.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }
    }
}
