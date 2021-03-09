using System;

namespace TestProjectGaletinko
{
    class CostCalculate
    {
        private int count;
        private double[] costs;
        private double[] discounts;

        public void WriteCostsAndDiscounts()
        {
            Console.Write("Writing count of purchases: ");
            count = Convert.ToInt32(Console.ReadLine());
           
            costs = new double[count];
            discounts = new double[count];


            Console.Write("\n");
            for (int i = 0; i < count; i++)
            {
                Console.Write("Writing the cost of buy " + (i + 1) + ": ");
                costs[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("\n");
            for (int i = 0; i < count; i++)
            {
                Console.Write("Writing the discount for buy " + (i + 1) + ": ");
                discounts[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("\n");
            Console.Write("Result: " + CalculateTotalCost());
            Console.Write("\n\n");

            BackMenu();
        }

        private double CalculateTotalCost()
        {
            double totalCost = 0;
            for (int i = 0; i < count; i++)
            {
                if (discounts[i] != 0)
                {
                    double percent = (costs[i] / 100) * discounts[i];
                    totalCost = totalCost + (costs[i] - percent); 
                }
            }

            return totalCost;
        }

        private void BackMenu()
        {
            Console.WriteLine("Replay               1");
            Console.WriteLine("Back to menu         2");
            Console.WriteLine("Exit from program    3");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    WriteCostsAndDiscounts();
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
