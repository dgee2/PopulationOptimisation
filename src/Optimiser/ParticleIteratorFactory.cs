using com.gee.PopulationOptimisation;
using System;

namespace Optimiser
{
	public class ParticleIteratorFactory : IIteratorFactory<OptimiserParticle>
	{
		public Random RandomGenerator { get; set; }
		public double SlowdownFactor { get; set; } = .9;
		public double AccelerationFactor { get; set; } = .5;

		public ParticleIteratorFactory(Random randomGenerator)
		{
			RandomGenerator = randomGenerator;
		}

		public IIteratorFactory<OptimiserParticle> SubIterator { get; set; }

		public IIterator<OptimiserParticle> GetIterator()
		{
			return new ParticleIterator()
			{
				AccelerationFactor = AccelerationFactor,
				RandomGenerator = RandomGenerator,
				SlowdownFactor = SlowdownFactor
			};
		}
	}
}
