#include "SearchingWord.h"

void SearchingWord(bool& found, std::string searchWord, std::map<std::string, std::string>& translater)
{
	for (auto pair : translater)
	{
		if (pair.first == searchWord)
		{
			std::cout << pair.second << '\n';
			found = true;
		}
		if (pair.second == searchWord)
		{
			std::cout << pair.first << '\n';
			found = true;
		}
	}
}
