using System;
using System.Collections.Generic;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            CRational rational = new CRational(2, 3);
            int num = 0;
            Console.WriteLine(rational / num);
        }
    }
}