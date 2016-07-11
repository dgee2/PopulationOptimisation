using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public int Iterations { get; set; }

		[Option("populationSize",
			HelpText = "The size of the population to use",
			DefaultValue = 50)]
		public int PopulationSize { get; set; }

		[Option("swarmSize",
			HelpText = "The size of the swarm to use",
			DefaultValue = 100)]
		public int SwarmSize { get; set; }

		[Option('a',
			"algorithm",
			HelpText = "The algorithm to use",
			Required = true)]
		public string Algorithm { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this,
			  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}
