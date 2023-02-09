using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_2__Zadanye_1_
{
    public class Node
    {
        private int id; // идентификатор смежной вершины
        private int weight; // вес ребра
        private Node link; // ссылка на соседний элемент списка вершин
        public int Id { get; set; } // свойства
        public int Weight { get; set; }
        public Node[] Link { get; set; }
        public Node() { } // конструкторы
        public Node(int id)
        {
            Id = id;
        }
        public Node(int id, int weight)
        {
            Id = id;
            Weight = weight;
        }
    }
}
