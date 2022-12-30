/*

Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)

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

// Генерирует трёхмерный массив из неповторяющихся чисел
int[,,] InitArray(int xCount, int yCount, int zCount, int min = 10, int max = 99)
{
    int[,,] arr = new int[xCount, yCount, zCount];

    // Проверяем, хватит ли неповторяющихся двухзначных чисел для наполнения массива
    if (max + 1 - min < xCount * yCount * zCount)
        return new int[0, 0, 0];

    // Массив использованных чисел (чтобы набрать неповторяющихся)
    int[] numsArr = new int[0];
    int num = 0; // Значение очередного случайного элемента

    Random rnd = new Random();

    for (int x = 0; x < xCount; x ++)
    {
        for (int y = 0; y < yCount; y ++)
        {
            for (int z = 0; z < zCount; z ++)
            {   
                // Получаем неповторяющееся число
                do { num = rnd.Next(min, max + 1); }
                while (numsArr.Contains(num));

                // Вносим его в numsArr
                Array.Resize(ref numsArr, numsArr.Length + 1);
                numsArr[numsArr.Length - 1] = num;

                arr[x, y, z] = num;
            }
        }
    }

    return arr;
}

// Выводит трёхмерный массив в консоль
void PrintArray(string message, int[,,] arr)
{
    Console.WriteLine(message+":");

    int xCount = arr.GetLength(0);
    int yCount = arr.GetLength(1);
    int zCount = arr.GetLength(2);

    for (int x = 0; x < xCount; x ++)
    {
        for (int y = 0; y < yCount; y ++)
        {
            for (int z = 0; z < zCount; z ++)
            {
                Console.Write($"{arr[x, y, z]}({x},{y},{z}) ");
            }

            Console.WriteLine();
        }
    }
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int xCount = GetNumber("Введите размер Х трёхмерного массива", notNull: true, notNegative: true);
int yCount = GetNumber("Введите размер У трёхмерного массива", notNull: true, notNegative: true);
int zCount = GetNumber("Введите размер Z трёхмерного массива", notNull: true, notNegative: true);

int[,,] arr = InitArray(xCount, yCount, zCount);

Console.WriteLine();

if (arr.GetLength(0) == 0 && arr.GetLength(1) == 0 && arr.GetLength(2) == 0)
    Console.WriteLine("Массив слишком велик, чтобы наполнить его неповторяющимися двухзначными числами.");

else
    PrintArray("Сгенерированный массив", arr);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
