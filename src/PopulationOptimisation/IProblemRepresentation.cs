using System.Collections.Generic;

namespace com.gee.PopulationOptimisation
{
	public interface IProblemRepresentation<P> where P : IProblemRepresentation<P>, new()
	{
		P Clone();
	}
}
