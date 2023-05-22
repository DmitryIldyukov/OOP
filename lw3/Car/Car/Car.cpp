#include <iostream>
#include <string>
#include "CCar.h"
#include "CCarController.h"

int main()
{
	setlocale(LC_ALL, "rus");

	CCar car;
	CCarController controller(car, std::cin, std::cout);
	controller.StartController();

	return 0;
}