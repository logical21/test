using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productList = new List<Product>();

            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            try
            {

                foreach (var item in peopleInfo)
                {
                    string[] elements = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = elements[0];
                    double money = double.Parse(elements[1]);
                    Person person = new Person(name, money);
                    peopleList.Add(person);

                }

                foreach (var item in productInfo)
                {
                    string[] elements = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = elements[0];
                    double cost = double.Parse(elements[1]);
                    Product product = new Product(name, cost);
                    productList.Add(product);


                }


                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string personName = commandArray[0];
                    string productName = commandArray[1];
                    Product product = productList.FirstOrDefault(x => x.Name == productName);

                    try
                    {
                        peopleList.FirstOrDefault(x => x.Name == personName).BuyProduct(product);
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }





                    command = Console.ReadLine();
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;
            }


            foreach (var person in peopleList)
            {

                Console.WriteLine(person.ToString());

            }

        }
    }
}
