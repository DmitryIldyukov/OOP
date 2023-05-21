using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Body
{
    class CParallelepiped : CBody
    {
        public CParallelepiped(double width, double height, double depth, double density)
            : base("Parallelepiped", density)
        {

            this.width = width;
            this.height = height;
            this.depth = depth;
        }
        public override double GetVolume()
        {
            return this.width * this.height * this.depth;
        }

        public double GetWidth()
        {
            return this.width;
        }
        public double GetHeight()
        {
            return this.height;
        }
        public double GetDepth()
        {
            return this.depth;
        }

        private double width;
        private double height;
        private double depth;

    }
}
