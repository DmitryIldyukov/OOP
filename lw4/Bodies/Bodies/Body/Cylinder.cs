using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Body
{
    class CCylinder : CBody
    {
        public CCylinder(double basic_radius, double height, double density)
            : base("Cylinder", density)
        {
            this.basic_radius = basic_radius;
            this.height = height;
        }

        public override double GetVolume()
        {
            return (Math.Pow(basic_radius, 2) * Math.PI * this.height);
        }

        public double GetRadius()
        {
            return this.basic_radius;
        }

        public double GetHeight()
        {
            return this.height;
        }

        private double basic_radius;
        private double height;
    }
}
