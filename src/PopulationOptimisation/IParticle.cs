using System.Collections.Generic;

namespace com.gee.PopulationOptimisation
{
	public interface IParticle<P> where P : IParticle<P>, new()
	{
		IList<double> Speed { get; }
		IList<double> Position { get; }
		IEnumerable<double> GetDistance(P particle);
		double GetCrowDistance(P particle);
	}
}
