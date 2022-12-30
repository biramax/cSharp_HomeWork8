/*

Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

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

// Выводит матрицу в консоль
void PrintMatrix(string message, string[,] matrix)
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

// Добавляет нули слева к числу.
// Например, если количество элементов в матрице 765, то функция для значения элемента 3 вернёт 003.
string AddLeftZerosToDigit(int num, int elCnt)
{
    string numStr   = Convert.ToString(num);
    string elCntStr = Convert.ToString(elCnt);

    int dif = elCntStr.Length - numStr.Length;

    for (int i = 0; i < dif; i ++)
        numStr = "0"+numStr;

    return numStr;
}

// Заполняет спирально матрицу любого размера.
string[,] BuildSpiralMatrix(int rows, int columns) 
{
    string[,] arr = new string[rows, columns];

    int elCnt = rows * columns; // Число элементов в матрице.
    
    int k   = 0; // Коэффициент, который участвует в вычислениях, увеличивающийся с каждым витком спирали.
    int num = 0; // Значение элемента матрицы.
    int i   = 0; // Обычный инкремент для циклов.

    while (true)
    {
        // Идём вправо
        if (k < columns - k)
        {
            for (i = k; i < columns - k; i ++)
            {
                num ++;
                arr[k, i] = AddLeftZerosToDigit(num, elCnt);
            }
        }
        else
            break;

        // Идём вниз
        if (k + 1 < rows - k)
        {
            for (i = k + 1; i < rows - k; i ++)
            {
                num ++;
                arr[i, columns - (k + 1)] = AddLeftZerosToDigit(num, elCnt);
            }
        }
        else
            break;

        // Идём влево
        if (columns - (k + 2) > k - 1)
        {
            for (i = columns - (k + 2); i > k - 1; i --)
            {
                num ++;
                arr[rows - (k + 1), i] = AddLeftZerosToDigit(num, elCnt);
            }
        }
        else
            break;

        // Идём вверх
        if (rows - (k + 2) > k)
        {
            for (i = rows - (k + 2); i > k; i --)
            {
                num ++;
                arr[i, k] = AddLeftZerosToDigit(num, elCnt);
            }
        }
        else
            break;

        k ++;
    }

    return arr;
}




Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int rows    = GetNumber("Введите количество строк матрицы", notNull: true, notNegative: true);
int columns = GetNumber("Введите количество столбцов матрицы", notNull: true, notNegative: true);

string[,] arr = BuildSpiralMatrix(rows, columns);

Console.WriteLine();
PrintMatrix("Матрица, заполненная значениями по спирали", arr);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
