#pragma once
#include <iostream>
#include <string>
#include <functional>
#include <map>
#include <sstream>

class CCar;

class CCarController
{
public:
	/// <summary>
	/// Создание контроллера
	/// </summary>
	/// <param name="car"></param>
	/// <param name="input"></param>
	/// <param name="output"></param>
	CCarController(CCar& car, std::istream& input, std::ostream& output);
	bool HandleCommand();

private:
	/// <summary>
	/// Получить интрукцию
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool Help(std::istream& args);
	/// <summary>
	/// Получить информацию о машине
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool Info(std::istream& args);
	/// <summary>
	/// Включить двигатель
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool EngineOn(std::istream& args);
	/// <summary>
	/// Выключить двигатель
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool EngineOff(std::istream& args);
	/// <summary>
	/// Задать передачу
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool SetGear(std::istream& args);
	/// <summary>
	/// Задать скорость
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool SetSpeed(std::istream& args);
	/// <summary>
	/// Завершить программу
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	bool Quit(std::istream& args);

private:
	using Handler = std::function<bool(std::istream& args)>;
	using ActionMap = std::map<std::string, Handler>;

	CCar& m_car;
	std::istream& m_input;
	std::ostream& m_output;

	const ActionMap m_actionMap;
};