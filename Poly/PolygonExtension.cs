using System;
using System.Drawing;
using System.Linq;

namespace Poly
{
    public static class PolygonExtensions
    {
        public static bool IsInside(this PointF innerPoint, Polygon polygon) => IsInside(innerPoint.X, innerPoint.Y, polygon);

        public static bool IsInside(float x, float y, Polygon polygon)
        {
            bool result = false;
            int  j      = polygon.Length - 1;
            for (int i = 0; i < polygon.Length; i++)
            {
                if ((polygon[i].Y < y && polygon[j].Y >= y ||
                     polygon[j].Y < y && polygon[i].Y >= y) &&
                    polygon[i].X + (y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < x)
                {
                    result = !result;
                }

                j = i;
            }

            return result;
        }

        public static PointF GetRandomPoint(this Polygon polygon) => 
            GetRandomPoint(polygon, new Point(0, 0), new Point(100, 100));

        public static PointF GetRandomPoint(this Polygon polygon, Point bottomLeft, Point topRight)
        {
            Random random = new Random();
            PointF pointF = new PointF(0, 0);

            int[] range;
            int index;
            
            if (random.Next(0, 2) == 0)
            {
                pointF.X = random.Next(bottomLeft.X, topRight.X);
                range = Enumerable.Range(bottomLeft.Y, topRight.Y - bottomLeft.Y - 1).Where(i => !IsInside(pointF.X, i,polygon)).ToArray();
                index = random.Next(0, range.Length);
                pointF.Y = range[index];
            }
            else
            {
                pointF.Y = random.Next(bottomLeft.Y, topRight.Y);
                range = Enumerable.Range(bottomLeft.X, topRight.X - bottomLeft.X - 1).Where(i => !IsInside(i, pointF.Y, polygon)).ToArray();
                index = random.Next(0, range.Length);
                pointF.X = range[index];
            }

            return pointF;
        }
    }
}