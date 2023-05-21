﻿#include <iostream>
#include <string>
#include "CCar.h"
#include "CCarController.h"

std::string const UNKNOWN_COMMAND = "Неизвестная команда! Попробуйте \"Help\" чтобы получить инструкцию по использованию";

int main()
{
	setlocale(LC_ALL, "rus");

	CCar car;
	CCarController controller(car, std::cin, std::cout);

	while (!std::cin.eof() && !std::cin.fail())
	{
		std::cout << "> ";
		if (!controller.HandleCommand())
			std::cout << UNKNOWN_COMMAND << std::endl;
	}

	return 0;
}