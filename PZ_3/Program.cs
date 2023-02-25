class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
{
    public BinaryTreeNode(TNode value)  // конструктор для записи значения в узел дерева
    {
        Value = value;
    }
    public BinaryTreeNode<TNode> Left   // левый потомок дерева
    {
        get; set;
    }
    public BinaryTreeNode<TNode> Right  // правый потомок дерева
    {
        get; set;
    }
    
    public TNode Value                  // свойство для реализации переменной в конструкторе
    {
        get; private set;
    }

    // Метод для сравнения значения 2 узлов (Value и other) -> other - значение для добавления, оно будет сравниваться с Value
    //                                                         Value - значение предок
    public int CompareTo(TNode other)   // метод сравнения значений 
    {
        return Value.CompareTo(other);
    }
    public int CompareNode(BinaryTreeNode<TNode> other) // метод сравнения узлов
    {
        return Value.CompareTo(other.Value);
    }

}
class Program
{
    public static void Main()
    {

        int[] valuesУзлов = new int [5];
        BinaryTreeNode <int> Узел1 = new BinaryTreeNode <int> (5);
        BinaryTreeNode <int> Узел2 = new BinaryTreeNode <int> (3);
        BinaryTreeNode <int> Узел3 = new BinaryTreeNode <int> (8);
        BinaryTreeNode <int> Узел4 = new BinaryTreeNode <int> (2);
        BinaryTreeNode <int> Узел5 = new BinaryTreeNode <int> (9);

        valuesУзлов[0] = Узел1.Value;
        valuesУзлов[1] = Узел2.Value;
        valuesУзлов[2] = Узел3.Value;
        valuesУзлов[3] = Узел4.Value;
        valuesУзлов[4] = Узел5.Value;

        if (Узел1.CompareNode(Узел2) >= 0) Узел1.Left = Узел2;
        else Узел1.Right = Узел2;

        if (Узел1.CompareNode(Узел3) >= 0) Узел1.Left = Узел3;
        else Узел1.Right = Узел3;

        if (Узел2.CompareNode(Узел4) >= 0) Узел2.Left = Узел4;
        else Узел2.Right = Узел4;

        if (Узел2.CompareNode(Узел5) >= 0) Узел2.Left = Узел5;
        else Узел2.Right = Узел5;

        Console.WriteLine("        {0}     ", Узел1.Value);
        Console.WriteLine("       / \\     ");
        Console.WriteLine("      {0}   {1}     ", Узел1.Left.Value, Узел1.Right.Value);
        Console.WriteLine("     / \\     ");
        Console.WriteLine("    {0}   {1}     ", Узел2.Left.Value, Узел2.Right.Value);
        Console.WriteLine(" ");

        // Задание 1
        // Сумма всех значений узлов поделённая на общее количество узлов
        double result = (Узел1.Value + Узел2.Value + Узел3.Value + Узел4.Value + Узел5.Value)/5.0;
        Console.WriteLine("Задание 1: Среднее арифметическое значений информационных полей узлов дерева: {0}", result);

        // Задание 2
        // Количество узлов дерева с положительными и отрицательными значениями
        int plusValue = 0;
        int minusValue = 0;
        for (int i = 0; i< valuesУзлов.Length; i++)
        {
            if (valuesУзлов[i] < 0) minusValue += 1;
            else plusValue += 1;
        }
        Console.WriteLine("Задание 2: Среднее арифметическое значений информационных полей узлов дерева: {0}", result);
        Console.WriteLine("Количество узлов дерева с положительными значениями: {0}", plusValue);
        Console.WriteLine("Количество узлов дерева с отрицательными значениями: {0}", minusValue);
    }
}

