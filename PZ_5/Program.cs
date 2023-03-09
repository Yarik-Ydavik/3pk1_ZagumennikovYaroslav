
public class AnotherClass
{
    public string v;                 // Поле класса AnotherClass

    public AnotherClass(string v)     // Конструктор для возвращения данного поля
    {
        this.v = v;
    }

}
public class MyClass
{
    private int myInt;                // Целое число  - закрытое поле базового типа
    private DateTime myDate;          // Дата и время - закрытое поле базового типа
    private AnotherClass myObj;       // Строка       - закрытое поле пользователького типа ( поле класса AnotherClass, которое через конструктор даёт значение )

    public MyClass(int myInt, DateTime myDate, AnotherClass myObj)  // Конструктор с тремя закрытыми полями (дата, число, поле другого класса) 
                                                                    // Принимает 3 параметра (myInt, myDate и myObj)
    {
        this.myInt = myInt;
        this.myDate = myDate;
        this.myObj = myObj;
    }

    public int MyInt                  // Определение открытого поля MyInt  
    {
        get { return myInt; }
        set { myInt = value; }
    }

    public DateTime MyDate            // Определение открытого поля MyDate 
    {
        get { return myDate; }
        set { myDate = value; }
    }

    public AnotherClass MyObj         // Определение открытого поля MyObj 
    {
        get { return myObj; }
        set { myObj = value; }
    }
                                      // Определение свойств для получения и установления значения в строку
    public string MyIntAsString       
    {
        get { return myInt.ToString(); }
        set { myInt = int.Parse(value); }
    }

    public string MyDateString
    {
        get { return myDate.ToString(); }
        set { myDate = DateTime.Parse(value); }
    }

    public string MyObjToString
    {
        get { return myObj.ToString(); }
        set { myObj = new AnotherClass(value); }
    }

    public object Clone()            // Реализация интерфейса IClonable для класса MyClass
    {
        return new MyClass(myInt, myDate, new AnotherClass( myObj.v));
    }
    public object Compare(MyClass my)// Реализация интерфейса IComporable для класса MyClass
    {
        if (my == null) return 1;

        int intCompare = myInt.CompareTo(my.myInt);
        if (intCompare != 0) return intCompare;

        int dateCompare = myDate.CompareTo(my.myDate);
        if (dateCompare != 0) return dateCompare;

        return MyObjToString.CompareTo(myObj);
    }
}


class Program
{
    public static void Main()
    {
        MyClass myObj = new MyClass(42, DateTime.Now, new AnotherClass("Hello"));     // Создание объекта класса, чтобы хранить данные базового и пользовательского типа
        Console.WriteLine("MyInt: {0}", myObj.MyInt);                  // Объявление свойства MyInt для получения значения закрытого поля myInt
        Console.WriteLine("MyDate: {0}", myObj.MyDate);                // Объявление свойства MyDate для получения значения закрытого поля myDate
        Console.WriteLine("MyObj: {0}", myObj.MyObjToString);          // Объявление свойства MyObjToString для получения значения закрытого поля myObjToString

        myObj.MyIntAsString = "123";
        myObj.MyDateString = "2021-10-01";
        myObj.MyObjToString = "World";

        Console.WriteLine("MyInt: {0}", myObj.MyInt);                  // Использование свойства MyInt
        Console.WriteLine("MyDate: {0}", myObj.MyDate);                // Использование свойства MyDate
        Console.WriteLine("MyObj: {0}", myObj.MyObjToString);          // Использование свойства MyObjToString


        // ------------------------------------------------------------------------------------------------------------------------------------ 
        // Задание 1 - Интерфейс IClonable
        MyClass obj1 = new MyClass(18, DateTime.Now, new AnotherClass("Yaroslav"));  // Создание нового объекта класса MyClass
        MyClass obj2 = (MyClass)obj1.Clone();                                        // Создание нового объекта с вызовом метода Clone() первого объекта
        Console.WriteLine("obj1: {0}, {1}, {2}", obj1.MyInt, obj1.MyDateString, obj1.MyObjToString);
        Console.WriteLine("obj2: {0}, {1}, {2}", obj2.MyInt, obj2.MyDateString, obj2.MyObjToString);

        // ------------------------------------------------------------------------------------------------------------------------------------ 
        // Задание 2 - Интерфейс IComporable
        MyClass obj3 = new MyClass(50, DateTime.Now, new AnotherClass("Yaroslav"));
        MyClass obj4 = new MyClass(18, DateTime.Now, new AnotherClass("Yaroslav"));
        
        int Result = (int)obj3.Compare(obj4);
        if (Result == 0) Console.WriteLine("Объект 3 равен Объекту 4");
        else if (Result < 0) Console.WriteLine("Объект 3 меньше Объекта 4");
        else Console.WriteLine("Объект 3 больше Объекта 4");
    }

}
