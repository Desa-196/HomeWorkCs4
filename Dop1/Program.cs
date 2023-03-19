/*
Дана последовательность из N целых чисел и число K. 
Необходимо сдвинуть всю последовательность (сдвиг - циклический) на |K| элементов вправо, 
если K – положительное и влево, если отрицательное.
*/

/*
Функция зацикливает индекс, если переданный индекс находится за пределами массива
то мы лишнее опять отсчитываем с начала массива
*/

//Функция возвращает индекс эллемента с учетом сдвига.
//Передаем index - текущее положение К-смещение, array_length - длинна массива
int get_new_index(int index, int K, int array_length)
{
    //Если при сдвиге индекс вышел за приделы массива
    if(index + K >= array_length || index + K < 0)
    {
        if(K > 0) index = (index + K) % array_length;
        if(K < 0) index = array_length + (index + K) % array_length;
        return index;
    }
    else
    {
        return index + K;
    }
    
}

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

int N = console_read_double("Введите количество элементов в массиве");

int[] array = new int[N];
int[] offset_array = new int[N];

for(int i = 0; i < array.Length; i++)
{
    array[i] = new Random().Next(0, 21);
}

Console.WriteLine($"Сгенерированный массив: {string.Join(", ", array)}");

int K = console_read_double("Введите K");

for(int i = 0; i< array.Length; i++)
{
    //Вставляем в новый массив на место расчитанное в get_new_index элемент старого массива
    offset_array[get_new_index(i, K, N)] = array[i];
}

Console.WriteLine($"Сдвинутый на {K} массив: {string.Join(", ", offset_array)}");