
using System;

class Dijkstra
{
    // Количество вершин графа
    static int V = 5;
    
    // Сам алгоритмдля поиска кратчайшего пути до вершины
    // Принимает 2 параметра ( граф смежности, начальную точку отсчёта )
    void dijkstra(int[,] graph, int src)
    {
        // Хранит расстояние от вершины до конечной вершины
        int[] distance = new int[V];

        // Хранит вершины, минимальное расстояние которых от источника вычеслено и завершено
        bool[] Vertexes = new bool[V];

        // Набор sptSet изначально пуст, а расстояния, назначенные вершинам, равны {0, бесконечность, бесконечность, бесконечность, бесконечность}.
        for (int i = 0; i < V; i++)
        {
            distance[i] = int.MaxValue;
            Vertexes[i] = false;
        }

        // Установка нулевого значения для точки графа, с которой начинается поиск
        distance[src] = 0;

        // Поиск кратчайшего пути для всех вершин
        for (int count = 0; count < V - 1; count++)
        {
            // Выбор вершины, с наименьшим расстоянием, которая еще не включена в Vertexes
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (Vertexes[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    min_index = v;
                }

            int minDistance = min_index;

            Vertexes[minDistance] = true;

            for (int v = 0; v < V; v++)
            {
                // Обновляется distance[v], только если его нет в Vertexes
                // Если существует палка от 
                if (!Vertexes[v] && graph[minDistance, v] != 0 && distance[minDistance] != int.MaxValue && distance[minDistance] + graph[minDistance, v] < distance[v])
                    distance[v] = distance[minDistance] + graph[minDistance, v];
            }
                
        }

        Console.Write("Точка " + " \t " + "Короткий путь\n");
        for (int i = 0; i < V; i++) 
            Console.Write(i + " \t " + distance[i] + "\n");
    }
    public static void Main()
    {
        int[,] graph = new int[,] { 
                                      { 0, 4, 0, 0, 0},
                                      { 4, 0, 8, 0, 0},
                                      { 0, 8, 0, 7, 0},
                                      { 0, 0, 7, 0, 9},
                                      { 0, 0, 0, 9, 0},
                                  };
        Dijkstra t = new Dijkstra();
        t.dijkstra(graph, 0);
    }
}