#include <iostream>
#include <Windows.h>
#define CATCH_CONFIG_MAIN
#include "../../../catch2/catch.hpp"

#include "../mini-dictionary/DictionaryInitialization.h"
#include "../mini-dictionary/FinishProgram.h"
#include "../mini-dictionary/SearchingWord.h"
#include "../mini-dictionary/NewWord.h"

SCENARIO("Test DictionaryInitialization function")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("Input file is empty")
	{
		std::map<std::string, std::string> translater;
		std::ifstream dictionary("empty.txt");
		THEN("Dictionary is also empty")
		{
			DictionaryInitialization(dictionary, translater);
			CHECK(translater.empty());
		}
	}

	WHEN("Input file has 1 translation")
	{
		std::map<std::string, std::string> translater, result = { {"кошка", "cat"} };
		THEN("Dictionary also has 1 translation")
		{
			std::ifstream dictionary("first.txt");
			DictionaryInitialization(dictionary, translater);
			CHECK(translater == result);
		}
	}

	WHEN("Input file has many translation")
	{
		std::map<std::string, std::string> translater, result = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} };
		THEN("Dictionary also has 1 translation")
		{
			std::ifstream dictionary("second.txt");
			DictionaryInitialization(dictionary, translater);
			CHECK(translater == result);
		}
	}
}

SCENARIO("Test SearchingWord dunction")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("If the word is in the dictionary")
	{
		bool found = false;
		std::string searchWord = "Hello";
		std::map<std::string, std::string> translater = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} };
		SearchingWord(found, searchWord, translater);
		CHECK(found == false);
	}

	WHEN("If the word is not in the dictionary")
	{
		bool found = false;
		std::string searchWord = "кошка";
		std::map<std::string, std::string> translater = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} };
		SearchingWord(found, searchWord, translater);
		CHECK(found == true);
	}
}

SCENARIO("Test NewWord function")
{
	WHEN("If not save")
	{
		std::string notFoundWord = "word";
		std::string input = "";
		std::map<std::string, std::string> translater = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} },
			result = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} };
		NewWord(translater, notFoundWord, input);
		CHECK(translater == result);
	}

	WHEN("If save")
	{
		std::string notFoundWord = "word";
		std::string input = "—лово";
		std::map<std::string, std::string> translater = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} },
			result = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"}, {"word", "слово"} };
		NewWord(translater, notFoundWord, input);
		CHECK(translater == result);
	}

	WHEN("If phrase")
	{
		std::string notFoundWord = "ƒоброе утро";
		std::string input = "good morning";
		std::map<std::string, std::string> translater = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"} },
			result = { {"кошка", "cat"}, {"мышь", "mouse"}, {"ball", "м€ч"}, {"м€со", "meat"}, {"ƒоброе утро", "good morning"} };
		NewWord(translater, notFoundWord, input);
		CHECK(translater == result);
	}
}