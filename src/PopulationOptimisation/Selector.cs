using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.PopulationOptimisation
{
	public abstract class Selector<P> : ISelector<P>
		where P : IProblemRepresentation<P>, new()
	{
		public abstract Func<P, bool> Where { get; set; }
		public abstract Func<P, double> OrderBy { get; set; }

		public IEnumerable<P> SelectParticles(IEnumerable<P> population)
		{
			if (Where != null)
			{
				population = population.Where(Where);
			}
			if (OrderBy != null)
			{
				population.OrderBy(OrderBy);
			}
			return population;
		}
	}
}