using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPK.ThirdLab.Services
{
    public class Facade
    {
        public Graph Graph { get; set; }

        public IInputOfItem<Graph> InputOfGraph { get; set; }

        public IOutputOfItem<Graph> OutputOfGraph { get; set; }

        public IWriter<Graph> GraphWriter { get; set; }

        public IReader<Graph> GraphReader { get; set; }

        public string PathToFile { get; set; }

        public Facade(Graph graph, IInputOfItem<Graph> inputOfGraph,
            IOutputOfItem<Graph> outputOfGraph, IReader<Graph> graphReader, IWriter<Graph> graphWriter) 
            : this(inputOfGraph,outputOfGraph,graphReader,graphWriter)
        {
            Graph = graph;
        }

        public Facade(IInputOfItem<Graph> inputOfGraph,
             IOutputOfItem<Graph> outputOfGraph, IReader<Graph> graphReader, IWriter<Graph> graphWriter)
        {
            InputOfGraph = inputOfGraph;
            OutputOfGraph = outputOfGraph;
            GraphReader = graphReader;
            GraphWriter = graphWriter;
        }

        public void CheckIsGraphDictyledonous(object sender, EventArgs e)
        {
            try
            {
                bool isDicotyledonous = Graph.IsDicotyledonousGraph();
                Console.WriteLine($"{nameof(isDicotyledonous)}:\t{isDicotyledonous}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void GraphInput(object sender, EventArgs e)
        {
            try
            {
                InputOfGraph.Input(out Graph graph);
                Graph = graph;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void GraphOutput(object sender, EventArgs e)
        {
            if (Graph != null)
            {
                OutputOfGraph.View(Graph);
            }
            else
                Console.WriteLine("Error!! Graph doesn't exist!");
        }

        public void SearchOfPath(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Input startVertex:");
                int startVertex = int.Parse(Console.ReadLine());
                Console.WriteLine("Input endVertex:");
                int endVertex = int.Parse(Console.ReadLine());

                var path = Graph.Search(startVertex, endVertex).ToList();

                Console.WriteLine();

                for (int i = 0; i < path.Count; i++)
                {
                    if (i != (path.Count - 1))
                        Console.Write($"{path[i]} -> ");
                    else
                        Console.WriteLine(path[i]);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public void BreadthFirstSearch(object sender, EventArgs e)
        {
            SearchOfPath(Graph.BreadthFirstSearch);
        }

        private void SearchOfPath(Func<int,int,bool> search)
        {
            try
            {
                Console.WriteLine("Input startVertex:");
                int startVertex = int.Parse(Console.ReadLine());
                Console.WriteLine("Input endVertex:");
                int endVertex = int.Parse(Console.ReadLine());

                var result = search(startVertex, endVertex);

                Console.WriteLine($"Result - {result}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void DepthFirstSearch(object sender, EventArgs e)
        {
            SearchOfPath(Graph.DepthFirstSearch);
        }

        public void InputFromFile(object sender, EventArgs e)
        {
            try
            {
                Graph = GraphReader.Read(PathToFile);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void OutputInFile(object sender, EventArgs e)
        {
            try
            {
                GraphWriter.Write(PathToFile, Graph);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }        
        }

    }
}
