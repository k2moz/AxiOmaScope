using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSharpGlNext.BL
{
    public abstract class myPoint
    {

    }
    public class myPoint2 : myPoint
    {
        public myPoint2(float x, float y)
        {
            fieldX = x;
            fieldY = y;
        }
        public float fieldX { get; set; }
        public float fieldY { get; set; }
    }
    public class myPoint3 : myPoint2
    {
        public myPoint3(float x, float y, float z)
            : base(x, y)
        {
            fieldZ = z;
        }
        public float fieldZ { get; set; }
    }
}
