using Microsoft.Extensions.Configuration;
using Optimiser;
using System;
using System.Linq;

namespace ParticleSwarmOptimisationConsole
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
							.AddCommandLine(args)
							.AddEnvironmentVariables()
							.Build();

			string algorithm;
			string strVariables;
			string strIterations;
			string strPopulationSize;
			string strSwarmSize;

			strVariables = config["variables"];
			if (strVariables==null)
			{
				strVariables = "1";
			}
			int variables = int.Parse(strVariables);

			strIterations = config["iterations"];
			if (strIterations==null)
			{
				strIterations = "100";
			}
			uint iterations = uint.Parse(strIterations);
			strPopulationSize = config["populationSize"];
			if (strPopulationSize == null)
			{
				strPopulationSize = "50";
			}
			int populationSize = int.Parse(strPopulationSize);
			strSwarmSize = config["populationCount"];
			if (strSwarmSize == null)
			{
				strSwarmSize = "1";
			}
			int swarmSize = int.Parse(strSwarmSize);

			algorithm = config["algorithm"];
			if (algorithm == null)
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
			string strParallel = config["parallel"];
			if (strParallel == null)
			{
				strParallel = "true";
			}
			bool parallel = bool.Parse(strParallel);
			Runner.Run(function, variables, iterations, populationSize, swarmSize, parallel);
		}
	}
}
