#include "NewWord.h"

void NewWord(std::map<std::string, std::string>& translater, std::string searchWord, std::string& translate)
{
	std::transform(translate.begin(), translate.end(), translate.begin(), tolower);
	if (translate.length() != 0) {
		translater[searchWord] = translate;
		std::cout << "����� \"" << searchWord << "\" ��������� � ������� ��� \"" << translate << "\".\n";
	}
	else
		std::cout << "����� \"" << searchWord << "\" ���������������.\n";
}
