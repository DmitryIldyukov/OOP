#include <iostream>
#include <Windows.h>
#define CATCH_CONFIG_MAIN
#include "../../../catch2/catch.hpp"

#include "../Decoder/HtmlDecode.h"

SCENARIO("Test HtmlDecode function")
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	WHEN("Input is empty")
	{
		std::string input = "";

		THEN ("Output is empty") 
		{
			std::string output = HtmlDecode(input);
			std::string out = "";
			CHECK(out == output);
		}
	}
	WHEN("Normal input")
	{
		std::string input = "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s";

		THEN("Output is good")
		{
			std::string output = HtmlDecode(input);
			std::string out = "Cat <says> \"Meow\". M&M's";
			CHECK(out == output);
		}
	}
	WHEN("Non-standard input")
	{
		std::string input = "&&&&;;;;lt;;says&&&gt;";

		THEN("Output is good")
		{
			std::string output = HtmlDecode(input);
			std::string out = "&&&&;;;;lt;;says&&>";
			CHECK(out == output);
		}
	}
}