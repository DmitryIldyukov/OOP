using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Body
{
    class CCompound : CBody
    {
        public CCompound()
            : base ("Compound body", 0)
        {
            ListBodies = new List<CBody>();
            this.Density = this.GetCompoundDensity();
        }
        private void AddBody(CBody body)
        {
            ListBodies.Add(body);
            this.Density = this.GetCompoundDensity();
        }
        private bool DeleteBody(int index)
        {
            if (index < 1 || index > ListBodies.Count)
            {
                return false;
            }

            ListBodies.RemoveAt(index--);
            this.Density = this.GetCompoundDensity();

            return true;
        }
        private double GetCompoundDensity()
        {
            double density = 0;

            foreach (CBody body in ListBodies)
            {
                density += body.Density;
            }

            return density / ListBodies.Count;
        }
        public override double GetVolume()
        {
            double volume = 0;
            foreach (CBody body in ListBodies)
            {
                volume += body.GetVolume();
            }

            return volume;
        }
        public override double GetMass()
        {
            return this.GetVolume() * GetCompoundDensity();
        }
        public override string ToString()
        {
            return $"{this.Type}:\n\tdensity: {this.GetCompoundDensity()}\n\tvolume: {this.GetVolume()}\n\tmass: {this.GetMass()}";
        }
        public string ShowAllBodiesInCompound()
        {
            string info = "";

            foreach (CBody body in ListBodies)
            {
                info += body.ToString() + "\n\n---------------\n\n";
            }

            return info;
        }
        
        public List<CBody> ListBodies { get; set; }
    }
}
