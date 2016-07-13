﻿using System.Collections.Generic;

namespace Gee.PopulationOptimisation
{
	public interface IIterator<P> where P : IProblemRepresentation<P>, new()
	{
		IIteratorFactory<P> SubIteratorFactory { get; set; }
		P Particle { get; set; }
		IList<P> Iterate(IEnumerable<P> population);
	}
}
