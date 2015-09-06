using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimiser
{
	public class Runner
	{
		public static void Run(Func<OptimiserParticle, double> function, int variables, uint iterations, int populationSize, int populationCount)
		{
			Random random = new Random();
			IList<IList<OptimiserParticle>> populations = new List<IList<OptimiserParticle>>();
			for (int j = populationCount - 1; j >= 0; j--)
			{
				populations.Add(new List<OptimiserParticle>(populationSize));
				for (int i = populationSize; i > 0; i--)
				{
					populations[j].Add(new OptimiserParticle(random, variables));
				}
			}
			ParticleIteratorFactory iteratorFactory = new ParticleIteratorFactory(random, function);


			for (uint iteration = 1; iteration <= iterations; iteration++)
			{
				var newSwarm = populations.AsParallel().Select(population => iteratorFactory.GetIterator().Iterate(population));
				Console.WriteLine(string.Join(",", populations.Select(population =>
				population.Max(particle => iteratorFactory.Function(particle))
				)));
			}
			printDetails(iteratorFactory.Function, populations);
		}

		private static void printDetails(Func<OptimiserParticle, double> function, IList<IList<OptimiserParticle>> swarm)
		{
			IEnumerable<IEnumerable<double>> qualities = swarm.Select(population => population.Select(
				particle => function(particle)
				));
			Console.WriteLine("(" + string.Join("),(",
				qualities.Select(population => population.Select(particle => string.Join(",", particle)))
				) + ")");
		}
	}
}