#include <iostream>
#include <Windows.h>
#define CATCH_CONFIG_MAIN
#include "../../../catch2/catch.hpp"

SCENARIO("Entered number 0") 
{
	std::istringstream input('0');
	std::string outStr = "Error!\nMin number is 1\nMax number is 100000000\n";


}