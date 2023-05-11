#include <iostream>
#define CATCH_CONFIG_MAIN
#include "../../../catch2/catch.hpp"

#include "../MultiplyByTheMinimumValue/Multiply.h"
#include "../MultiplyByTheMinimumValue/SortVector.h"
#include "../MultiplyByTheMinimumValue/PrintVector.h"

SCENARIO("Multiplying an empty vector gives an empty vector")
{
	std::vector<double> numbers = {};
	Multiply(numbers);
	REQUIRE(numbers.empty());
}

SCENARIO("A vector of one number should produce the same vector")
{
	std::vector<double> numbers = { 1 };
	Multiply(numbers);
	std::vector<double> nowNumbers = { 1 };
	REQUIRE(numbers == nowNumbers);
}

SCENARIO("If the vector contains the number 0, then all elements must turn to 0")
{
	std::vector<double> numbers = { 1, 0, 99, 5 };
	std::vector<double> nowNumbers = { 0, 0, 0, 0 };
	Multiply(numbers);
	REQUIRE(numbers == nowNumbers);
}

SCENARIO("If the minimum value is less than zero, then all elements of the vector will change sign")
{
	std::vector<double> numbers = { -1, 7, 99, 5 };
	std::vector<double> nowNumbers = { 1, -7, -99, -5 };
	Multiply(numbers);
	REQUIRE(numbers == nowNumbers);
}

SCENARIO("Standart test")
{
	std::vector<double> numbers = { -2, 7, 99, 5 };
	std::vector<double> nowNumbers = { 4, -14, -198, -10 };
	Multiply(numbers);
	REQUIRE(numbers == nowNumbers);
}

SCENARIO("Sort test")
{
	std::vector<double> numbers = { -2, 7, 99, 5 };
	std::vector<double> nowNumbers = { -198, -14, -10, 4 };
	Multiply(numbers);
	SortVector(numbers);
	REQUIRE(numbers == nowNumbers);
}