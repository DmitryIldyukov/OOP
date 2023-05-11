#include <iostream>
#include <fstream>
#include <vector>
#include <iomanip>

const int argumentCount = 3;
const int matrixSize = 3;
const int miniMatrixSize = 2;
const int numbersAfterComma = 3;
const std::string invalidArgumentCountMessage = "Invalid arguments count\nUsage: invert.exe <matrix file>\n";
const std::string notFoundMessage = "File not found\n";
const std::string matrixNotExistMessage = "Inverse matrix does not exist\n";

void MatrixInitialization(std::istream& matrixFile, double matrix[matrixSize][matrixSize])
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            matrixFile >> matrix[i][j];
        }
    }
}

void InverceMatrixOutput(double inverceMatrix[matrixSize][matrixSize])
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            std::cout << std::fixed << std::setprecision(numbersAfterComma) << inverceMatrix[j][i] << ' ';
        }
        std::cout << '\n';
    }
}

void CheckNull(double inverceMatrix[matrixSize][matrixSize])
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if (inverceMatrix[i][j] == -0)
            {
                inverceMatrix[i][j] = 0;
            }
        }
    }
}

void Multiplicate(double matrix[matrixSize][matrixSize], double multiplier)
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            matrix[i][j] *= 1 / multiplier;
        }
    }
}

double FindingCoefficient(double matrix[matrixSize][matrixSize], double row, double column)
{
    std::vector<double> tempMas;
    double miniMatrix[miniMatrixSize][miniMatrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if (i != row && j != column) 
                tempMas.push_back(matrix[i][j]);
        }
    }

    miniMatrix[0][0] = tempMas[0];
    miniMatrix[0][1] = tempMas[1];
    miniMatrix[1][0] = tempMas[2];
    miniMatrix[1][1] = tempMas[3];

    return miniMatrix[0][0] * miniMatrix[1][1] - miniMatrix[0][1] * miniMatrix[1][0];
}

void FindingInverceMatrix(double matrix[matrixSize][matrixSize], double inverceMatrix[matrixSize][matrixSize])
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if ((i + j) % 2 == 0)
                inverceMatrix[i][j] = FindingCoefficient(matrix, i, j);
            else
                inverceMatrix[i][j] = -FindingCoefficient(matrix, i, j);
        }
    }
}

double FindingTheDeterminant(double matrix[matrixSize][matrixSize])
{
    return matrix[0][0] * matrix[1][1] * matrix[2][2] +
        matrix[0][2] * matrix[1][0] * matrix[2][1] +
        matrix[0][1] * matrix[1][2] * matrix[2][0] -
        matrix[0][2] * matrix[1][1] * matrix[2][0] -
        matrix[0][0] * matrix[1][2] * matrix[2][1] -
        matrix[0][1] * matrix[1][0] * matrix[2][2];
}

bool CheckExistenceInverseMatrix(double determinant)
{
    if (determinant == 0)
        return false;
    return true;
}

int main(int argc, char* argv[]) 
{
    std::cout.precision(numbersAfterComma);
    double matrix[matrixSize][matrixSize];
    double inverceMatrix[matrixSize][matrixSize];

    if (argc != argumentCount) 
    {
        std::cout << invalidArgumentCountMessage;
        return 1;
    }

    std::ifstream matrixFile(argv[1]);
    if (!matrixFile.is_open()) 
    {
        std::cout << notFoundMessage;
        return 1;
    }

    MatrixInitialization(matrixFile, matrix);

    if (!CheckExistenceInverseMatrix(FindingTheDeterminant(matrix))) 
    {
        std::cout << matrixNotExistMessage;
        return 1;
    }

    FindingInverceMatrix(matrix, inverceMatrix);
    CheckNull(inverceMatrix);
    Multiplicate(inverceMatrix, FindingTheDeterminant(matrix));
    InverceMatrixOutput(inverceMatrix);

    return 0;
}