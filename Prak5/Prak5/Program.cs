using System;
using System.Threading;

class Program
{
    static int[] array = new int[15];
    static Thread t0, t1;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Ініціалізація масиву
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
            Console.WriteLine($"Елемент масиву з індексом {i}: {array[i]}");
        }

        // Створення потоків
        t0 = new Thread(PrintEvenIndices);
        t1 = new Thread(PrintOddIndicesSquares);

        // Запуск потоків
        t0.Start();
        t1.Start();

        // Очікування завершення потоків
        t0.Join();
        t1.Join();
    }

    static void PrintEvenIndices()
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            Console.WriteLine($"Елементи з парними індексами {i}: {array[i]}");
        }
    }

    static void PrintOddIndicesSquares()
    {
        for (int i = 1; i < array.Length; i += 2)
        {
            Console.WriteLine($"Квадрати непарних індексів {i}: {Math.Pow(array[i], 2)}");
        }
    }
}
