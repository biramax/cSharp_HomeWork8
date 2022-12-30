/*

Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

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
int[,] SortDescMatrixElemsInRows(int[,] matrix) 
{      
    int rows    = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    
    int[,] sortedMatrix = new int[rows, columns];

    int[] arr = new int[columns];

    for (int i = 0; i < rows; i ++)
    {   
        for (int j = 0; j < columns; j ++)
        {
            arr[j] = matrix[i, j];
        }
        
        Array.Sort(arr);
        Array.Reverse(arr);

        for (int k = 0; k < columns; k ++)
        {
            sortedMatrix[i, k] = arr[k];
        }
    }

    return sortedMatrix;
}


Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int rows    = GetNumber("Введите количество строк матрицы", notNull: true, notNegative: true);
int columns = GetNumber("Введите количество столбцов матрицы", notNull: true, notNegative: true);
int min     = GetNumber("Введите минимальное значение элементов матрицы");
int max     = GetNumber("Введите максимальное значение элементов матрицы", lowestValueExists: true, lowestValue: min);

int[,] matrix = InitMatrix(rows, columns, min, max);

Console.WriteLine();
PrintMatrix("Сгенерированная матрица", matrix);
Console.WriteLine();

int[,] sortedMatrix = SortDescMatrixElemsInRows(matrix);
PrintMatrix("Матрица с упорядоченными по убыванию элементами каждой строки", sortedMatrix);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
