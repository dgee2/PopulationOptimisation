using com.gee.ParticleSwarmOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimiser
{
	public class Runner
	{
		public static void Run(Func<IList<double>, double> function, int variables, int iterations, int populationSize, int swarmSize)
		{
			OptimiserParticle.Function = function;
			OptimiserParticle.RandomGenerator = new Random();
			OptimiserParticle.Variables = variables;
			IList<Swarm<OptimiserParticle>> swarms = new List<Swarm<OptimiserParticle>>(populationSize);
			for (int i = 0; i < populationSize; i++)
			{
				swarms.Add(new Swarm<OptimiserParticle>(swarmSize));
			}
			uint iteration = 0;
			Console.Write(string.Join(",", swarms.Select(swarm => swarm.Particles.Max(x => x.Quality)).ToArray()));
			for (; iteration < iterations; iteration++)
			{
				Parallel.ForEach(swarms, swarm => swarm.IterateSwarm());
				Console.WriteLine();
				Console.Write(string.Join(",", swarms.Select(swarm => swarm.Particles.Max(x => x.Quality)).ToArray()));
			}
		}
	}
}