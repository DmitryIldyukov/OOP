#include "Multiply.h"
#include "WritingToArray.h"
#include "PrintVector.h"
#include "SortVector.h"

int main()
{
    std::vector<double> numbers;

    WritingToArray(numbers);
	Multiply(numbers);
    SortVector(numbers);
    PrintVector(numbers);

    system("pause");
	return 0;
}