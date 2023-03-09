using System;

public class Node                                    // Узел дерева
{
    public int value;
    public Node left;
    public Node right;

    public Node(int val)
    {
        value = val;
        left = null;
        right = null;
    }
}

public class BinaryTree                              // Дерево поиска
{
    public Node root;

    public BinaryTree()  
    {
        root = null;
    }

    public void Insert(int val)                      // Метод для заполнения дерева рандомными значениями
    {
        Node newNode = new Node(val);

        if (root == null)                            // Если у дерева нет корня, создастся новый узел
        {
            root = newNode;
            return;
        }

        Node current = root;

        while (true)
        {
            if (val < current.value)                 // Если добавляемое значение детёныша предка меньше предка
            {
                if (current.left == null)            // Если у предка нет левого детёныша ( Создаётся левый детёныш )
                {
                    current.left = newNode;
                    break;
                }
                else                                 // Если у предка есть левый детёныш ( Осуществляется переход к левому детёнышу )
                {
                    current = current.left;
                }
            }
            else                                     // Если добавляемое значение детёныша предка больше предка
            {
                if (current.right == null)           // Если у предка нет правого детёныша ( Создаётся правый детёныш )
                {
                    current.right = newNode;
                    break;
                }
                else                                 // Если у предка есть правый детёныш ( Осуществляется переход к правому детёнышу )
                {
                    current = current.right;
                }
            }
        }
    }
    public int [] array = new int[1100];                    // Массив для хранения всех отрицательных значений информационных полей дерева
    int index = 0;

    // Метод для складывания значений информационных полей дерева

    /* Метод рекурсивно обходит дерево и считает количество всех узлов, 
       пока значение узла не будет равно 0
    */

    public int Sum(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        else if (node.value < 0)
        {
            array[index] = node.value;
            index++;
        }
        return node.value + Sum(node.left) + Sum(node.right);
    }
    // Метод для подсчёта количества внутренних узлов

    /* Метод рекурсивно обходит дерево и считает количество узлов, 
       у которых есть хотя бы один потомок.
       Узел считается предком, если у него 
       есть хотя бы один потомок, а детёнышем, если у него нет потомков
    */
    public int CountInternalNodes(Node node)        
    {
        if (node == null || (node.left == null && node.right == null))
        {
            return 0;
        }

        return 1 + CountInternalNodes(node.left) + CountInternalNodes(node.right);
    }
}

public class Program
{
    public static void Main()
    {
        BinaryTree tree = new BinaryTree();
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Задание 1: Создать дерево поиска. Осуществить генерацию значений дерева с помощью
        // рандома в диапазоне 10..1000.Подсчитать сумму значений информационных полей
        // дерева

        // заполнение дерева значениями от 10 до 1000
        for (int i = 10; i <= 1000; i++)
        {
            tree.Insert(i);
        }

        // подсчет суммы значений информационных полей дерева
        int sum = tree.Sum(tree.root);

        Console.WriteLine("Сумма значений информационных полей дерева: " + sum);

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Задание 2: Создать дерево поиска. Подсчитать количество внутренних узлов.
        int internalNodesCount = tree.CountInternalNodes(tree.root);
        Console.WriteLine("Количество внутренних узлов дерева: " + internalNodesCount);

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        /* Задание 3: Создать дерево поиска. В линейную структуру (массив или список) скопировать
        отрицательные значения информационных полей дерева.
        */
        int minusValue = tree.array.Length;
        Console.WriteLine("Количество отрицательных узлов дерева: " + minusValue);
        for (int i = 0; i <= 1000; i++)
        {
            Console.WriteLine(tree.array[i]);
        }
        
    }
}