using System;

namespace com.gee.PopulationOptimisation
{
	public interface IProblem<P> where P : IParticle<P>, new()
	{
		Func<P, double> Function { get; set; }
	}
}
