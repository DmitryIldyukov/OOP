#include "SortVector.h"

std::vector<double> SortVector(std::vector<double>& numbers)
{
	sort(numbers.begin(), numbers.end());
	return numbers;
}
