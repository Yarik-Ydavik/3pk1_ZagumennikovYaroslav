
using PZ_2__Zadanye_1_;

bool[,] edges = new bool[5, 5]
{
    {false, true, true, false , true},
    {false, false, false, true, false},
    {false, true, false, false, true},
    {false, false, true, false, false},
    {false, false, false, true, false},
};

Graph graph = new Graph(5, edges);

graph.Depth(2);
