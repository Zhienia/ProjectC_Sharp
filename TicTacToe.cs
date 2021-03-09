using System;

namespace TestProjectGaletinko
{
    class TicTacToe
    {
        private int horizontal_X = 0;
        private int horizontal_O = 0;
        private int vertical_X = 0;
        private int vertical_O = 0;
        private int diagonal_X = 0;
        private int diagonal_O = 0;
        private const int sizePole = 3;
        private char[,] place = new char[sizePole, sizePole];

        public void WriteMass()
        {
            Console.Write("Writing in cells 'x' or 'o' or ' \n\n");

            for (int i = 0; i < sizePole; i++)
            {
                for (int j = 0; j < sizePole; j++)
                {
                    Console.Write("Cell " + i + " " + j + " ");
                    place[i, j] = Convert.ToChar(Console.ReadLine());
                }
            }

            Console.Write("\n");
            for (int i = 0; i < sizePole; i++)
            {
                for (int j = 0; j < sizePole; j++)
                {
                    Console.Write(place[i, j] + " ");
                }
                Console.Write("\n");
            }

            if (!checkHorizontal())
            {
                if (!checkVertical())
                {
                    if (!checkDiagonal())
                    {
                        Console.Write("\'");
                    }
                }
            }
            Console.Write("\n\n");
            BackMenu();
        }


        private bool checkHorizontal()
        {
            for (int i = 0; i < sizePole; i++)
            {
                for (int j = 0; j < sizePole; j++)
                {
                    if (place[i, j] == 'x')
                    {
                        horizontal_X = horizontal_X + 1;
                        if (horizontal_X == 3)
                        {
                            Console.Write('x');
                            horizontal_X = 0;
                            horizontal_O = 0;
                            return true;
                        }
                    }
                    else if (place[i, j] == 'o')
                    {
                        horizontal_O = horizontal_O + 1;
                        if (horizontal_O == 3)
                        {
                            Console.Write('o');
                            horizontal_X = 0;
                            horizontal_O = 0;
                            return true;
                        }
                    }
                }
                horizontal_X = 0;
                horizontal_O = 0;
            }
            return false;
        }

        private bool checkVertical()
        {
            for (int i = 0; i < sizePole; i++)
            {
                for (int l = 0; l < sizePole; l++)
                {
                    if (place[l, i] == 'x')
                    {
                        vertical_X = vertical_X + 1;
                        if (vertical_X == 3)
                        {
                            Console.Write('x');
                            vertical_X = 0;
                            vertical_O = 0;
                            return true;
                        }
                    }
                    else if (place[l, i] == 'o')
                    {
                        vertical_O = vertical_O + 1;
                        if (vertical_O == 3)
                        {
                            Console.Write('o');
                            vertical_X = 0;
                            vertical_O = 0;
                            return true;
                        }
                    }
                }
                vertical_X = 0;
                vertical_O = 0;
            }

            return false;
        }

        private bool checkDiagonal()
        {
            for (int i = 0; i < sizePole; i++)
            {
                if (place[i, i] == 'x')
                {
                    diagonal_X = diagonal_X + 1;
                    if (diagonal_X == 3)
                    {
                        Console.Write('x');
                        diagonal_X = 0;
                        diagonal_O = 0;
                        return true;
                    }
                }
                else if (place[i, i] == 'o')
                {
                    diagonal_O = diagonal_O + 1;
                    if (diagonal_O == 3)
                    {
                        Console.Write('o');
                        diagonal_X = 0;
                        diagonal_O = 0;
                        return true;
                    }
                }
            }

            diagonal_X = 0;
            diagonal_O = 0;

            for (int i = 0, j = sizePole-1; i < sizePole && j >= 0; i++, j--)
            {
                if (place[i, j] == 'x')
                {
                    diagonal_X = diagonal_X + 1;
                    if (diagonal_X == 3)
                    {
                        Console.Write('x');
                        diagonal_X = 0;
                        diagonal_O = 0;
                        return true;
                    }
                }
                else if (place[i, j] == 'o')
                {
                    diagonal_O = diagonal_O + 1;
                    if (diagonal_O == 3)
                    {
                        Console.Write('o');
                        diagonal_X = 0;
                        diagonal_O = 0;
                        return true;
                    }
                }
            }

            return false;
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
                    WriteMass();
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
