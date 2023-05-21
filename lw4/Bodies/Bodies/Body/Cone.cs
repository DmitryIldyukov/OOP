using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Body
{
    class CCone : CBody
    {
        public CCone(double basic_radius, double height, double density)
            : base("Cone", density)
        {
            this.basic_radius = basic_radius;
            this.height = height;
        }
        public override double GetVolume()
        {
            return (Math.PI * Math.Pow(basic_radius, 2) * height) / 3;
        }

        private double height;
        private double basic_radius;
    }
}
