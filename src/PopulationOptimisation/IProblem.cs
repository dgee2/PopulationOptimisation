using System;

namespace Gee.PopulationOptimisation
{
	public interface IProblem<P> where P : IProblemRepresentation<P>, new()
	{
		Func<P, double> Function { get; set; }
	}
}
