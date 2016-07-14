using Gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gee.Optimiser
{
	public class ParticleIterator : Iterator<OptimiserParticle>
	{
		public Random RandomGenerator;
		public double SlowdownFactor = .9;
		public double AccelerationFactor = .5;

		protected override IEnumerable<OptimiserParticle> Iterate(OptimiserParticle particle, IEnumerable<OptimiserParticle> population)
		{
			OptimiserParticle newParticle = particle.Clone();
			for (int i = particle.Variables - 1; i >= 0; i--)
			{
				newParticle.Speed[i] *= SlowdownFactor;
			}
			AccelerateTowards(newParticle,
				population.First());
			yield return newParticle;
		}

		private void AccelerateTowards(OptimiserParticle newParticle, OptimiserParticle particle)
		{
			IList<double> distance = newParticle.GetDistance(particle).ToList();
			for (int i = newParticle.Variables - 1; i >= 0; i--)
			{
				newParticle.Speed[i] += distance[i] * AccelerationFactor;
				particle.Position[i] += particle.Speed[i];
			}
		}
	}
}
