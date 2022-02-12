using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TandmSolution
{
    public class Line
    {
        public Vector3 First { get; set; }
        public Vector3 Last { get; set; }

        public string Name { get; set; } = string.Empty;
        public Vector3 Direction()
        {
            return Last - First;
        }
        public float Length()
        {
            return Direction().Length();
        }
        public double OrthogonalDistanceToPoint(Vector3 point)
        {
            double dist = -1;
            var dirTopoint = point - First;
            var projectionDist = Vector3.Dot( dirTopoint, Direction())/Length();
            var squaredDist = Math.Pow(dirTopoint.Length(), 2) - Math.Pow(projectionDist,2);
            if(squaredDist> 0)
                dist = Math.Pow(squaredDist, 0.5);
            return dist;
        }
        public Vector3? Projectionpoint(Vector3 fromPoint)
        {
            Vector3? toReturn = null;
            var dir = Direction();
            var unitDir = Vector3.Normalize(dir);
            float dist = (float)OrthogonalDistanceToPoint(fromPoint);
            toReturn = Vector3.Multiply(dist,unitDir);
            return toReturn;
        }
    }
}
