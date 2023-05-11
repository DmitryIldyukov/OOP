#include <iostream>
#include <string>
#include <fstream>

const int argumentCount = 3;
const int firstArgument = 1;
const int secondArgument = 2;
const std::string invalidArgementMessage = "Invalid arguments count\nUsage: findtext.exe <file name> <text to search>\n";
const std::string notFoundMessage = "Text not found\n";
const std::string failedOpenFileMessage = "Failed to open file for reading\n";

bool FindingTextInStr(std::string str, std::string foundStr) {
    if (str.find(foundStr) != std::string::npos)
        return true;
    return false;
}

int main(int argc, char* argv[]) {
    
    setlocale(LC_ALL, "rus");

    std::string tempStr;
    std::string searchStr;
    int counter = 0;
    int found = 0;
    
    if (argc != argumentCount) {
        std::cout << invalidArgementMessage;
        return 1;
    }

    searchStr = argv[secondArgument];
    if (searchStr.length() == 0) {
        std::cout << notFoundMessage;
        return 1;
    }

    std::ifstream inputFile(argv[firstArgument]);
    if (!inputFile.is_open()) {
        std::cout << failedOpenFileMessage;
        return 1;
    }

    while (!inputFile.eof()) {
        getline(inputFile, tempStr);
        counter++;
        if (FindingTextInStr(tempStr, argv[secondArgument])) {
            found++;
            std::cout << counter << '\n';
        }
    }

    if (found == 0) {
        std::cout << notFoundMessage;
        return 1;
    }

    return 0;
}