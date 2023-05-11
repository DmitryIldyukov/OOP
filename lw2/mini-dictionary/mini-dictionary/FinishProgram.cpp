#include "finishProgram.h"

void FinishProgram(std::ofstream& dictionary, std::map<std::string, std::string> translater, char ch)
{
	if (ch == 'Y' || ch == 'y')
	{
		for (auto pair : translater)
			dictionary << pair.first << '>' << pair.second << '\n';
		dictionary.close();
		std::cout << "Изменения сохранены. До свидания.\n";
	}
	else
		std::cout << "До свидания.\n";
}
