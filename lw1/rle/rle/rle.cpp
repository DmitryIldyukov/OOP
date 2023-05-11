#include <iostream>
#include <fstream>

int main()
{
	char ch;
	int quantity;

	std::ifstream file("input.txt");
	if (!file.is_open()) 
	{
		std::cout << "File not open!\n";
		return 1;
	}

	if (file.peek() == EOF) 
	{
		std::cout << "File is empty\n";
		return 1;
	}

	while (!file.eof())
	{
		file >> quantity;
		
	}


	return 0;
}