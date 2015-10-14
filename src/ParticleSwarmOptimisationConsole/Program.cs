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
			uint iterations = uint.Parse(strIterations);
			if (!config.TryGet("populationSize", out strPopulationSize))
			{
				strPopulationSize = "50";
			}
			int populationSize = int.Parse(strPopulationSize);
			if (!config.TryGet("populationCount", out strSwarmSize))
			{
				strSwarmSize = "1";
			}
			int swarmSize = int.Parse(strSwarmSize);

			if (!config.TryGet("algorithm", out algorithm))
			{
				throw new Exception("Algorithm not set");
			}
			Func<OptimiserParticle, double> function;
			switch (algorithm)
			{
				case "Test":
					function = (x) =>
					{
						return x.Position.Sum(y => y * y);
					};
					break;
				case "StyblinskiTang":
					function = (x) =>
					{
						return x.Position.Sum(y => Math.Pow(y, 4) - 16 * Math.Pow(y, 2) + 5 * y) / 2;
					};
					break;
				default:
					throw new NotImplementedException("Algorithm has not been implemented yet");
			}
			string strParallel;
			if (!config.TryGet("parallel", out strParallel))
			{
				strParallel = "true";
			}
			bool parallel = bool.Parse(strParallel);
			Runner.Run(function, variables, iterations, populationSize, swarmSize, parallel);
		}
	}
}
