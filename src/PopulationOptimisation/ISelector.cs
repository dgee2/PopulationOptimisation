using System.Collections.Generic;

namespace com.gee.PopulationOptimisation
{
	public interface ISelector<P>
		where P : IProblemRepresentation<P>, new()
	{
		IEnumerable<P> SelectParticles(IEnumerable<P> population);
	}
}
