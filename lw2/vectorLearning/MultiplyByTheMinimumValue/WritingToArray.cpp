#include "WritingToArray.h"

std::vector<double> WritingToArray(std::vector<double>& numbers)
{
	double number;
	while (std::cin >> number)
		numbers.push_back(number);
	return numbers;
}
