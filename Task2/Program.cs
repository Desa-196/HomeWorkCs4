/*
Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.

452 -> 11
82 -> 10
9012 -> 12
*/

string read_int = "";
int result = 0;

Console.Write("Введите число: ");

while(true)
{	
	//Ждем ввода числа
    read_int = Console.ReadLine()!;
	
	//Проверяем число ли ввели
    if( int.TryParse(read_int, out _ ) )
    {
        break;
    }
    else
    {
        Console.Write("Введено некорректное число, повторите попытку ввода числа:");
    }
}

foreach(char a in read_int)
{
    result  += Int32.Parse(a.ToString());
}
Console.WriteLine($"Сумма цифр числа {read_int} = {result}");