#include <iostream>
#include <Windows.h>
#define CATCH_CONFIG_MAIN
#include "../../../../catch2/catch.hpp"

#include "../Car/CCar.h"

SCENARIO("Test starting values of car")
{
	CCar car;
	THEN("Engine is switched off, speed is zero and gear is zero too")
	{
		REQUIRE(car.IsTurnedOn() == false);
		REQUIRE(car.GetDirection() == Direction::Stop);
		REQUIRE(car.GetGear() == 0);
		REQUIRE(car.GetSpeed() == 0);
		std::cout << "Test starting values of car - completed" << std::endl;
	}
}

SCENARIO("Test TurnOnEngine function")
{
	WHEN("Engine off")
	{
		CCar car;
		THEN("Engine will be on")
		{
			car.TurnOnEngine();
			REQUIRE(car.IsTurnedOn() == true);
			std::cout << "Test TurnOnEngine function when engine off - completed" << std::endl;
		}
	}
	WHEN("Engine on")
	{
		CCar car;
		car.TurnOnEngine();
		THEN("Engine will be on")
		{
			car.TurnOnEngine();
			REQUIRE(car.IsTurnedOn() == true);
			std::cout << "Test TurnOnEngine function when engine on - completed" << std::endl;
		}
	}
}

SCENARIO("Test TurnOffEngine function")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("Engine on")
	{
		CCar car;
		car.TurnOnEngine();
		THEN("Engine will be off")
		{
			car.TurnOffEngine();
			REQUIRE(car.IsTurnedOn() == false);
			std::cout << "Test TurnOffEngine function when engine on- completed" << std::endl;
		}
	}

	WHEN("Engine off")
	{
		CCar car;
		THEN("Engine will be off")
		{
			car.TurnOffEngine();
			REQUIRE(car.IsTurnedOn() == false);
			std::cout << "Test TurnOffEngine function when engine off - completed" << std::endl;
		}
	}

	WHEN("Engine on and speed more than 0")
	{
		CCar car;
		car.TurnOnEngine();
		car.SetGear(1);
		car.SetSpeed(10);
		THEN("Engine stays on")
		{
			car.TurnOffEngine();
			REQUIRE(car.IsTurnedOn() == true);
			std::cout << "Test TurnOffEngine function when engine on and speed more than 0 - completed" << std::endl;
		}
	}
}

SCENARIO("Test SetGear function")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("Gear with the engine off")
	{
		CCar car;
		THEN("Gear will remain the same.")
		{
			car.SetGear(1);
			REQUIRE(car.GetGear() == 0);
			std::cout << "Test SetGear function when gear with the engine off - completed" << std::endl;
		}
	}
	WHEN("Switching to the same gear")
	{
		CCar car;
		THEN("The gear will remain the same")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(10);
			car.SetGear(1);
			REQUIRE(car.GetGear() == 1);
			std::cout << "Test SetGear function when switching to the same gear - completed" << std::endl;
		}
	}
	WHEN("Gear with the engine on and speed in acceptable values ")
	{
		CCar car;
		THEN("Gear will be switch")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(10);
			REQUIRE(car.GetGear() == 1);
			std::cout << "Test SetGear function when gear with the engine on and speed in acceptable values - completed" << std::endl;
		}
	}
	WHEN("Gear with the engine on and speed in invalid values ")
	{
		CCar car;
		THEN("Gear will be not switch")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(10);
			car.SetGear(4);
			REQUIRE(car.GetGear() == 1);
			std::cout << "Test SetGear function when gear with the engine on and speed in invalid values - completed" << std::endl;
		}
	}
	WHEN("Now the first gear and we switch to reverse gear")
	{
		CCar car;
		THEN("Gear will be not switch")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(10);
			car.SetGear(-1);
			REQUIRE(car.GetGear() == 1);
			std::cout << "Test SetGear function when now the first gear and we switch to reverse gear - completed" << std::endl;
		}
	}
	WHEN("Now reverse gear and we want to shift into first gear")
	{
		CCar car;
		THEN("Gear will be not switch")
		{
			car.TurnOnEngine();
			car.SetGear(-1);
			car.SetSpeed(10);
			car.SetGear(1);
			REQUIRE(car.GetGear() == -1);
			std::cout << "Test SetGear function when now reverse gear and we want to shift into first gear - completed" << std::endl;
		}
	}
}

SCENARIO("Test SetSpeed function")
{
	WHEN("Engine off")
	{
		CCar car;
		THEN("Speed will be 0")
		{
			car.SetSpeed(10);
			REQUIRE(car.GetSpeed() == 0);
			std::cout << "Test SetSpeed function when engine off - completed" << std::endl;
		}
	}
	WHEN("Gear allows you to shift at speed")
	{
		CCar car;
		THEN("Speed change")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(30);
			REQUIRE(car.GetSpeed() == 30);
			car.SetGear(3);
			car.SetSpeed(50);
			REQUIRE(car.GetSpeed() == 50);
			std::cout << "Test SetSpeed function when gear allows you to shift at speed - completed" << std::endl;
		}
	}
	WHEN("Gear doesn't allows you to shift at speed")
	{
		CCar car;
		THEN("Speed don't change")
		{
			car.TurnOnEngine();
			car.SetGear(1);
			car.SetSpeed(40);
			REQUIRE(car.GetSpeed() == 0);
			car.SetSpeed(30);
			car.SetGear(3);
			car.SetSpeed(10);
			REQUIRE(car.GetSpeed() == 30);
			std::cout << "Test SetSpeed function when gear doesn't allows you to shift at speed - completed" << std::endl;
		}
	}
}