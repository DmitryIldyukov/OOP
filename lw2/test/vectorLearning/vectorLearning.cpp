#include <iostream>
#include <algorithm>
#include <vector>

int main() 
{
	std::vector<double> numbers(std::istream_iterator<double>(std::cin), (std::istream_iterator<double>()));
	
	while (!std::cin.eof())
	{
		double number;
		if (std::cin >> number)
			numbers.push_back(number);
		else
			break;
	}

	for (int num : numbers) 
	{
		num *= *std::min_element(numbers.begin(), numbers.end());
		std::cout << num << ' ';
	}

	system("pause");
	return 0;
}