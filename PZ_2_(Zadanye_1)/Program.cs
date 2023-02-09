
using PZ_2__Zadanye_1_;

bool[,] edges = new bool[4, 4]
{
    {false, true, true, false},
    {false, false, false, true},
    {false, true, false, false},
    {false, false, true, false},
};

Graph graph = new Graph(4, edges);

graph.Depth(3);
