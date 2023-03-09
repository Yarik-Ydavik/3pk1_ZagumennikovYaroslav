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
    public int [] array  = new int[1000];                    // Массив для хранения всех отрицательных значений информационных полей дерева
    int index = 0;

    public int [] array2 = new int[1000];
    int index2 = 0;

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
        if (node.value < 0)
        {
            array[index] = node.value;
            index++;
        }
        array2[index2] = node.value;
        index2++;
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
        Random rnd = new Random();
        BinaryTree tree = new BinaryTree();
        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Задание 1: Создать дерево поиска. Осуществить генерацию значений дерева с помощью
        // рандома в диапазоне 10..1000.Подсчитать сумму значений информационных полей
        // дерева

        // заполнение дерева значениями 
        for (int i = 10; i <= 100; i++)
        {
            tree.Insert(rnd.Next(-100,100));
        }
        int sum = tree.Sum(tree.root);
        Console.Write("Задание 1: ");
        Console.WriteLine("Сумма значений информационных полей дерева: " + sum);
        Console.WriteLine(" ");

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        // Задание 2: Создать дерево поиска. Подсчитать количество внутренних узлов.
        int internalNodesCount = tree.CountInternalNodes(tree.root);
        Console.Write("Задание 2: ");
        Console.WriteLine("Количество внутренних узлов дерева: " + internalNodesCount);
        Console.WriteLine(" ");

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        /* Задание 3: Создать дерево поиска. В линейную структуру (массив или список) скопировать
        отрицательные значения информационных полей дерева.
        */
        int minusValue = 0;
        Console.Write("Задание 3: ");
        Console.WriteLine("Вывод отрицательных значений дерева: ");
        for (int i = 0; i <= tree.array.Length; i++)
        {
            if (tree.array[i] == 0) break;
            minusValue++;
            Console.Write(tree.array[i]+" ");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Количество отрицательных узлов дерева: " + minusValue);
        Console.WriteLine(" ");

        // ---------------------------------------------------------------------------------------------------------------------------------------------
        /* Задание 4:  Cоздать два дерева поиска. Скопировать в линейную структуру (массив или список)
        значения информационных полей, которые совпадают по значениям ключей в этих
        деревьях
        */
        Console.WriteLine("Задание 4: ");
        BinaryTree tree1 = new BinaryTree();
        BinaryTree tree2 = new BinaryTree();
        int[] arrayValueRavny = new int[1000];
        int indexArrayValueRavny = 0;
        int index = 0;

        int countValue = 0;
        for (int i = 0; i <= 30; i++)
        {
            tree1.Insert(rnd.Next(-20, 20));
        }
        for (int i = 0; i <= 30; i++)
        {
            tree2.Insert(rnd.Next(-20, 20));
        }
        int sum1 = tree1.Sum(tree1.root);
        int sum2 = tree2.Sum(tree2.root);
        for (int i = 0; i <= 30; i++)
        {
            index++;
            Console.WriteLine(tree1.array2[index]);
            Console.WriteLine(tree2.array2[index]);
            Console.WriteLine("-------------------------------------");
            if (tree1.array2[index] == tree2.array2[index])
            {
                arrayValueRavny[indexArrayValueRavny] = tree1.array2[index];
                indexArrayValueRavny++;
            }
        }
        Console.WriteLine("Вывод совпавших значений узлов");
        indexArrayValueRavny = 0;
        for (int i = 0; i <= 30; i++)
        {
            if (arrayValueRavny[indexArrayValueRavny] != 0)
            {
                countValue++;
                Console.WriteLine(arrayValueRavny[indexArrayValueRavny]);
            }
            indexArrayValueRavny++;
        }
        Console.WriteLine(" ");
        Console.WriteLine("Количество совпавших узлов в дереве1 и дереве2: " + countValue);
    }
}