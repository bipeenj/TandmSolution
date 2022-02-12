using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TandmSolution
{
    class Ceiling
    {
        public Line Edge1 { get; set; }
        public Line Edge2 { get; set; }

        public Line Edge3 { get; set; }
        public Line Edge4 { get; set; }

        public float Offset { get; set; }
        public List<Vector3> GetSprinklerPoints()
        {
            List<Vector3> result = new List<Vector3>();
            var firstiterationPnts = GetEquidistantPoints(Edge1, false, false);
            var otherunitdir = Vector3.Normalize(Edge2.Direction());
            var limitdist = Edge2.Length();
            firstiterationPnts.ForEach(pnt => {
                Line toProcess = new Line();
                toProcess.First = pnt;
                toProcess.Last = pnt + otherunitdir * limitdist;
                var toadd = GetEquidistantPoints(toProcess, false,false) ;
                result.AddRange(toadd);
            });
            return result;
        }
        public List<Vector3> GetEquidistantPoints(Line lineIn,bool includeStart, bool includeEnd)
        {
            List<Vector3> result = new List<Vector3>();
            float totaldist = lineIn.Length();
            var unitdir = Vector3.Normalize(lineIn.Direction());
            var lastPnt = lineIn.First;
            var nextPnt = lastPnt  + unitdir * Offset;
            var distTofirst = (nextPnt - lineIn.First).Length();
            while (distTofirst < totaldist)
            {
                result.Add(nextPnt);
                lastPnt = nextPnt;
                nextPnt = lastPnt + unitdir * Offset;
                distTofirst = (nextPnt - lineIn.First).Length();
            }
            if (includeStart)
                result.Add(lineIn.First);
            if(includeEnd)
                result.Add(lineIn.Last);
            return result;
        }
        public Line FindClosestPipe(List<Line>pipes, Vector3 sprinklerPnt)
        {
            Line toReturn = new Line();
            double minDist = -1;
            foreach(var pipe in pipes)
            {
                var dist = pipe.OrthogonalDistanceToPoint(sprinklerPnt);
                if(dist < minDist || minDist ==-1)
                {
                    minDist = dist;
                    toReturn = pipe;
                }
            }
            return toReturn;
        }
    }
}
