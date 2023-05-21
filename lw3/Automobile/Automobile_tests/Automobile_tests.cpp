#include <iostream>
#include <Windows.h>

#include "../../../../catch2/catch.hpp"
#define CATCH_CONFIG_MAIN
#include "../Automobile/CarController.h"
#include "../Automobile/Car.h"

SCENARIO("Test starting values of car")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("Car is created")
	{
		Car car;
		THEN("Engine is off, gear is zero, speed is zero, direction is stop")
		{
			CHECK(car.IsTurnedOn() == false);
			CHECK(car.GetGear() == GEAR_N);
			CHECK(car.GetSpeed() == GEAR_N_MIN_SPEED);
			CHECK(car.GetDirection() == START_DIRECTION);
		}
	}
}