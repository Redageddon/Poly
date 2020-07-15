using System.Drawing;

namespace Poly
{
    public class Polygon
    {
        private readonly PointF[] points;

        public Polygon(PointF[] points) => this.points = points;

        public int Length => this.points.Length;
        public PointF this[int i] => this.points[i];
    }
}