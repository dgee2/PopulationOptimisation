using System.Collections.Generic;

namespace com.gee.ParticleSwarmOptimisation
{
	public interface IParentSelector<P>
		where P : IParticle<P>, new()
	{
		IEnumerable<P> SelectParticles(P particle, IEnumerable<P> swarm);
	}
}
