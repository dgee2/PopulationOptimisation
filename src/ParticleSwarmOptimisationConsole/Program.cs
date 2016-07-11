using Optimiser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParticleSwarmOptimisationConsole
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var config = new Options();
			if (CommandLine.Parser.Default.ParseArguments(args, config))
			{
				Func<IList<double>, double> function;
				switch (config.Algorithm)
				{
					case "Test":
						function = (x) =>
						{
							return x[0] * (1 - x[0]) * Math.Exp(x[0]);
						};
						break;
					case "StyblinskiTang":
						function = (x) =>
						{
							x = x.Select(y => Math.Max(Math.Min(y * 5, 5), -5)).ToList();
							double max = -x.Sum(y => Math.Pow(y, 4) - 16 * Math.Pow(y, 2) + 5 * y) / 2;
							if (max > 78.4)
							{
								int a = 1;
							}
							return max;
						};
						break;
					default:
						throw new NotImplementedException("Algorithm has not been implemented yet");
				}
				Runner.Run(function, config.Variables, config.Iterations, config.PopulationSize, config.SwarmSize);
			}
		}
	}
}
