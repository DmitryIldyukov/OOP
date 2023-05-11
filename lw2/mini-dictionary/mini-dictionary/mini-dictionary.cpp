#include <iostream>
#include <Windows.h>
#include <fstream>
#include <map>
#include <algorithm>

#include "DictionaryInitialization.h"
#include "FinishProgram.h"
#include "SearchingWord.h"
#include "NewWord.h"


int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	if (argc != 2)
	{
		return 1;
	}

	std::ifstream dictionary(argv[1]);
	std::map <std::string, std::string> translater;

	if (!dictionary)
	{
		std::cout << "File is not found!\n";
		return 1;
	}

	DictionaryInitialization(dictionary, translater);

	bool isNeededToExit = true;
	while (isNeededToExit) {
		std::string searchWord;
		bool found = false;
		std::getline(std::cin, searchWord);
		if (searchWord.length() == 0)
			continue;
		std::transform(searchWord.begin(), searchWord.end(), searchWord.begin(), tolower);
		if (searchWord == "...") {
			char ch;
			dictionary.close();
			std::cout << "В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.\n";
			std::cin >> ch;
			std::ofstream dictionary("dictionary.txt");
			FinishProgram(dictionary, translater, ch);
			bool flag = false;
			break;
		}
		SearchingWord(found, searchWord, translater);
		if (found == false)
		{
			std::string translate = "";
			std::cout << "Неизвестное слово found \"" << searchWord << "\". Введите перевод или пустую строку для отказа.\n";
			std::getline(std::cin, translate);
			NewWord(translater, searchWord, translate);
		}
	}

	system("pause");
	return 0;
}