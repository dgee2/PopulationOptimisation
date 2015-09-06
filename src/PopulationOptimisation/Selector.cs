using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.PopulationOptimisation
{
	public abstract class Selector<P> : ISelector<P>
		where P : IProblemRepresentation<P>, new()
	{
		protected abstract Func<P, bool> function { get; }
		protected abstract Func<P, double> orderBy { get; }

		public IEnumerable<P> SelectParticles(IEnumerable<P> population)
		{
			if (function != null)
			{
				population = population.Where(function);
			}
			if (orderBy != null)
			{
				population.OrderBy(orderBy);
			}
			return population;
		}
	}
}