using System;

public class Node
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

public class BinaryTree
{
    public Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int val)
    {
        Node newNode = new Node(val);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Node current = root;

        while (true)
        {
            if (val < current.value)
            {
                if (current.left == null)
                {
                    current.left = newNode;
                    break;
                }
                else
                {
                    current = current.left;
                }
            }
            else
            {
                if (current.right == null)
                {
                    current.right = newNode;
                    break;
                }
                else
                {
                    current = current.right;
                }
            }
        }
    }

    public int Sum(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.value + Sum(node.left) + Sum(node.right);
    }
}

public class Program
{
    public static void Main()
    {
        BinaryTree tree = new BinaryTree();

        // заполнение дерева значениями от 10 до 1000
        for (int i = 10; i <= 1000; i++)
        {
            tree.Insert(i);
        }

        // подсчет суммы значений информационных полей дерева
        int sum = tree.Sum(tree.root);

        Console.WriteLine("Сумма значений информационных полей дерева: " + sum);
    }
}