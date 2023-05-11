#include "GeneratePrimeNumbersSet.h"

void GeneratePrimeNumbersSet(long long upperBound)
{
    std::vector<int> vec;
    for (long long i = 0; i <= upperBound; i++)
        vec.push_back(i);

    for (long long i = 2; i * i <= upperBound; i++)
        if (vec[i] != 0)
            for (long long j = i * i; j <= upperBound; j += i)
                vec[j] = 0;

    long long counter = 0;

    for (long long i = 2; i <= upperBound; i++)
        if (vec[i] != 0)
            counter++;

    std::cout << counter << '\n';
}
