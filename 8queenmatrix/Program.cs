using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _8queenmatrix
{
    class Program
    {
        public static int[,] board,prev;
        public static int currentrow = 1, startcolumn = 7,exit=0;
        public static void Main(string[] args)
        {
            board=new int[8,8];
            prev = new int[8, 8];
            int g;
            for (int j = 0; j < 8; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    board[j, k] = 0;
                    prev[j, k] = 0;
                }
            }
            for (g = 0; exit != 2; g++)
            {
                goback();//call
                for (; (currentrow < 8)&&(exit!=2); )
                {
                   putqueen();
                }
                if (exit != 2)
                {
                    Console.WriteLine("Solution Number " + g);
                    Console.WriteLine("----------------------");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.WriteLine();
                        for (int k = 0; k < 8; k++)
                        {
                            Console.Write(" " + board[j, k]);
                        }
                    }

                    Console.WriteLine(" ");
                }
                currentrow = 7;
            }
                Thread.Sleep(50000);
            

        }

        static void goback()
        {
            int w;
            for (w = 0; w < 8; w++)
            {
                if (board[currentrow, w] == 1)
                {
                    if (w + 1 < 8)
                    {
                        startcolumn = w + 1;
                        board[currentrow, w] = 0;
                    }
                    else if (currentrow - 1 >= 0)
                    {
                        board[currentrow, w] = 0;
                        currentrow--;
                        goback();
                    }
                    else
                    {
                        exit = 2;
                        break;
                    }
                }
            }
        }


        static int putqueen()
        {
            int j,success=0;
            goback();
            if (exit != 2)
            {
                for (j = startcolumn; j < 8; j++)
                {
                    board[currentrow, j] = 1;
                    success = check();
                    if (success == 0)
                    {
                        board[currentrow, j] = 0;
                    }
                    else
                    {
                        currentrow++;
                        break;
                    }
                }
                startcolumn = 0;
                if (success == 0)
                {
                    --currentrow;
                    if (currentrow >= 0)
                    {
                        return 0;
                    }
                    else
                    {
                        exit = 1;
                        return 0;
                    }

                }
            }
            else
            {
                return 2;
            }
            return 1;
        }



        static int check()
        {
            int j, k;
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    if (board[m, n] == 1)
                    {
                        for (j = 0; j < 8; j++)// horizontal check
                        {
                            if ((j != n)&&(board[m,j]==1))
                            {
                                return 0;
                            }
                        }
                        for (j = 0; j < 8; j++)//vertical check
                        {
                            if((j!=m)&&(board[j,n]==1))
                            {
                                return 0;
                            }
                        }
                        
                        for (j=m+1,k=n+1; (k < 8)&&(j<8); j++,k++)//downright diagonal check
                        {
                            if (board[j, k] == 1)
                            {
                                return 0;
                            }
                        }

                        for (j = m - 1, k = n - 1; (j >= 0) && (k >= 0); j--, k--)//upleft diagonal check
                        {
                            if (board[j, k] == 1)
                            {
                                return 0;
                            }
                        }

                        for (j = m + 1, k = n - 1; (j < 8) && (k >= 0); j++, k--)//downleft diagonal check
                        {
                            if (board[j, k] == 1)
                            {
                                return 0;
                            }
                        }

                        for (j = m - 1, k = n + 1; (j >= 0) && (k < 8); j--, k++)//uprirght diagonal check
                        {
                            if (board[j, k] == 1)
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
            return 1;
        }
    }
}
