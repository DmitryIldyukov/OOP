#include "CCar.h"

std::string const ERROR_SET_GEAR_ENGINE_OFF = "Невозможно переключить передачу, т.к. двигатель выключен";
std::string const ERROR_SET_GEAR_SPEED_LIMIT = "Невозможно переключить передачу, т.к. скорость выходит за пределы!\nДопустимая скорость на ";
std::string const ERROR_SET_GEAR_R = "Невозможно переключиться на заднюю передачу, т.к. машина в движении";

std::map<int, std::pair<int, int>> gearSpeeds = {
	{ GEAR_R, { GEAR_R_MIN_SPEED, GEAR_R_MAX_SPEED } },
	{ GEAR_1, { GEAR_1_MIN_SPEED, GEAR_1_MAX_SPEED } },
	{ GEAR_2, { GEAR_2_MIN_SPEED, GEAR_2_MAX_SPEED } },
	{ GEAR_3, { GEAR_3_MIN_SPEED, GEAR_3_MAX_SPEED } },
	{ GEAR_4, { GEAR_4_MIN_SPEED, GEAR_4_MAX_SPEED } },
	{ GEAR_5, { GEAR_5_MIN_SPEED, GEAR_5_MAX_SPEED } }
};

bool CCar::IsTurnedOn() const
{
	return m_isOn;
}

Direction CCar::GetDirection() const
{
	return m_direction;
}

int CCar::GetSpeed() const
{
	return m_speed;
}

int CCar::GetGear() const
{
	return m_gear;
}

bool CCar::TurnOnEngine()
{
	if (m_speed == GEAR_N_MIN_SPEED && m_gear == GEAR_N_MIN_SPEED)
	{
		m_isOn = true;
		return true;
	}
	else
		return false;
}

bool CCar::TurnOffEngine()
{
	if (m_speed == GEAR_N_MIN_SPEED && m_gear == GEAR_N_MIN_SPEED)
	{
		m_direction = Direction::Stop;
		m_isOn = false;
		return true;
	}
	else
		return false;
}

bool CCar::SetGear(int gear)
{
	if (gear == m_gear)
		return true;
	if (m_isOn == true)
	{
		if (gear == GEAR_N) {
			m_gear = GEAR_N;
			return true;
		}
		if (gear == GEAR_R)
		{
			if (m_direction == Direction::Stop)
			{
				m_gear = GEAR_R;
				return true;
			}
			std::cout << ERROR_SET_GEAR_R << std::endl;
			return false;
		}
		if (m_speed >= gearSpeeds.find(gear)->second.first && m_speed <= gearSpeeds.find(gear)->second.second)
			m_gear = gear;
		else
		{
			std::cout << ERROR_SET_GEAR_SPEED_LIMIT << gear << " передаче: "
				<< gearSpeeds.find(gear)->second.first << " - " << gearSpeeds.find(gear)->second.second << std::endl;
			return false;
		}

		return true;
	}
	std::cout << ERROR_SET_GEAR_ENGINE_OFF << std::endl;
	return false;
}

bool CCar::SetSpeed(int speed)
{
	if (speed == m_speed)
		return true;
	if (m_isOn == true) {
		if (m_gear == GEAR_R) {
			if (speed >= gearSpeeds.find(m_gear)->second.first && speed <= gearSpeeds.find(m_gear)->second.second) {
				if (speed == 0)
					m_direction = Direction::Stop;
				else
					m_direction = Direction::Backward;
				m_speed = speed;
				return true;
			}
		}
		if (m_gear == GEAR_N) {
			if (speed == 0)
				m_direction = Direction::Stop;
			if (speed <= m_speed) {
				m_speed = speed;
				return true;
			}
			return false;
		}
		if (speed >= gearSpeeds.find(m_gear)->second.first && speed <= gearSpeeds.find(m_gear)->second.second) {
			if (speed == 0)
				m_direction = Direction::Stop;
			else
				m_direction = Direction::Forward;
			m_speed = speed;
			return true;
		}

		return false;
	}

	return false;
}
