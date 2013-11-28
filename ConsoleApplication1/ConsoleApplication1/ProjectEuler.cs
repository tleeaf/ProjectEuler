using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ProjectEuler
    {
        static void Main(string[] args)
        {
            ProjectEuler _e = new ProjectEuler();
            //Test for Euler3()
            /*
            System.Console.WriteLine(_e.Euler3(600851475143,null));
            foreach (long n in _e.Euler_3List(600851475143, null))
            {
                System.Console.WriteLine(n);
            }*/
            //Test for Euler4()
            //System.Console.WriteLine(_e.Euler4(3));
            //System.Console.WriteLine(_e.Euler5(1,20));
            //List<int> L = _e.populateRange(1, 100);
            //System.Console.WriteLine(_e.Euler6(L));
            System.Console.WriteLine(_e.Euler7(10001));
            Console.ReadKey();
        }

        public ProjectEuler()
        {

        }

        //Returns the sum of multiples of 3 and 5 less than num
        public int Euler1(int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //Returns the sum of the of the even fibonnacci terms less than num
        public int Euler2(int num)
        {
            int sum = 0;
            int fib1 = 1;
            int fib2 = 2;
            while (fib2 < num)
            {
                if (fib1 % 2 == 0)
                {
                    sum += fib1;
                }
                if (fib2 % 2 == 0)
                {
                    sum += fib2;
                }
                fib1 = fib1 + fib2;
                fib2 = fib1 + fib2;
            }

            return sum;
        }

        //Returns the largest prime factor of num
        public long Euler3(long num, HashSet<long> pFactors)
        {
            if (pFactors == null)
            {
                pFactors = new HashSet<long>();
            }

            for (long i = 2; i < num/i; i++)
            {
                if (num % i == 0 && isPrime(i))
                {
                    pFactors.Add(i);
                    this.Euler3(num / i, pFactors);
                }

            }
            return pFactors.Max();
        }

        //Returns largest prime factor of num, list of prime factors
        public HashSet<long> Euler_3List(long num, HashSet<long> pFactors)
        {
            if (pFactors == null)
            {
                pFactors = new HashSet<long>();
            }

            for (long i = 2; i < num / i; i++)
            {
                if (num % i == 0 && isPrime(i))
                {
                    pFactors.Add(i);
                    this.Euler3(num / i, pFactors);
                }

            }
            return pFactors;
        }

        //Returns the largest palindrome product of two n digit numbers
        public int Euler4(int n)
        {
            HashSet<int> pals = new HashSet<int>();
            //Generate highest n digit number by concatenating strings
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += "9";
            }
            //Convert the string to int
            int num1 = Convert.ToInt32(str);

            
            for (int k = 0; k < (Math.Pow(10,n)) - 10; k++)
            {
                int num2 = num1;
                for (int j = 0; j < (Math.Pow(10, n)) - 10; j++)
                {
                    int prod = num1 * num2;
                    if (isPalindrome(prod))
                    {
                        pals.Add(prod);
                    }
                    else
                    {
                        num2--;
                    }
                }
                num1--;
            }
            return pals.Max();
        }

        //Returns the smallest number that can be divided by numbers falling in the range [lo,hi]
        public int Euler5(int lo, int hi)
        {
            //Result needs to be at least 'hi'
            int num = hi;
            int diff = hi - lo;
            bool found = false;
            while (!found)
            {
                int count = 0;
                for (int i = lo; i <= hi; i++)
                {
                    if (num % i == 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == diff + 1)
                {
                    return num;
                }
                else
                {
                    num++;
                }
            }
            return 0;
        }
        
        //Returns the difference (square(sums) - sum(squares)) 
        public double Euler6(List<int> L)
        {
            double sumSq = sumofSquares(L);
            double sqSum = squareofSum(L);
            return sqSum - sumSq;
        }

        public int Euler7(int num)
        {
            int count = 0;
            int i = 1;
            do
            {
                i++;
                if (isPrime(i))
                {
                    count++;
                }
            } while (count < num);
            return i;
        }
        //General Utility Functions
        //
        public bool isPrime(long num)
        {
            if(num == 1)
            {
                return false;
            }
            else if (num < 4)
            {
                return true;
            }
            else if(num % 2 == 0)
            {
                return false;
            }
            else if(num < 9)
            {
                return true;
            }
            else if (num % 3 == 0)
            {
                return false;
            }
            else
            {
                double r = Math.Floor(Math.Sqrt(num));
                double f = 5.0;
                while (f <= r)
                {
                    if(num % f == 0)
                    {
                        return false;
                    }
                    if(num % (f+2.0) == 0)
                    {
                        return false;
                    }
                    f += 6;
                }
            }
            return true;
        }

        public bool isPalindrome(int num)
        {
            string str = Convert.ToString(num);
            int len = str.Length;
            int mid = len/2;
            if (len == 1)
            {
                return true;
            }
            for (int i = 0; i < mid; i++)
            {
                if (str[i] != str[len - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public int sumofSquares(List<int> L)
        {
            int result = 0;
            foreach (int i in L)
            {
                result += i*i;
            }
            return result;
        }

        public double squareofSum(List<int> L)
        {
            double sum = L.Sum();
            return Math.Pow(sum,2.0);
        }

        public List<int> populateRange(int lo, int hi)
        {
            List<int> L = new List<int>();
            int val = lo;
            int diff = hi - lo;
            for(int i = lo; i <= hi; i++)
            {
                L.Add(i);
            }
            return L;
        }
    }
}
