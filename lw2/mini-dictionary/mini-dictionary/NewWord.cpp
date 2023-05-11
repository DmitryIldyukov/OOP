#include "NewWord.h"

void NewWord(std::map<std::string, std::string>& translater, std::string searchWord, std::string& translate)
{
	std::transform(translate.begin(), translate.end(), translate.begin(), tolower);
	if (translate.length() != 0) {
		translater[searchWord] = translate;
		std::cout << "Слово \"" << searchWord << "\" сохранено в словаре как \"" << translate << "\".\n";
	}
	else
		std::cout << "Слово \"" << searchWord << "\" проигнорировано.\n";
}
