﻿namespace Gee.PopulationOptimisation
{
	public interface IIteratorFactory<P> where P : IProblemRepresentation<P>, new()
	{
		IIterator<P> GetIterator();
		IIteratorFactory<P> SubIteratorFactory { get; set; }
	}
}
