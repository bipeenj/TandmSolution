using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
namespace TandmSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sprinkler Solution:");
            List<Line> pipes = new List<Line>();
            Line pipe1 = new Line();
            pipe1.Name = "Pipe1";
            pipe1.First = new Vector3((float)98242.11, (float)36588.29, (float)3000.00);
            pipe1.Last = new Vector3((float)87970.10, (float)44556.09, (float)3500.00);
            Line pipe2 = new Line();
            pipe2.Name = "Pipe2";
            pipe2.First = new Vector3((float)99774.38, (float)38563.68, (float)3500.00);
            pipe2.Last = new Vector3((float)89502.37, (float)46531.47, (float)3000.00);
            Line pipe3 = new Line();
            pipe3.Name = "Pipe3";
            pipe3.First = new Vector3((float)101306.65, (float)40539.07, (float)3000.00);
            pipe3.Last = new Vector3((float)91034.63, (float)48506.86, (float)3000.00);
            pipes.Add(pipe1);
            pipes.Add(pipe2);
            pipes.Add(pipe3);
            Line edge1 = new Line();
            edge1.Name = "Edge1";
            edge1.First = new Vector3((float)97500.00, (float)34000.00, (float)2500.00);
            edge1.Last = new Vector3((float)85647.67, (float)43193.61, (float)2500.00);
            Line edge2 = new Line();
            edge2.Name = "Edge2";
            edge2.First = new Vector3((float)85647.67, (float)43193.61, (float)2500.00);
            edge2.Last = new Vector3((float)91776.75, (float)51095.16, (float)2500.00);
            Line edge3 = new Line();
            edge3.Name = "Edge3";
            edge3.First = new Vector3((float)91776.75, (float)51095.16, (float)2500.00);
            edge3.Last = new Vector3((float)103629.07, (float)41901.55, (float)2500.00);
            Line edge4 = new Line();
            edge4.Name = "Edge4";
            edge4.First = new Vector3((float)103629.07, (float)41901.55, (float)2500.00);
            edge4.Last = new Vector3((float)97500.00, (float)34000.00, (float)2500.00);

            Ceiling cel = new Ceiling();
            cel.Edge1 = edge1;
            cel.Edge2 = edge2;
            cel.Edge3 = edge3;
            cel.Edge4 = edge4;
            //Console.WriteLine($"Length of {edge1.Name} is {edge1.Length()} ");
            //Console.WriteLine($"Length of {edge2.Name} is {edge2.Length()} ");
            //Console.WriteLine($"Length of {edge3.Name} is {edge3.Length()} ");
            //Console.WriteLine($"Length of {edge4.Name} is {edge4.Length()} ");
            cel.Offset = 2500;
            List<Vector3> sprinklerPoints = cel.GetSprinklerPoints();
            Debug.WriteLine($"Number of sprinkler points are:{sprinklerPoints.Count}");
            Console.WriteLine($"Number of sprinkler points are:{sprinklerPoints.Count}");
            sprinklerPoints.ForEach( spPnt=> {
                Debug.WriteLine($"Sprinkler pnt is ({spPnt.X},{spPnt.Y},{spPnt.Z})");
                Console.WriteLine($"Sprinkler pnt is ({spPnt.X},{spPnt.Y},{spPnt.Z})");
                Line foundPipe = cel.FindClosestPipe(pipes,spPnt);
                if(!string.IsNullOrEmpty(foundPipe.Name))
                {
                    Debug.WriteLine($"Closest pipe is {foundPipe.Name}");
                    Console.WriteLine($"Closest pipe is {foundPipe.Name}");
                    var intersectpnt = foundPipe.Projectionpoint(spPnt);
                    if(intersectpnt!=null)
                    {
                        Debug.WriteLine($"Attachment pnt is ({intersectpnt.Value.X},{intersectpnt.Value.Y},{intersectpnt.Value.Z})");
                        Console.WriteLine($"Attachment pnt is ({intersectpnt.Value.X},{intersectpnt.Value.Y},{intersectpnt.Value.Z})");
                    }
                }
            });
            

        }
    }
}
