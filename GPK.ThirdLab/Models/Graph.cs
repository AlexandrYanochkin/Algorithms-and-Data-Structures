using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GPK.ThirdLab.Models
{
    public class Graph
    {
        private Rib[,] _ribs;

        public Rib[,] Ribs { 
            
            get => _ribs; 
            
            private set
            {
                if (value.GetLength(0) != value.GetLength(1) || value.Rank != 2)
                    throw new ArgumentException("Invalid matrix of ribs for graph!!!");

                _ribs = value;
            }
        
        }

        public int CountOfVertices { get; private set; }


        public Graph(Rib[,] ribs)
        {
            Ribs = ribs;
            CountOfVertices = ribs.GetLength(0);
        }

        private void ValidateVertex(int vertex)
        {
            if (vertex < 0 || vertex >= CountOfVertices)
                throw new ArgumentException("Invalid value of Vertex!!!");
        }


        public IEnumerable<int> Search(int startVertex, int endVertex)
        {
            ValidateVertex(startVertex);
            ValidateVertex(endVertex);
            var graph = GetGraphForSearch(Ribs);
            List<(List<int> verticesNums, int sum)> pathes = new List<(List<int> verticesNums, int sum)>();
            int currentVertex = startVertex;

            Search(graph, startVertex, endVertex, new List<int>(), 0, ref pathes);

            var minPath = pathes.First(t => t.sum == pathes.Min(t => t.sum)).verticesNums;

            return minPath;
        }

        private void Search(List<Vertex> graph, int currentVertex, int endVertex, List<int> verticesNums,
            int sum, ref List<(List<int> verticesNums, int sum)> pathesForOutput)
        {
            if (currentVertex == endVertex)
            {
                verticesNums.Add(currentVertex);
                pathesForOutput.Add((new List<int>(verticesNums), sum));
                verticesNums.Clear();
            }
            else
            {
                
                for (int i = 0; i < CountOfVertices; i++)
                    if (graph[currentVertex].Ribs[i].Exist && !verticesNums.Contains(i))
                    {
                        verticesNums.Add(currentVertex);
                        int sumForNextStep = (sum + graph[currentVertex].Ribs[i].Weight);
                        Search(graph, i, endVertex, verticesNums, sumForNextStep, ref pathesForOutput);
                    }
            }
        }

        public bool DepthFirstSearch(int startVertex, int endVertex)
        {
            ValidateVertex(startVertex);
            ValidateVertex(endVertex);
            var graph = GetGraphForSearch(Ribs);

            if (startVertex == endVertex)
                return graph[startVertex].Ribs[endVertex].Exist;
            else 
                return DepthFirstSearch(startVertex, endVertex, ref graph);
        }

        private bool DepthFirstSearch(int currentVertex, int endVertex, ref List<Vertex> graph)
        {
            if (currentVertex == endVertex)
                return true;

            graph[currentVertex].IsVisited = true;
            bool result = false;
            for (int i = 0; i < CountOfVertices && !result; i++)
                if (graph[currentVertex].Ribs[i].Exist && !graph[i].IsVisited)
                    result = DepthFirstSearch(i, endVertex, ref graph);

            return result;
        }

        public bool BreadthFirstSearch(int startVertex, int endVertex)
        {
            ValidateVertex(startVertex);
            ValidateVertex(endVertex);

            Queue<int> vertices = new Queue<int>();
            bool result = false;
            var graph = GetGraphForSearch(Ribs);

            vertices.Enqueue(startVertex);

            while(vertices.Count != 0 && !result)
            {
                int currentVertex = vertices.Dequeue();
                graph[currentVertex].IsVisited = true;

                for(int i = 0;i < CountOfVertices && !result; i++)
                {
                    if(graph[currentVertex].Ribs[i].Exist && !graph[i].IsVisited)
                    {
                        if (i == endVertex)
                            result = true;
                        else
                            vertices.Enqueue(i);
                    }
                }           
            }


            return result;
        }

        public bool IsDicotyledonousGraph()
        {        
            int startVertex = 0;
            var graph = GetGraphForSearch(_ribs);
            bool isGraphDicotyledonous = true;
            SetType typeOfVertex = SetType.VertexFromFirstSet;
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startVertex);
            graph[startVertex].SetType = typeOfVertex;
            typeOfVertex = GetNextSetType(typeOfVertex);
            

            while (queue.Count != 0 && isGraphDicotyledonous)
            {
                int currentVertex = queue.Dequeue();
               
                for (int i = 0;i < CountOfVertices && isGraphDicotyledonous; i++)
                {
                    if(graph[currentVertex].Ribs[i].Exist && !graph[i].IsVisited)
                    {
                        if (graph[i].SetType == SetType.None)
                            graph[i].SetType = typeOfVertex;
                        else if (graph[currentVertex].SetType == graph[i].SetType)
                            isGraphDicotyledonous = false;

                        queue.Enqueue(i);
                    }
                }

                graph[currentVertex].IsVisited = true;
                typeOfVertex = GetNextSetType(typeOfVertex);
            }

            return isGraphDicotyledonous;
        }

        private SetType GetNextSetType(SetType typeOfVertex) 
            => (typeOfVertex == SetType.VertexFromFirstSet) ? SetType.VertexFromSecondSet : SetType.VertexFromFirstSet;

        private List<Vertex> GetGraphForSearch(Rib[,] ribs)
        {
            List<Vertex> graph = new List<Vertex>();

            for (int i = 0; i < ribs.GetLength(0); i++)
            {
                graph.Add(new Vertex());
                for (int g = 0; g < ribs.GetLength(1); g++)
                    graph[i].Ribs.Add(ribs[i, g]);
            }

            return graph;
        }

        private class Vertex
        {
            public List<Rib> Ribs { get; set; }
            public bool IsVisited { get; set; }

            public SetType SetType { get; set; }

            public Vertex(List<Rib> ribs,bool isVisited)
            {
                Ribs = ribs;
                IsVisited = isVisited;
            }

            public Vertex()
            {
                Ribs = new List<Rib>();
                IsVisited = false;
            }

        }

        private enum SetType
        {
            None,
            VertexFromFirstSet,
            VertexFromSecondSet
        }

    }
}
