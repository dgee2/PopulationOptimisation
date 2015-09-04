using System.Collections.Generic;

namespace com.gee.ParticleSwarmOptimisation
{
	interface IIterateAll<P> : IIterator<P> where P : IParticle<P>, new()
	{
		IEnumerable<P> Iterate(P particle, ISelector<P> swarm);
	}
}
