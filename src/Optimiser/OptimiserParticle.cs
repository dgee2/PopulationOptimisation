using com.gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optimiser
{
	public class OptimiserParticle : ProblemRepresentation<OptimiserParticle>, IComparable<OptimiserParticle>
	{
		public Func<IList<double>, double> Function;
		public int Variables;

		public OptimiserParticle()
		{
			Position = new List<double>(Variables);
			Speed = new List<double>(Variables);
		}
		public OptimiserParticle(Random randomGenerator)
		{
			for (int i = 0; i < Variables; i++)
			{
				Position.Add(randomGenerator.NextDouble() * 2.0 - 1.0);
				Speed.Add(randomGenerator.NextDouble() * 2.0 - 1.0);
			}
		}

		public OptimiserParticle CloneParticle()
		{
			return new OptimiserParticle()
			{
				Function = Function,
				Position = Position.ToList(),
				Speed = Speed.ToList(),
				Variables = Variables
			};
		}


		public int CompareTo(OptimiserParticle other)
		{
			return Quality.CompareTo(other.Quality);
		}

		public double Quality
		{
			get
			{
				return Function(Position);
			}
		}
	}
}
