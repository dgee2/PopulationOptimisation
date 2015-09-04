using System;
using System.Collections.Generic;
using System.Linq;

namespace com.gee.ParticleSwarmOptimisation
{
	public abstract class Selector<P> : ISelector<P>
		where P : IParticle<P>, new()
	{
		public IEnumerable<P> Swarm { get; set; }
		protected abstract Func<P, bool> function { get; }
		protected abstract Func<P, double> orderBy { get; }

		public IEnumerable<P> SelectParticles(IEnumerable<P> swarm)
		{
			if (function != null)
			{
				swarm = swarm.Where(function);
			}
			if (orderBy != null)
			{
				swarm.OrderBy(orderBy);
			}
			return swarm;
		}
	}
}