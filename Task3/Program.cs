/*
Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.

1, 2, 5, 7, 19, 6, 1, 33 -> [1, 2, 5, 7, 19, 6, 1, 33]

*/
int[] array = new int[8];

int console_read_double(string text)
{
    Console.Write($"{text}: ");
    
    int read_int;

    while(true)
    {
        

        if( int.TryParse(Console.ReadLine(), out read_int ) )
        {
            return read_int;
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
        
    }
}

int start = console_read_double("Введите начало диапазона значений случайных чисел");
int stop = console_read_double("Введите конец диапазона значений случайных чисел");

for(int i = 0; i < array.Length; i++)
{
    array[i] = new Random().Next(start, stop + 1);
}

Console.WriteLine(string.Join(", ", array));