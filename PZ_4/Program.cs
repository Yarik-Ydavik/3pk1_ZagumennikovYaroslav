

using static Tree;

public class Tree
{
    // подкласс "элемент дерева"
    public class TreeNode
    {
        public int Value; // численное значение
        public int Count = 0; // сколько раз было добавлено данное численное значение
        public TreeNode Left; // левое поддерево
        public TreeNode Right; // правое поддерево
    }
    public TreeNode Node; // экземпляр класса "элемент дерева"

}
private void RCL(TreeNode node, ref string s, bool detailed)
{
    /*
     Аргументы метода:
     1. TreeNode node - текущий "элемент дерева" (ref  передача по ссылке)       
     2. ref string s - строка, в которой накапливается результат (ref - передача по ссылке)
    */
    if (node != null)
    {
        if (detailed) s += "    обходим правое поддерево" + Environment.NewLine;
        RCL(node.Right, ref s, detailed); // обойти правое поддерево
        if (detailed)
            s += "    получили значение " + node.Value.ToString() + Environment.NewLine;
        else
            s += node.Value.ToString() + " "; // запомнить текущее значение
        if (detailed) s += "    обходим левое поддерево" + Environment.NewLine;
        RCL(node.Left, ref s, detailed); // обойти левое поддерево
    }
    else if (detailed) s += "    значение отсутствует - null" + Environment.NewLine;
}

class Program
{
    public static void Main()
    {
        private void RCL(TreeNode node, ref string s, bool detailed);
        if (node != null)
        {
            if (detailed) s += "    обходим правое поддерево" + Environment.NewLine;
            RCL(node.Right, ref s, detailed); // обойти правое поддерево
            if (detailed)
                s += "    получили значение " + node.Value.ToString() + Environment.NewLine;
            else
                s += node.Value.ToString() + " "; // запомнить текущее значение
            if (detailed) s += "    обходим левое поддерево" + Environment.NewLine;
            RCL(node.Left, ref s, detailed); // обойти левое поддерево
        }
        else if (detailed) s += "    значение отсутствует - null" + Environment.NewLine;
    }
}