﻿/*
Известно, что любое чётное число, большее 2, представимо в виде суммы 2 простых чисел, причём таких разложений может быть несколько. 
Впервые гипотезу о существовании данного разложения сформулировал математик Х. Гольдбах.

Требуется написать программу, производящую согласно утверждению Гольдбаха, разложение заданного чётного числа. 
Из всех пар простых чисел, сумма которых равна заданному числу, требуется найти пару, содержащую наименьшее простое число.

Входные данные
Входной файл INPUT.TXT содержит чётное число N (4 ≤ N ≤ 998).

Выходные данные
В выходной файл OUTPUT.TXT необходимо вывести два простых числа, сумма которых равна числу N. Первым выводится наименьшее число.
*/

//Функция ввода чисел с проверкой, что они от min до max
int console_read_int(string text, int min, int max)
{
    Console.Write($"{text}: ");
    
    int read_int;

    while(true)
    {
        
        if( int.TryParse(Console.ReadLine(), out read_int ) )
        {
            if(read_int >= min && read_int <= max)
            {
                if(read_int % 2 == 0)
                    return read_int;
                else
                    Console.Write($"Число должно быть четным, повторите попытку ввода:");
            }
            else
            {
                Console.Write($"Число должно находиться в пределах от {min} до {max}, повторите попытку ввода:");
            }
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
        
    }
}

string get_min_sum(HashSet<int> hash, int N)
{
    foreach(int a in hash)
    {
        foreach(int b in hash)
        {
            if(a + b == N) return $"{a} + {b}";
        }
    }
    return "error";
}

HashSet<int> get_hash_prime_numbers(int N)
{
    //Создаем HashSet - это список который хранит только уникальные значения, он обеспечит бытрый доступ к элементам по значению.
    HashSet<int> hash = new HashSet<int>();

    //Добавляем двойку, так как это простое число
    hash.Add(2);
    //Набиваем массив hash нечетными числами, так как четные кроме 2 не могут быть простыми, так как делятся на 2 как минимум
    for(int i=3; i < N; i+=2)
    {
        hash.Add(i);
    }

    for(int i=3; i < N; i++)
    {
        //Если следующий элемент существует, его ещё не удалили, значит это простое число, ищим все числа которые делятся на него без остатка и удаляем их
        if(hash.Contains(i))
        {
            foreach(int a in hash)
            {
                //Проходимся по всему хешу, удаляем всё что делится на текущее число без остатка, но при делении не получаем 1, что-бы не удалить себя же.
                if(a % i == 0 && a / i != 1) hash.Remove(a);
            }
        }
    }
    return hash;
}

int N = console_read_int("Введите четное число", 4, 998);

HashSet<int> hash = get_hash_prime_numbers(N);

Console.WriteLine(get_min_sum(hash, N));