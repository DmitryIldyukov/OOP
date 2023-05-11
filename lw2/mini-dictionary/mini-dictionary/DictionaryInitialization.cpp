#include "dictionaryInitialization.h"
#include <string>

void DictionaryInitialization(std::ifstream& dictionary, std::map<std::string, std::string>& translater)
{
	std::string ruWord, enWord, word;
	int counter = 1;
	std::string str;

	while (std::getline(dictionary, str))
	{
		size_t pos = 0;
		pos = str.find('>', pos);
		if (pos == std::string::npos)
			break;
		for (int i = 0; i < pos; i++)
			ruWord += str[i];
		for (int i = pos + 1; i < str.length(); i++)
			enWord += str[i];
		translater[ruWord] = enWord;
		ruWord = "";
		enWord = "";
	}
}
