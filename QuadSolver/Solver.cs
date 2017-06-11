using System;
using System.Collections.Generic;
using System.Text;

namespace QuadSolver
{
    class Solver
    {

        public static void SolveExp(string eq)
        {
            if (eq == "")
            {
                Console.WriteLine("No Input Given.");
            }
            else
            {
                int first = 0;
                int second = 0;
                int third = 0;
                string currInt = "";
                bool isHat = false;
                for (int i = 0; i < eq.Length; ++i)
                {
                    if (eq[i] == '^')
                    {
                        isHat = true;
                    }
                    else if (isHat)
                    {
                        isHat = false;
                    }
                    else if (eq[i] == '1' || eq[i] == '2' || eq[i] == '3' || eq[i] == '4' || eq[i] == '5' || eq[i] == '6' || eq[i] == '7' || eq[i] == '8' || eq[i] == '9' || eq[i] == '-')
                    {
                        if (i == eq.Length - 1)
                        {
                            currInt += eq[i];
                            if (first == 0)
                            {
                                first = Convert.ToInt32(currInt);
                                currInt = "";
                            }
                            else
                            {
                                third = Convert.ToInt32(currInt);
                                currInt = "";
                            }
                        }
                        else
                        {
                            currInt += eq[i];
                        }
                    }
                    else
                    {

                        if (currInt == "")
                        {
                            if (first == 0)
                            {
                                first = 1;
                            }
                            else if (second == 0)
                            {
                                second = 1;
                            }
                            else
                            {
                                third = 1;
                            }
                        }
                        else
                        {
                            if (first == 0)
                            {
                                first = Convert.ToInt32(currInt);
                                currInt = "";
                            }
                            else if (second == 0)
                            {
                                second = Convert.ToInt32(currInt);
                                currInt = "";
                            }
                            else
                            {
                                third = Convert.ToInt32(currInt);
                                currInt = "";
                            }
                        }
                    }
                }
                var discriminant = second * second - 4 * first * third;
                if (discriminant < 0)
                {
                    Console.WriteLine("No Root Exists.");
                }
                else
                {
                    Root currRoots = quad_form(first, second, third, discriminant);
                    Fraction f = GetFrac(currRoots.Root1, 0.001);
                    Fraction f2 = GetFrac(currRoots.Root2, 0.001);
                    Console.WriteLine("x = " + currRoots.Root1.ToString() + ", x = " + currRoots.Root2.ToString());
                    string factoredExp = String.Empty;
                    if (f.N < 0 && f2.N < 0)
                    {
                        if (f.D == 1 && f2.D == 1)
                        {
                            int numerator = -1 * f.N;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(x+" + numerator.ToString() + ")(x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f.D == 1)
                        {
                            int numerator1 = -1 * f.N;
                            int denominator2 = f2.D;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(x+" + numerator1.ToString() + ")(" + denominator2.ToString() + "x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f2.D == 1)
                        {
                            int denominator1 = f.D;
                            int numerator1 = -1 * f.N;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x+" + numerator1.ToString() + ")(x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else
                        {
                            int denominator1 = f.D;
                            int numerator1 = -1 * f.N;
                            int denominator2 = f2.D;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x+" + numerator1.ToString() + ")(" + denominator2.ToString() + "x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                    }
                    else if (f.N < 0)
                    {
                        if (f.D == 1 && f2.D == 1)
                        {
                            int numerator1 = -1 * f.N;
                            int numerator2 = f2.N;
                            factoredExp = "(x+" + numerator1.ToString() + ")(x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f.D == 1)
                        {
                            int numerator1 = -1 * f.N;
                            int denominator2 = f2.D;
                            int numerator2 = f2.N;
                            factoredExp = "(x+" + numerator1.ToString() + ")(" + denominator2.ToString() + "x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f2.D == 1)
                        {
                            int denominator1 = f.D;
                            int numerator1 = -1 * f.N;
                            int numerator2 = f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x+" + numerator1.ToString() + ")(x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else
                        {
                            int denominator1 = f.D;
                            int numerator1 = -1 * f.N;
                            int denominator2 = f2.D;
                            int numerator2 = f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x+" + numerator1.ToString() + ")(" + denominator2.ToString() + "x-" + numerator2.ToString();
                            Console.WriteLine(factoredExp);
                        }

                    }
                    else if (f2.N < 0)
                    {
                        if (f.D == 1 && f2.D == 1)
                        {
                            int numerator1 = f.N;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(x-" + numerator1.ToString() + ")(x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f.D == 1)
                        {
                            int numerator1 = f.N;
                            int denominator2 = f2.D;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(x-" + numerator1.ToString() + ")(" + denominator2.ToString() + "x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f2.D == 1)
                        {
                            int denominator1 = f.D;
                            int numerator1 = f.N;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x-" + numerator1.ToString() + ")(x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else
                        {
                            int denominator1 = f.D;
                            int numerator1 = f.N;
                            int denominator2 = f2.D;
                            int numerator2 = -1 * f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x-" + numerator1.ToString() + ")(" + denominator2.ToString() + "x+" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                    }
                    else
                    {
                        if (f.D == 1 && f2.D == 1)
                        {
                            int numerator1 = f.N;
                            int numerator2 = f2.N;
                            factoredExp = "(x-" + numerator1.ToString() + ")(x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f.D == 1)
                        {
                            int numerator1 = f.N;
                            int denominator2 = f2.D;
                            int numerator2 = f2.N;
                            factoredExp = "(x-" + numerator1.ToString() + ")(" + denominator2.ToString() + "x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else if (f2.D == 1)
                        {
                            int denominator1 = f.D;
                            int numerator1 = f.N;
                            int numerator2 = f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x-" + numerator1.ToString() + ")(x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                        else
                        {
                            int denominator1 = f.D;
                            int numerator1 = f.N;
                            int denominator2 = f2.D;
                            int numerator2 = f2.N;
                            factoredExp = "(" + denominator1.ToString() + "x-" + numerator1.ToString() + ")(" + denominator2.ToString() + "x-" + numerator2.ToString() + ")";
                            Console.WriteLine(factoredExp);
                        }
                    }
                }

            }

        }



        public static Root quad_form(int a, int b, int c, int disc)
        {

            double root1 = (-b + Math.Sqrt(disc)) / (2.0 * a);
            double root2 = (-b - Math.Sqrt(disc)) / (2.0 * a);
            return new Root(root1, root2);

        }
        public static Fraction GetFrac(double val, double acc)
        {
            var sign = Math.Sign(val);
            if (sign == -1)
            {
                val = Math.Abs(val);
            }
            double MaxError = sign == 0 ? acc : val * acc;
            int n = (int)Math.Floor(val);
            val -= n;
            if (val < MaxError)
            {
                return new Fraction(sign * n, 1);
            }
            if (1 - MaxError < val)
            {
                return new Fraction(sign * (n + 1), 1);
            }
            int low_n = 0;
            int low_d = 1;
            int up_n = 1;
            int up_d = 1;

            while (true)
            {
                int mid_n = low_n + up_n;
                int mid_d = low_d + up_d;

                if (mid_d * (val + MaxError) < mid_n)
                {
                    up_n = mid_n;
                    up_d = mid_d;
                }
                else if (mid_n < (val - MaxError) * mid_d)
                {
                    low_n = mid_n;
                    low_d = mid_d;
                }
                else
                {
                    return new Fraction((n * mid_d + mid_n) * sign, mid_d);
                }
            }
        }

        public struct Root
        {
            public Root(double r1, double r2)
            {
                Root1 = r1;
                Root2 = r2;
            }
            public double Root1 { get; private set; }
            public double Root2 { get; private set; }
        }

        public struct Fraction
        {
            public Fraction(int n, int d)
            {
                N = n;
                D = d;
            }

            public int N { get; private set; }
            public int D { get; private set; }
        }
    }
}
