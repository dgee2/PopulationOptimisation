using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.ParticleSwarmOptimisation
{
	public class Environment<P> : IEnvironment<P> where P :IParticle
	{
		public IEnumerable<P> Particles { get; set; } = new List<P>();

		public IEnumerable<Tuple<P, double>> GetParticleDistances(P particle)
		{
			return Particles.Where(x => x.Equals(particle))
							.Select(x => new Tuple<P, double>(particle, x.GetDistance(particle)));
		}
	}
}
