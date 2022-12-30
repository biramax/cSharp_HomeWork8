/*

Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3

Результирующая матрица будет:
18 20
15 18

*/


// Получает целое число от пользователя
int GetNumber(string message, bool notNull = false, bool notNegative = false, bool lowestValueExists = false, int lowestValue = 0)
{
    bool isCorrect = false;
    int number = 0;

    while (!isCorrect)
    {
        Console.Write(message+": ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out number))
        {
            if (notNull && number == 0)
                Console.WriteLine("Число не должно быть равно нулю.");
            
            else if (notNegative && number < 0)
                Console.WriteLine("Число должно быть положительным.");
            
            else if (lowestValueExists && number <= lowestValue)
                Console.WriteLine($"Число должно быть больше {lowestValue}.");
            
            else
                isCorrect = true;
        }
            
        else
            Console.WriteLine(input.Trim() == "" ? "Вы ничего не ввели." : "Вы ввели некорректные данные.");
    }
    
    return number;
}

// Генерирует матрицу из случайных чисел
int[,] InitMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i ++)
    {
        for (int j = 0; j < columns; j ++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }

    return matrix;
}

// Выводит матрицу в консоль
void PrintMatrix(string message, int[,] matrix)
{
    Console.WriteLine(message+":");

    for (int i = 0; i < matrix.GetLength(0); i ++)
    {
        for (int j = 0; j < matrix.GetLength(1); j ++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

// Упорядочивает по убыванию элементы каждой строки матрицы
int[,] GetResultMatrix(int[,] matrix1, int[,] matrix2) 
{      
    int rows1    = matrix1.GetLength(0);
    int columns1 = matrix1.GetLength(1);

    int rows2    = columns1;
    int columns2 = matrix2.GetLength(1);

    int[,] resultMatrix = new int[rows1, columns2];

    for (int i = 0; i < rows1; i ++)
    {   
        for (int j = 0; j < columns2; j ++)
        {
            resultMatrix[i, j] = 0;
            
            for (int k = 0; k < columns1; k ++)
            {
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }        
    }

    return resultMatrix;
}


Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int rows1    = GetNumber("Введите количество строк первой матрицы", notNull: true, notNegative: true);
int columns1 = GetNumber("Введите количество столбцов первой матрицы", notNull: true, notNegative: true);

// Операция умножения двух матриц выполнима только в том случае, если число столбцов в первой матрице равно числу строк во второй; в этом случае говорят, что матрицы согласованы.
Console.WriteLine($"Количество строк второй матрицы будет равно количеству столбцов первой матрицы: {columns1}");
int rows2    = columns1;
int columns2 = GetNumber("Введите количество столбцов второй матрицы", notNull: true, notNegative: true);

int min = GetNumber("Введите минимальное значение элементов матриц");
int max = GetNumber("Введите максимальное значение элементов матриц", lowestValueExists: true, lowestValue: min);

int[,] matrix1 = InitMatrix(rows1, columns1, min, max);
int[,] matrix2 = InitMatrix(rows2, columns2, min, max);

Console.WriteLine();
PrintMatrix("Сгенерированная матрица 1", matrix1);
Console.WriteLine();
PrintMatrix("Сгенерированная матрица 2", matrix2);
Console.WriteLine();

// Тестируем на матрицах из примера
/*
int[,] matrix1 = 
{
    {2, 4},
    {3, 2}
};

int[,] matrix2 = 
{
    {3, 4},
    {3, 3}
};
*/

int[,] resultMatrix = GetResultMatrix(matrix1, matrix2);
PrintMatrix("Результат умножения матриц", resultMatrix);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();

