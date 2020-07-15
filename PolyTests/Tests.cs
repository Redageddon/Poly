using System.Drawing;
using NUnit.Framework;
using Poly;

// https://www.desmos.com/calculator/axektxytpa
namespace PolyTests
{
    public class Tests
    {
        private readonly Polygon square = new Polygon(new[]
        {
            new PointF(0,   0),
            new PointF(100, 0),
            new PointF(100, 100),
            new PointF(0,   100)
        });

        private readonly Polygon pentagon = new Polygon(new[]
        {
            new PointF(35, 65),
            new PointF(45, 75),
            new PointF(45, 95),
            new PointF(30, 90),
            new PointF(20, 75)
        });
        
        private readonly Polygon triangle = new Polygon(new[]
        {
            new PointF(55, 70),
            new PointF(20, 60),
            new PointF(50, 90)
        });

        [Test]
        public void InSquare()
        {
            PointF pointF = new PointF(50, 50);

            Assert.IsTrue(pointF.IsInside(this.square));
        }
        
        [Test]
        public void OutSquare()
        {
            PointF pointF = new PointF(150, 50);

            Assert.IsTrue(!pointF.IsInside(this.square));
        }
        
        [Test]
        public void InPentagon()
        {
            PointF pointF = new PointF(35, 80);

            Assert.IsTrue(pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void OutPentagon()
        {
            PointF pointF = new PointF(0, 0);

            Assert.IsTrue(!pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void InSquareAndPentagon()
        {
            PointF pointF = new PointF(35, 80);

            Assert.IsTrue(pointF.IsInside(this.square) && pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void InSquareNotPentagon()
        {
            PointF pointF = new PointF(20, 90);

            Assert.IsTrue(pointF.IsInside(this.square) && !pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void InTriangle()
        {
            PointF pointF = new PointF(35, 70);

            Assert.IsTrue(pointF.IsInside(this.triangle));
        }
        
        [Test]
        public void InTriangleAndPentagon()
        {
            PointF pointF = new PointF(35, 70);

            Assert.IsTrue(pointF.IsInside(this.triangle) && pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void InTriangleNotPentagon()
        {
            PointF pointF = new PointF(50, 75);

            Assert.IsTrue(pointF.IsInside(this.triangle) && !pointF.IsInside(this.pentagon));
        }
        
        [Test]
        public void InTriangleAndPentagonAndSquare()
        {
            PointF pointF = new PointF(40, 75);

            Assert.IsTrue(pointF.IsInside(this.triangle) && pointF.IsInside(this.pentagon) && pointF.IsInside(this.square));
        }
        
        [Test]
        public void RandomInSquare()
        {
            Assert.IsTrue(!this.square.GetRandomPoint().IsInside(this.square));
        }
        
        [Test]
        public void RandomInPentagon()
        {
            Assert.IsTrue(!this.pentagon.GetRandomPoint().IsInside(this.pentagon));
        }
        
        [Test]
        public void RandomInTriangle()
        {
            Assert.IsTrue(!this.pentagon.GetRandomPoint().IsInside(this.pentagon));
        }
    }
}