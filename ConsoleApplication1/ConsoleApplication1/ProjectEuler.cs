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
            System.Console.WriteLine(_e.Euler3(600851475143,null));
            foreach (long n in _e.Euler_3List(600851475143, null))
            {
                System.Console.WriteLine(n);
            }
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
            
        }

        //General Utility Functions
        public bool isPrime(long num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
