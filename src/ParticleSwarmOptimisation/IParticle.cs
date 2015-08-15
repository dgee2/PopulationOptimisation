using System.Collections.Generic;

namespace com.gee.ParticleSwarmOptimisation
{
	public interface IParticle<P> where P : IParticle<P>
	{
		IList<double> Speed { get; }
		IList<double> Position { get; }
		IEnumerable<double> GetDistance(P particle);
		double GetCrowDistance(P particle);

		IEnumerable<P> Iterate(IEnvironment<P> environment);
	}
}
