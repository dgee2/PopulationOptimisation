using System.Collections.Generic;

namespace com.gee.ParticleSwarmOptimisation
{
	public interface ISelector<P>
		where P : IParticle<P>, new()
	{
		IEnumerable<P> SelectParticles(IEnumerable<P> swarm);
	}
}
