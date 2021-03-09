using System;

namespace TestProjectGaletinko
{
    class Menu
    {
        public void showMenu()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Task 2");
            Console.WriteLine("Task 3");
            Console.WriteLine("Exit 4");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    CostCalculate ob = new CostCalculate();
                    ob.WriteCostsAndDiscounts();
                    break;
                case '2':
                    Console.Clear();
                    TicTacToe ok = new TicTacToe();
                    ok.WriteMass();
                    break;
                case '3':
                    Trader trader = new Trader();
                    trader.RandTown();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    showMenu();
                    break;
            }
            Console.ReadKey();
        }
    }
}
