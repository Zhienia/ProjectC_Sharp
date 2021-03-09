using System;
using System.Collections.Generic;

namespace TestProjectGaletinko
{
    class Trader
    {
        private Random rand = new Random();
        private const int startCountCoin = 50;
        private string nameProductBuy = "";
        private int coin = 0;
        private List<Product> lubek = new List<Product>()
        {
            new Product("salt", 20),
            new Product("fish", 50),
            new Product("cloth", 60),
            new Product("copper", 36),
            new Product("furs", 96)
        };

        private List<Product> reval = new List<Product>()
        {
            new Product("salt", 35),
            new Product("fish", 50),
            new Product("cloth", 40),
            new Product("copper", 60),
            new Product("furs", 45)
        };
        private List<Product> bergen = new List<Product>()
        {
            new Product("salt", 62),
            new Product("fish", 15),
            new Product("cloth", 18),
            new Product("copper", 82),
            new Product("furs", 54)
        };

        public void RandTown()
        {
            Console.Clear();
            string[] towns = { "Lubek", "Reval", "Bergen" };
      
            List<int> numberTown = new List<int>();
            while(numberTown.Count != 3)
            {
                int k = rand.Next(0, 3);
                if (!numberTown.Contains(k))
                {
                    numberTown.Add(k);
                    if (numberTown.Count == 3)
                    {
                        BuyProduct(towns[k], true);
                    }
                    else
                    {
                        BuyProduct(towns[k], false);
                    }
                }
            }

            Console.Write("\n");
            BackMenu();
        }


        private bool BuyProduct(string nameTown, bool isLastTown)
        {
            int numberProduct = 0;
            List<Product> townName = new List<Product>();
            List<Product> productBuy = new List<Product>();
            if (nameTown == "Lubek")
            {
                townName = lubek;
            }
            else if (nameTown == "Reval")
            {
                townName = reval;
            }
            else if (nameTown == "Bergen")
            {
                townName = bergen;
            }


            if (nameProductBuy == "")
            {
                Console.Write("Initial coins: " + startCountCoin + "\n");
                foreach (Product product in townName)
                {
                    if (product.getCostProduct() <= startCountCoin)
                    {
                        productBuy.Add(product);
                    }
                }

                numberProduct = rand.Next(0, productBuy.Count);
                nameProductBuy = productBuy[numberProduct].getNameProduct();
                coin = startCountCoin - productBuy[numberProduct].getCostProduct();
                Console.Write("Buy " + nameProductBuy + " for " + productBuy[numberProduct].getCostProduct() + " coins in " + nameTown + ". " + coin + " coins left.\n");
                productBuy.Clear();
                return true;
            }
            else
            {
                productBuy.Clear();
                foreach (Product product in townName)
                {
                    if (product.getNameProduct() == nameProductBuy && isLastTown != true)
                    {
                        coin = coin + product.getCostProduct();
                        Console.Write("Sell " + nameProductBuy + " for " + product.getCostProduct() + " in " + nameTown + ". " + coin + " coins left.\n");
                        break;
                    }
                    else if (product.getNameProduct() == nameProductBuy && isLastTown == true)
                    {
                        coin = coin + product.getCostProduct();
                        Console.Write("Sell " + nameProductBuy + " for " + product.getCostProduct() + " in " + nameTown + ". \n");
                        Console.Write("Final coins: " + coin + "\n");
                        return false;
                    }
                }

                foreach (Product product in townName)
                {
                    if (product.getCostProduct() <= coin)
                    {
                        productBuy.Add(product);
                    }
                }

                numberProduct = rand.Next(0, productBuy.Count);
                nameProductBuy = productBuy[numberProduct].getNameProduct();
                coin = coin - productBuy[numberProduct].getCostProduct();
                Console.Write("Buy " + nameProductBuy + " for " + productBuy[numberProduct].getCostProduct() + " coins in " + nameTown + ". " + coin + " coins left.\n");
                productBuy.Clear();
            }

            return true;
        }

        private void BackMenu()
        {
            Console.WriteLine("Replay              1");
            Console.WriteLine("Back to menu        2");
            Console.WriteLine("Exit from program   3");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    nameProductBuy = "";
                    coin = 0;
                    RandTown();
                    break;
                case '2':
                    Console.Clear();
                    Menu menu = new Menu();
                    menu.showMenu();
                    break;
                case '3':
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    BackMenu();
                    break;
            }
        }
    }
}
