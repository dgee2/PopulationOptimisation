using System.Collections.Generic;

namespace Gee.PopulationOptimisation
{
	public interface IParentSelector<P>
		where P : IProblemRepresentation<P>, new()
	{
		IEnumerable<P> SelectParticles(P particle, IEnumerable<P> population);
	}
}
