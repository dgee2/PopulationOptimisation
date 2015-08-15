using System;
using System.Collections.Generic;

namespace com.gee.ParticleSwarmOptimisation
{
	public interface IEnvironment<P> where P : IParticle<P>
	{
		IEnumerable<P> Particles { get; set; }
		IEnumerable<Tuple<P, double>> GetParticleDistances(P particle);
	}
}
