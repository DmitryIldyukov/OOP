#include <iostream>
#include <string>
#include <sstream>
#include <vector>

void GeneratePrimeNumbersSet(long long upperBound)
{
    std::vector<int> vec;
    for (long long i = 0; i <= upperBound; i++)
        vec.push_back(i);
    
    for (long long i = 2; i * i <= upperBound; i++)
        if (vec[i] != 0)
            for (int j = i * i; j <= upperBound; j += i)
                vec[j] = 0;

    long long counter = 0;

    for (long long i = 2; i <= upperBound; i++)
        if (vec[i] != 0)
            counter++;
        
    std::cout << counter << '\n';
}

int main(int argc, char* argv[])
{
    if (argc != 2)
    {
        std::cout << "Invalid argument count\n"
            << "Usage: replace.exe <inputFile> <outputFile> <searchString> <replacementString>\n";
        return 1;
    }
    
    std::stringstream numStr ( argv[1] );
    long long num;

    if (numStr >> num)
    {
        if (num > 100000000)
        {
            std::cout << "Error!\nMax number is 100000000\n";
            return 1;
        }
        GeneratePrimeNumbersSet(num);
    }
    else
        std::cout << "Error!\n";

    return 0;
}
