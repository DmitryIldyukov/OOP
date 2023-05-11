#include <iostream>
#include <string>

int FlipByte(int number) {
    
    unsigned char result = 0;

    for (int i = 0; i < CHAR_BIT; i++) {
        result <<= 1;
        result |= number & 1;
        number >>= 1;
    }

    return result;
}

bool CheckRange(int number) {
    if ((number >= 0) && (number <= 255))
        return true;
    return false;
}

int main(int argc, char** argv)
{
    /*if (argc != 2) {
        std::cout << "Invalid arguments count\n"
            << "Usage: findtext.exe <file name> <text to search>\n";
        return 1;
    }*/

    int number;

    try
    {
        //num = std::stoi(argv[1]);
        number = 6;
    }
    catch (const std::exception&)
    {
        std::cout << "Invalid argument\n"
            << "A non-numeric value was passed\n";
        return 1;
    }

    if (CheckRange(number))
        std::cout << FlipByte(number) << '\n';
    else {
        std::cout << "Incorrect input data\n"
            << "The entered number is outside the array 0-255\n";
        return 1;
    }
    

    system("pause");
    return 0;
}