using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    abstract class CBody
    {
        public CBody(string type, double density)
        {
            this.Type = type;
            this.Density = density;
        }

        abstract public double GetVolume();

        virtual public double GetMass()
        {
            return GetVolume() * this.Density;
        }

        public override string ToString()
        {
            return $"{this.Type}:\n\tdensity: {this.Density}\n\tvolume: {GetVolume()}\n\tmass: {GetMass()}";
        }

        public string Type { get { return type; } set { type = value; } }
        public double Density { get { return density; } set { density = value; } }

        private string type;
        private double density;
    }
}
