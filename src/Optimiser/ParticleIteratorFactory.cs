using com.gee.PopulationOptimisation;
using System;

namespace Optimiser
{
	public class ParticleIteratorFactory : IIteratorFactory<OptimiserParticle>
	{
		public Random RandomGenerator { get; set; }
		public double SlowdownFactor { get; set; } = .9;
		public double AccelerationFactor { get; set; } = .5;
		public Func<OptimiserParticle, double> Function { get; set; }

		public ParticleIteratorFactory(Random randomGenerator, Func<OptimiserParticle, double> function)
		{
			RandomGenerator = randomGenerator;
			Function = function;
		}

		public IIteratorFactory<OptimiserParticle> SubIteratorFactory { get; set; }

		public IIterator<OptimiserParticle> GetIterator()
		{
			return new ParticleIterator()
			{
				AccelerationFactor = AccelerationFactor,
				RandomGenerator = RandomGenerator,
				SlowdownFactor = SlowdownFactor,
				Selector = new ParticleSelector() { OrderBy = Function }
			};
		}
	}
}
