using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.ParticleSwarmOptimisation
{	
	public class Environment<P> : IEnvironment<P> where P :IParticle<P>
	{
		public IEnumerable<P> Particles { get; set; } = new List<P>();

		public IEnumerable<Tuple<P, double>> GetParticleDistances(P particle)
		{
			return Particles.Select(x => new Tuple<P, double>(particle, x.GetDistance(particle)));
		}

		public void IterateEnvironment()
		{
			IList<P> newParticles = new List<P>();
			foreach (P particle in Particles)
			{
				foreach (P newParticle in particle.Iterate(this))
				{
					newParticles.Add(newParticle);
				}
			}
			Particles = newParticles;
		}
	}
}
