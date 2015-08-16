using Optimiser;
using System;
using Microsoft.Framework.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ParticleSwarmOptimisation
{
	public class Program
	{
		public void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
							.AddCommandLine(args).Build();

			string algorithm;
			string strVariables;
			string strIterations;
			string strPopulationSize;
			string strSwarmSize;

			if (!config.TryGet("variables", out strVariables))
			{
				strVariables = "1";
			}
			int variables = int.Parse(strVariables);
			if (!config.TryGet("iterations", out strIterations))
			{
				strIterations = "100";
			}
			int iterations = int.Parse(strIterations);
			if (!config.TryGet("populationSize", out strPopulationSize))
			{
				strPopulationSize = "50";
			}
			int populationSize = int.Parse(strPopulationSize);
			if (!config.TryGet("swarmSize", out strSwarmSize))
			{
				strSwarmSize = "100";
			}
			int swarmSize = int.Parse(strSwarmSize);

			if (!config.TryGet("algorithm", out algorithm))
			{
				throw new Exception("Algorithm not set");
			}
			Func<IList<double>, double> function;
			switch (algorithm)
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
						x = x.Select(y=> Math.Max(Math.Min(y*5, 5), -5)).ToList();
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
			Runner.Run(function, variables, iterations, populationSize, swarmSize);
		}
	}
}
