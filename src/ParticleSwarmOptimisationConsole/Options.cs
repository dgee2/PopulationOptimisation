using CommandLine;
using CommandLine.Text;
using Gee.Optimiser;
using System;
using System.Linq;

namespace ParticleSwarmOptimisationConsole
{
	// Define a class to receive parsed values
	class Options
	{
		[Option("variables",
			HelpText = "The number of variables",
			DefaultValue = 1)]
		public int Variables { get; set; }

		[Option("iterations",
			HelpText = "The number of iterations to run until",
			DefaultValue = 100)]
		public uint Iterations { get; set; }

		[Option("populationSize",
			HelpText = "The size of the population to use",
			DefaultValue = 50)]
		public int PopulationSize { get; set; }

		[Option("swarmSize",
			HelpText = "The size of the swarm to use",
			DefaultValue = 100)]
		public uint SwarmSize { get; set; }

		[Option('a',
			"algorithm",
			HelpText = "The algorithm to use",
			Required = true)]
		public string Algorithm { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[Option('p',
			"parallel",
			HelpText = "Whether to parallelise",
			DefaultValue = false)]
		public bool Parallel { get; set; }

		public Func<OptimiserParticle, double> Function
		{
			get
			{
				Func<OptimiserParticle, double> function;
				switch (Algorithm)
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
				return function;
			}
		}

		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this,
			  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}
