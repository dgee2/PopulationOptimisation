using System.Collections.Generic;
using System.Linq;

namespace com.gee.PopulationOptimisation
{
	public abstract class Iterator<P> : IIterator<P> where P : IParticle<P>, new()
	{
		public ISelector<P> Selector { get; set; }
		public IParentSelector<P> ParentSelector { get; set; }
		public P Particle { get; set; }
		public ISelector<P> Restrictor { get; set; }

		public IIteratorFactory<P> SubIteratorFactory { get; set; }

		public IEnumerable<P> Iterate(IEnumerable<P> population)
		{
			if (Selector != null)
			{
				population = Selector.SelectParticles(population);
			}
			if (ParentSelector == null)
			{
				population = population.SelectMany(particle =>
				{
					return Iterate(particle, population);
				});
			}
			else
			{
				population = population.SelectMany(particle =>
				{
					return Iterate(particle, ParentSelector.SelectParticles(particle, population));
				});
			}
			if (SubIteratorFactory != null)
			{
				population = population.SelectMany(particle =>
				 {
					 IList<P> ret = new List<P>();
					 IIterator<P> iterator = SubIteratorFactory.GetIterator();
					 iterator.Particle = particle;
					 foreach (var newParticle in iterator.Iterate(population))
					 {
						 ret.Add(newParticle);
					 }
					 return ret;
				 });
			}
			if (Restrictor != null)
			{
				population = Restrictor.SelectParticles(population);
			}
			return population;
		}
		protected abstract IEnumerable<P> Iterate(P particle, IEnumerable<P> population);
	}
}
