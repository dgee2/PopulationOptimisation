using System.Collections.Generic;

namespace com.gee.PopulationOptimisation
{
	public interface IParentSelector<P>
		where P : IProblemRepresentation<P>, new()
	{
		IEnumerable<P> SelectParticles(P particle, IEnumerable<P> population);
	}
}
