using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.ParticleSwarmOptimisation
{
	public class Swarm<P> : ISwarm<P> where P : IParticle<P>, new()
	{
		public Swarm(int numberOfParticles)
		{
			IList<P> particles = new List<P>(numberOfParticles);
			for (int i = 0; i < numberOfParticles; i++)
			{
				particles.Add(new P());
			}
			Particles = particles;
		}

		public IEnumerable<P> Particles { get; set; }

		public IEnumerable<Tuple<P, double>> GetParticleDistances(P particle)
		{
			return Particles.Select(x => new Tuple<P, double>(particle, x.GetCrowDistance(particle)));
		}

		public void IterateSwarm()
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
