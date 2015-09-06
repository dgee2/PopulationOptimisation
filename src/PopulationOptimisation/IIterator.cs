using System.Collections.Generic;

namespace com.gee.PopulationOptimisation
{
	public interface IIterator<P> where P : IParticle<P>, new()
	{
		IIteratorFactory<P> SubIteratorFactory { get; set; }
		P Particle { get; set; }
		IEnumerable<P> Iterate(IEnumerable<P> population);
	}
}
