using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    abstract class CBody
    {
        private static int staticBodyId;
        static CBody()
        {
            staticBodyId = 0;
        }

        private static int NextId()
        {
            staticBodyId++;
            return staticBodyId;
        }

        public CBody(string type, double density)
        {
            this.Id = NextId();
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
            return $"{this.Type}:\n\tid: {this.Id}\n\tdensity: {this.Density}\n\tvolume: {GetVolume()}\n\tmass: {GetMass()}";
        }

        public string Type { get { return type; } set { type = value; } }
        public double Density { get { return density; } set { density = value; } }
        public int Id { get { return id; } set { id = value; } }

        private int id;
        private string type;
        private double density;
    }
}
