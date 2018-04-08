using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    class Solution
    {
        public static Solution s = new Solution();
        public int solution(string [] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int sol=0;
            int row = 0;
            int col = 0;
            int[] col_n = new int[2];
            bool flag = false;
            int temp = 0;
            int[] tempp = new int[2];
            

            for (int i = 0; i<B.Length;i++)
            {
                char[] oo = B[i].ToCharArray();
                if(oo.Contains('O'))
                {
                    row = i;
                    break;
                }
            }
            Console.WriteLine(row);
            char[] ooo = B[row].ToCharArray();
            for (int j=0; j<B.Length; j++)
            {
                if(ooo[j]=='O')
                {
                    col = j;
                    break;
                }
            }
            Console.WriteLine(col);

            while (!flag)
            {
                sol = MyLoop(row, col);
            }

            int IfTwo(int r, int[] col_nn, int t)
            {
                temp = 0;
                tempp[0] = MyLoop(r, col_nn[0]);
                Console.WriteLine(tempp[0]);
                tempp[1] = MyLoop(r, col_nn[1]);
                Console.WriteLine(tempp[1]);
                int re = tempp.Max();
                temp = t + re;
                return temp;
            }

            int MyLoop(int r, int c)
            {
                Console.WriteLine(temp);
                Console.WriteLine(r);
                Console.WriteLine(c);
                
                if ((B.Length <= 2) || r == 0 || r == 1 || c == 1 || (c == B.Length - 2))
                {
                    flag = true;
                }
                else
                {
                    char[] nowJ = B[r].ToCharArray();
                    char[] nowA = B[r - 1].ToCharArray();
                    char[] nextJ = B[r - 2].ToCharArray();
                    if (c == 0 && nowA[c + 1] != 'X')
                    {
                        flag = true;
                    }
                    else if (c == 0 && nowA[c + 1] == 'X' && nextJ[c + 2] == 'X')
                    {
                        flag = true;
                    }
                    else if (c == B.Length-1 && nowA[c - 1] != 'X')
                    {
                        flag = true;
                    }
                    else if (c == B.Length-1 && nowA[c - 1] == 'X' && nextJ[c - 2] == 'X')
                    {
                        flag = true;
                    }
                    else
                    {
                        if (c == 0)
                        {
                            temp++;
                            row = r - 2;
                            col = c + 2;
                        }
                        else if (c == B.Length-1)
                        {
                            temp++;
                            row = r - 2;
                            col = c - 2;
                        }
                        else
                        {
                            if (nowA[c - 1] != 'X' && nowA[c + 1] == 'X')
                            {
                                if (nextJ[c + 2] == 'X')
                                {
                                    flag = true;
                                }
                                else
                                {
                                    temp++;
                                    row = r - 2;
                                    col = c + 2;
                                }
                            }
                            else if (nowA[c - 1] == 'X' && nowA[c + 1] != 'X')
                            {
                                if (nextJ[c - 2] == 'X')
                                {
                                    flag = true;
                                }
                                else
                                {
                                    temp++;
                                    row = r - 2;
                                    col = c - 2;
                                }
                            }
                            else
                            {
                                if (nextJ[c - 2] == 'X' && nextJ[c + 2] != 'X')
                                {
                                    temp++;
                                    row = r - 2;
                                    col = c + 2;
                                }
                                else if (nextJ[c - 2] != 'X' && nextJ[c + 2] == 'X')
                                {
                                    temp++;
                                    row = r - 2;
                                    col = c - 2;
                                }
                                else if (nextJ[c - 2] == 'X' && nextJ[c + 2] == 'X')
                                {
                                    flag = true;
                                }
                                else
                                {
                                    temp++;
                                    row = r - 2;
                                    col_n[0] = c - 2;
                                    col_n[1] = c + 2;
                                    temp = IfTwo(row, col_n, temp);
                                }
                            }
                        }
                    }

                }
                return temp;
            }
            Console.WriteLine(sol);
            return sol;
        }

        public static void Main()
        {
            string[] B = new string[6];
            B[0] = "..X...";
            B[1] = "......";
            B[2] = "....X.";
            B[3] = "......";
            B[4] = "..X.X.";
            B[5] = "...O..";
            
            s.solution(B);
            while (true)
            {
                
            }
        }
    }

    
    
}
