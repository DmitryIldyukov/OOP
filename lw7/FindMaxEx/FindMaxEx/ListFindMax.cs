using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMax
{
    public static class ListFindMax
    {
        public static bool FindMax<T>(List<T> arr, ref T maxValue)
        {
            try
            {
                if (arr.Any())
                {
                    maxValue = arr.Max();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[FindMax] : {e.Message}\nErrorType : {e.GetType()}");
                throw;
            }
        }
    }
}
