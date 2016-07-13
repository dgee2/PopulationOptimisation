using System;
using System.Collections.Generic;
using System.Linq;

namespace Gee.Optimiser
{
	public class Runner
	{
		public static void Run(Func<OptimiserParticle, double> function, int variables, int iterations, int populationSize, int populationCount, bool parallel = true)
		{
			Random random = new Random();
			IList<IList<OptimiserParticle>> populations = new List<IList<OptimiserParticle>>();
			for (int j = 0; j < populationCount; j++)
			{
				populations.Add(new List<OptimiserParticle>(populationSize));
				for (int i = populationSize; i > 0; i--)
				{
					populations[j].Add(new OptimiserParticle(random, variables));
				}
			}
			ParticleIteratorFactory iteratorFactory = new ParticleIteratorFactory(random, function);


			for (int iteration = 1; iteration <= iterations; iteration++)
			{
				var p = new List<IList<OptimiserParticle>>();
				foreach (var item in populations)
				{
					var iterator = iteratorFactory.GetIterator();
					p.Add(iterator.Iterate(item));
				}
				if (parallel)
				{
					populations = populations.AsParallel().Select(population => iteratorFactory.GetIterator().Iterate(population)).ToList();
				}
				else
				{
					populations = populations.Select(population => iteratorFactory.GetIterator().Iterate(population)).ToList();
				}
			}
			printDetails(iteratorFactory.Function, populations);
		}

		private static void printDetails(Func<OptimiserParticle, double> function, IList<IList<OptimiserParticle>> swarm)
		{
			IEnumerable<IEnumerable<double>> qualities = swarm.Select(population => population.Select(
				particle => function(particle)
				));
			Console.WriteLine(string.Join("\n",
				qualities.Select(population => population.Min()
				)));
		}
	}
}