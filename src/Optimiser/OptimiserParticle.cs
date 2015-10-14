using com.gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optimiser
{
	public class OptimiserParticle : IProblemRepresentation<OptimiserParticle>
	{
		public int Variables;
		public IList<double> Position { get; set; }
		public IList<double> Speed { get; set; }

		public OptimiserParticle()
		{
		}
		public OptimiserParticle(Random randomGenerator, int variables)
		{
			Variables = variables;
			Position = new List<double>(variables);
			Speed = new List<double>(variables);
			for (int i = 0; i < Variables; i++)
			{
				Position.Add(randomGenerator.NextDouble() * 2.0 - 1.0);
				Speed.Add(randomGenerator.NextDouble() * 2.0 - 1.0);
			}
		}

		public OptimiserParticle Clone()
		{
			return new OptimiserParticle()
			{
				Position = Position.ToList(),
				Speed = Speed.ToList(),
				Variables = Variables
			};
		}

		public IList<double> GetDistance(OptimiserParticle particle)
		{
			IList<double> list = new List<double>(particle.Position.Count);
			for (int i = particle.Position.Count - 1; i >= 0; i--)
			{
				list.Add(particle.Position[i] - Position[i]);
			}
			return list;
		}

		public double GetCrowDistance(OptimiserParticle particle)
		{
			double res = 0;
			foreach (var item in GetDistance(particle))
			{
				res += item * item;
			}
			return Math.Sqrt(res);
		}
	}
}
