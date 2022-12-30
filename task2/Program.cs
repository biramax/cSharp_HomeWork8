/*

Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

// Возвращает номер строки с наименьшей суммой элементов
int RowNumberWithMinElemsSum(int[,] matrix) 
{      
    int numRows    = matrix.GetLength(0);
    int numColumns = matrix.GetLength(1);
    
    int sum       = 0;
    int minSum    = 0;
    int rowNumber = 1;

    for (int i = 0; i < numRows; i ++)
    {   
        sum = 0;

        for (int j = 0; j < numColumns; j ++)
        {
            sum += matrix[i, j];
        }

        // Если это первая строка, просто присваиваем переменной minSum значение суммы элементов
        if (i == 0 || minSum > sum) 
        {
            minSum = sum;
            rowNumber = i + 1;
        }
    }

    return rowNumber;
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int size = GetNumber("Введите размер прямоугольной матрицы (количество строк или столбцов)", notNull: true, notNegative: true);
int min  = GetNumber("Введите минимальное значение элементов матрицы");
int max  = GetNumber("Введите максимальное значение элементов матрицы", lowestValueExists: true, lowestValue: min);

int[,] matrix = InitMatrix(size, size, min, max);

Console.WriteLine();
PrintMatrix("Сгенерированная матрица", matrix);
Console.WriteLine();

Console.WriteLine($"Номер строки с наименьшей суммой элементов: {RowNumberWithMinElemsSum(matrix)}");

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
