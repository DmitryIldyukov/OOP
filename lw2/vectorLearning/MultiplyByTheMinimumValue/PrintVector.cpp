#include "PrintVector.h"

void PrintVector(std::vector<double> numbers)
{
    copy(numbers.begin(), numbers.end(), std::ostream_iterator<double>(std::cout, " "));
}
