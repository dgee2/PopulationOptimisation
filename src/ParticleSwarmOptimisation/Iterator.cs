using System.Collections.Generic;
using System.Linq;

namespace com.gee.ParticleSwarmOptimisation
{
	public abstract class Iterator<P> : IIterator<P> where P : IParticle<P>, new()
	{
		public ISelector<P> Selector { get; set; }
		public IParentSelector<P> ParentSelector { get; set; }
		public P Particle { get; set; }
		public ISelector<P> Restrictor { get; set; }

		public IIteratorFactory<P> SubIteratorFactory { get; set; }

		public IEnumerable<P> Iterate(IEnumerable<P> swarm)
		{
			if (Selector != null)
			{
				swarm = Selector.SelectParticles(swarm);
			}
			if (ParentSelector == null)
			{
				swarm = swarm.SelectMany(particle =>
				{
					return Iterate(particle, swarm);
				});
			}
			else
			{
				swarm = swarm.SelectMany(particle =>
				{
					return Iterate(particle, ParentSelector.SelectParticles(particle, swarm));
				});
			}
			if (SubIteratorFactory != null)
			{
				swarm = swarm.SelectMany(particle =>
				 {
					 IList<P> ret = new List<P>();
					 IIterator<P> iterator = SubIteratorFactory.GetIterator();
					 iterator.Particle = particle;
					 foreach (var newParticle in iterator.Iterate(swarm))
					 {
						 ret.Add(newParticle);
					 }
					 return ret;
				 });
			}
			if (Restrictor != null)
			{
				swarm = Restrictor.SelectParticles(swarm);
			}
			return swarm;
		}
		protected abstract IEnumerable<P> Iterate(P particle, IEnumerable<P> swarm);
	}
}
