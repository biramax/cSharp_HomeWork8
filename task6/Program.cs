/*

Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника.

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

string[] getTriangleRows(int rows)
{
    // Инициализируем массивы, заполняем значениями первого ряда.
    int[] arrPrevious = {1};    // Массив значений предыдущего ряда.
    int[] arrCurrent  = {1, 1}; // Массив значений текущего ряда.
    int num           = 0;      // Очередное число в ряду.
    string row        = "1";    // Будем записывать в строку каждый ряд...
    string[] rowsArr  = {row};  // ...и помещать в массив.

    for (int i = 1; i < rows; i ++) 
    {   
        // Делаем arrPrevious равным arrCurrent
        Array.Resize(ref arrPrevious, arrCurrent.Length);
        for (int k = 0; k < arrCurrent.Length; k ++)
            arrPrevious[k] = arrCurrent[k];
        
        // Размер arrCurrent подгоняем под следующий ряд
        Array.Resize(ref arrCurrent, i + 2);

        arrCurrent[0] = 1;
        row = "1 ";

        for (int j = 0; j < i - 1; j ++)
        {
            num = arrPrevious[j] + arrPrevious[j + 1];
            
            arrCurrent[j + 1] = num;
            row += $"{num} ";
        }

        arrCurrent[i] = 1;
        row += "1";

        // Размер rowsArr подгоняем под текущий ряд и записываем в него строку значений ряда
        Array.Resize(ref rowsArr, i + 1);
        rowsArr[i] = row;
    }

    return rowsArr;
}

void PrintTriangle(string message, string[] rowsArr)
{
    Console.WriteLine(message+":");

    int maxLength = rowsArr[rowsArr.Length - 1].Length; // Длина нижнего ряда.
    int indent    = 0; // Величина отступа ряда.

    for (int i = 0; i < rowsArr.Length; i ++)
    {
        indent = (maxLength - rowsArr[i].Length) / 2;
        
        for (int j = 0; j < indent; j ++)
            Console.Write(" ");
        
        Console.Write(rowsArr[i]);
        Console.WriteLine();
    }
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int rows = GetNumber("Введите количество строк треугольника Паскаля", notNull: true, notNegative: true);

Console.WriteLine();
string[] rowsArr = getTriangleRows(rows);
PrintTriangle($"Первые {rows} строк треугольника Паскаля", rowsArr);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
