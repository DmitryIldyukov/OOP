#include <iostream>
#include <sstream>
#include "GeneratePrimeNumbersSet.h"

int main(int argc, char* argv[])
{
    if (argc != 2)
    {
        std::cout << "Invalid argument count\n"
            << "Usage: replace.exe <inputFile> <outputFile> <searchString> <replacementString>\n";
        return 1;
    }

    std::stringstream numStr(argv[1]);
    long long num;

    if (numStr >> num)
    {
        if (num > 100000000 || num < 1)
        {
            std::cout << "Error!\nMin number is 1\nMax number is 100000000\n";
            return 1;
        }
        GeneratePrimeNumbersSet(num);
    }
    else
        std::cout << "Error!\n";

    return 0;
}
