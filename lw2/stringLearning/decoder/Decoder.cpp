#include <iostream>
#include <string>
#include <fstream>
#include <Windows.h>
#include "HtmlDecode.h"

int main()
{
    std::string htmlText;
    getline(std::cin, htmlText);

    std::cout << HtmlDecode(htmlText) << '\n';

    system("pause");
    return 0;
}