/*
Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
Не использовать Math.Pow

3, 5 -> 243 (3⁵)
2, 4 -> 16
*/

int get_int_from_console()
{
    int console_int = 0;

    Console.Write("Введите число: ");

    while(true)
    {
        if( int.TryParse(Console.ReadLine(), out console_int ) )
        {
            break;
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
    }
    return console_int;

}

int int_1 = get_int_from_console();
int int_2 = get_int_from_console();

int result = 1;

for(int i = 0; i < int_2; i++)
{
    result *= int_1;
}

Console.WriteLine($"Число {int_1} в степени {int_2} = {result}");