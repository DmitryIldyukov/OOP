using System;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CRational number = new CRational(23);
                number++;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error name: {e.Message}\nError type: {e.GetType()}");
            }
        }
    }
}
