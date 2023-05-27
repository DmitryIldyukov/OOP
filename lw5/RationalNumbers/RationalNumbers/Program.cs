using System;
using System.Collections.Generic;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CRational rational1 = new CRational(2, 3);
                CRational rational2 = new CRational(3, 2);
                bool f = rational1 != rational2;
                Console.WriteLine(f);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error name: {e.Message}\nError type: {e.GetType()}");
            }
        }
    }
}
