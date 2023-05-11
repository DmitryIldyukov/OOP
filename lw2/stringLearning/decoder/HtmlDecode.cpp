#include "HtmlDecode.h"
#include <iostream>
#include <map>
#include <string>

std::map<const char, const std::string> decode = {
	{ '"', "&quot;" }, 
	{ '\'', "&apos;" }, 
	{ '>', "&gt;" }, 
	{ '<', "&lt;" }, 
	{ '&', "&amp;" }
};

std::string HtmlDecode(std::string const& html)
{
	std::string decodedStr = html;

	for (const auto& pair : decode)
	{
		char symbol = pair.first;
		std::string essence = pair.second;

		size_t pos = 0;
		while ((pos = decodedStr.find(essence, pos)) != std::string::npos)
		{
			decodedStr.replace(pos, essence.length(), 1, symbol);
			pos++;
		}
	}

	return decodedStr;
}