#include "Multiply.h"

void Multiply(std::vector<double>& numbers)
{
	if (numbers.size() == 0) 
		return;
	const double minEl = *std::min_element(numbers.begin(), numbers.end());
	std::transform(numbers.begin(), numbers.end(), numbers.begin(), [minEl](double x) { return x * minEl; });
}