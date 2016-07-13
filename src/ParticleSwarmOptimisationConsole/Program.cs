using Gee.Optimiser;

namespace ParticleSwarmOptimisationConsole
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var config = new Options();
			if (!CommandLine.Parser.Default.ParseArguments(args, config))
				return;

			Runner.Run(config.Function, config.Variables, config.Iterations, config.PopulationSize, config.SwarmSize, config.Parallel);
		}
	}
}
