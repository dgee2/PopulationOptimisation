using System.Collections.Generic;
using System.Linq;

namespace Gee.PopulationOptimisation
{
	public abstract class Iterator<P> : IIterator<P> where P : IProblemRepresentation<P>, new()
	{
		public ISelector<P> Selector { get; set; }
		public IParentSelector<P> ParentSelector { get; set; }
		public P Particle { get; set; }

		public ISelector<P> Restrictor { get; set; }

		public IIteratorFactory<P> SubIteratorFactory { get; set; }

		public IList<P> Iterate(IEnumerable<P> population)
		{
			population = Selector.SelectParticles(population);
			if (ParentSelector == null)
			{
				List<P> pop = new List<P>();
				foreach (var particle in population)
				{
					pop.AddRange(Iterate(particle, population));
				}
				population = pop;
			}
			else
			{
				List<P> pop = new List<P>();
				foreach (var particle in population)
				{
					pop.AddRange(Iterate(particle, ParentSelector.SelectParticles(particle, population)));
				}
				population = pop;
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
			return population.ToList();
		}
		protected abstract IEnumerable<P> Iterate(P particle, IEnumerable<P> population);
	}
}
