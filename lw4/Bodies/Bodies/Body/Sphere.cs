using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Body
{
    class CSphere : CBody
    {
        public CSphere(double basic_radius, double density)
            : base("Sphere", density)
        {
            this.basic_radius = basic_radius;
            Density = density;
        }

        public override double GetVolume()
        {
            return (Math.Pow(basic_radius, 3) * Math.PI * 4) / 3;
        }

        public double GetRadius()
        {
            return basic_radius;
        }

        private double basic_radius;
    }
}
