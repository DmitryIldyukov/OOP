#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
#include <map>
#include <cstring>
#include <Windows.h>

int main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	std::ifstream dictionary("dictionary.txt");
	if (!dictionary)
	{
		std::cout << "File is not found!\n";
		return 1;
	}

	std::map <std::string, std::string> translater;

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

	bool flag = true;
	while (flag) {
		std::string searchWord;
		bool found = false;
		std::cin >> searchWord;
		std::transform(searchWord.begin(), searchWord.end(), searchWord.begin(), tolower);
		if (searchWord == "...")
		{
			char ch;
			dictionary.close();
			std::cout << "В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.\n";
			std::cin >> ch;
			if (ch == 'Y' || ch == 'y')
			{
				std::ofstream dictionary2("dictionary.txt");
				for (auto pair : translater)
					dictionary2 << pair.first << '>' << pair.second << '\n';
				dictionary2.close();
				std::cout << "Изменения сохранены. До свидания.\n";
			}
			else
				std::cout << "До свидания.\n";
			flag = false;
			break;
		}
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
		if (found == false)
		{
			std::string translate = "";
			std::cout << "Неизвестное слово found \"" << searchWord << "\". Введите перевод или пустую строку для отказа.\n";
			std::cin >> translate;
			std::transform(translate.begin(), translate.end(), translate.begin(), tolower);
			if (translate.length() != 0) {
				translater[searchWord] = translate;
				std::cout << "Слово \"" << searchWord << "\" сохранено в словаре как \"" << translate << "\".\n";
			}
			else 
				std::cout << "Слово \"" << searchWord << "\" проигнорировано.\n";
		}
	}

	system("pause");
	return 0;
}