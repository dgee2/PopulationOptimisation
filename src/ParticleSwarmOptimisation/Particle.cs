using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.gee.ParticleSwarmOptimisation
{
	public abstract class Particle<P> : IParticle<P> where P : Particle<P>
	{
		public IList<double> Position { get; set; }
		public IList<double> Speed { get; set; }

		public double GetDistance(P particle)
		{
			double res = 0;
			for (int i = Position.Count - 1; i >= 0; i--)
			{
				double temp = Position[i] - particle.Position[i];
				res += temp * temp;
			}
			return Math.Sqrt(res);
		}

		protected void IteratePosition()
		{
			for (int i = Position.Count - 1; i >= 0; i--)
			{
				Position[i] += Speed[i];
			}
		}

		public abstract IEnumerable<P> Iterate(IEnvironment<P> environment);
	}
}
