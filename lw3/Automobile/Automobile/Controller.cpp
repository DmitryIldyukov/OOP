#include "CarController.h"
#include "Car.h"

std::string const INSTRUCTION = "----- Инструкция -----\nInfo - Получить информацию об автомобиле\nEngineOn - Включить двигатель\nEngineOff - Выключить двигатель\nSetGear <передача> - Переключить передачуSetSpeed <скорость> - Изменить скорость автомобиля\nQuit - Выйти из приложения\n";
std::string const ENGINE_ON = "Двигатель: включен";
std::string const ENGINE_OFF = "Двигатель: выключен";
std::string const GET_GEAR = "Передача: ";
std::string const GET_SPEED = "Скорость: ";
std::string const DIRECTION_STOP = "Направление: на месте";
std::string const DIRECTION_FORWARD = "Направление: вперед";
std::string const DIRECTION_BACKWARD = "Направление: назад";
std::string const ERROR_ENGINE_ON = "Невозможно запустить двигатель";
std::string const CORRECT_ENGINE_ON = "Двигатель запущен";
std::string const ERROR_ENGINE_OFF = "Невозможно заглушить двигатель";
std::string const CORRECT_ENGINE_OFF = "Двигатель заглушен";
std::string const INCORRECT_USING_SET_GEAR = "Неправильное использование: SetGear <gear>";
std::string const INVALID_ARGUMENT_GEAR = "Передача должна быть целым числом";
std::string const ERROR_ARGUMENT_GEAR = "Такой передачи не существует";
std::string const SET_GEAR = "Включена передача: ";
std::string const INCORRECT_USING_SET_SPEED = "Неправильное использование: SetSpeed <speed>";
std::string const INVALID_ARGUMENT_SPEED = "Скорость должна быть целым числом";
std::string const ERROR_ARGUMENT_SPEED = "Невозможная скорость на данной передаче";
std::string const SET_SPEED = "Скорость изменена до ";

CarController::CarController(Car& car, std::istream& input, std::ostream& output)
	: m_car(car)
	, m_input(input)
	, m_output(output)
	, m_actionMap({
		{ "Help", bind(&CarController::Help, this, std::placeholders::_1) },
		{ "Info", bind(&CarController::Info, this, std::placeholders::_1) },
		{ "EngineOn", bind(&CarController::EngineOn, this, std::placeholders::_1) },
		{ "EngineOff", bind(&CarController::EngineOff, this, std::placeholders::_1) },
		{ "SetGear", bind(&CarController::SetGear, this, std::placeholders::_1) },
		{ "SetSpeed", bind(&CarController::SetSpeed, this, std::placeholders::_1) },
		{ "Quit", bind(&CarController::Quit, this, std::placeholders::_1) },
		{ "Exit", bind(&CarController::Quit, this, std::placeholders::_1) }
	})
{};

bool CarController::HandleCommand()
{
	std::string comandLine;
	std::getline(m_input, comandLine);
	std::istringstream strm(comandLine);

	std::string action;
	strm >> action;

	auto it = m_actionMap.find(action);
	if (it != m_actionMap.end())
		return it->second(strm);

	return false;
}

bool CarController::Help(std::istream& args)
{
	m_output << INSTRUCTION;
	return true;
}

bool CarController::Info(std::istream& args)
{
	if (m_car.IsTurnedOn())
		m_output << ENGINE_ON << std::endl;
	else
		m_output << ENGINE_OFF << std::endl;
	m_output << GET_GEAR << m_car.GetGear() << std::endl;
	m_output << GET_SPEED << m_car.GetSpeed() << std::endl;
	switch (m_car.GetDirection())
	{
	case Direction::Forward:
		m_output << DIRECTION_FORWARD << std::endl;
		break;
	case Direction::Backward:
		m_output << DIRECTION_BACKWARD << std::endl;
		break;
	case Direction::Stop:
		m_output << DIRECTION_STOP << std::endl;
		break;
	}

	return true;
}

bool CarController::EngineOn(std::istream& args)
{
	if (!m_car.TurnOnEngine()) {
		m_output << ERROR_ENGINE_ON << std::endl;
		return true;
	}
	m_output << CORRECT_ENGINE_ON << std::endl;
	return true;
}

bool CarController::EngineOff(std::istream& args)
{
	if (!m_car.TurnOffEngine()) {
		m_output << ERROR_ENGINE_OFF << std::endl;
		return true;
	}
	m_output << CORRECT_ENGINE_OFF << std::endl;
	return true;
}

bool CarController::SetGear(std::istream& args)
{
	if (args.eof())
	{
		m_output << INCORRECT_USING_SET_GEAR << std::endl;
		return true;
	}
	std::string gearStr;
	args >> gearStr;
	int gear;
	try
	{
		gear = std::stoi(gearStr);
	}
	catch (std::invalid_argument e)
	{
		m_output << INVALID_ARGUMENT_GEAR << std::endl;
		return true;
	}

	if (gear < -1 || gear > 5)
	{
		m_output << ERROR_ARGUMENT_GEAR << std::endl;
		return true;
	}

	if (m_car.SetGear(gear))
		m_output << SET_GEAR << gear << std::endl;
	
	return true;
}

bool CarController::SetSpeed(std::istream& args)
{
	if (args.eof())
	{
		m_output << INCORRECT_USING_SET_SPEED << std::endl;
		return true;
	}
	std::string speedStr;
	args >> speedStr;
	int speed;

	try
	{
		speed = std::stoi(speedStr);
	}
	catch (std::invalid_argument e)
	{
		m_output << INVALID_ARGUMENT_SPEED << std::endl;
		return true;
	}

	if (!m_car.SetSpeed(speed)) {
		m_output << ERROR_ARGUMENT_SPEED << std::endl;
		return true;
	}
	
	m_output << SET_SPEED << speed << std::endl;
	return true;
}

bool CarController::Quit(std::istream& args)
{
	exit(0);
	return true;
}
