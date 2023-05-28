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
            CompoundBodies = new List<CBody>();
            this.Density = this.GetCompoundDensity();
        }
        private void AddBody(CBody body)
        {
            CompoundBodies.Add(body);
            this.Density = this.GetCompoundDensity();
        }
        private bool DeleteBody(int id)
        {
            //if (index < 0 || index >= CompoundBodies.Count)
            //{
            //    return false;
            //}

            //CompoundBodies.RemoveAt(index);
            //this.Density = this.GetCompoundDensity();

            return true;
        }
        private double GetCompoundDensity()
        {
            double density = 0;

            foreach (CBody body in CompoundBodies)
            {
                density += body.Density;
            }

            return density / CompoundBodies.Count;
        }
        public override double GetVolume()
        {
            double volume = 0;
            foreach (CBody body in CompoundBodies)
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
            return $"{this.Type}:\n\tid: {this.Id}\n\tdensity: {this.GetCompoundDensity()}\n\tvolume: {this.GetVolume()}\n\tmass: {this.GetMass()}";
        }
        public string ShowAllBodiesInCompound()
        {
            string info = "";

            foreach (CBody body in CompoundBodies)
            {
                info += body.ToString() + "\n\n---------------\n\n";
            }

            return info;
        }
        
        public List<CBody> CompoundBodies { get; set; }
    }
}
