using System.Collections;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

Stopwatch stopwatch = new Stopwatch();
// Массив размерностью 5000 элементов

int [] massive = new int [5000];

// Заполнение массива

Random rnd = new Random ();
for (int i = 0; i < massive.Length; i++) massive[i] = rnd.Next(10000);

// Обычный поиск числа со значением 5000

for (int i = 0; i < massive.Length; i++){
    stopwatch.Start ();
    if (massive[i] == 5000) Console.WriteLine("Время для поиска числа обычным способом: "+stopwatch.Elapsed);
}

// Бинарный поиск числа со значением 5000
// Для начала необходимо отсортировать массив, чтобы выполнялось условие на проверку среднего значения
Array.Sort(massive);
int a = 0;
int b = massive.Length-1;
int index = -1;

while(a<b && index == -1){
    int sredneye = (a+b)/2;
    // Обнуление счётчика времени
    stopwatch.Restart ();
    // Если искомое значение находится в середине массива, то поиск завершится
    if (massive[sredneye] == 5000) index= sredneye;
    else {
        if (5000 < massive[sredneye]) b = sredneye - 1;
        else a = sredneye + 1;
    }
    if (index != 1){
        Console.WriteLine("Время для поиска числа бинарным способом: " + stopwatch.Elapsed);
        break;
    }
}
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------
// Создание Хэш таблицы

Hashtable massive2 = new Hashtable ();
// Заполнение Хэш таблицы значениями из ранее созданного массива
for (int i = 0; i < massive.Length; i++) massive2.Add(i, massive[i]);

// Обычный поиск в Хэш-таблице
foreach (DictionaryEntry de in massive2)
{
    stopwatch.Restart ();
    if (Convert.ToInt32(de.Value) == 5000) Console.WriteLine("Время для поиска числа в Хэш-таблице обычным способом: "+ stopwatch.Elapsed);
}

// Бинарный поиск в Хэш- таблице
a= 0; b=massive2.Count; index = -1;
while (a<b && index == -1){
    int sredneye = (a+b)/2;
    stopwatch.Restart();
    if (5000 == Convert.ToInt32(massive2[sredneye])) index = sredneye;
    else {
        if (5000 < Convert.ToInt32(massive2[sredneye])) b = sredneye - 1;
        else a= sredneye + 1;
    }
    if (index != 1) { 
        Console.WriteLine("Время для поиска числа в Хэш-таблице обычным способом: " + stopwatch.Elapsed); 
        break;
    }
}
