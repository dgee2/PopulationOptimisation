using Gee.PopulationOptimisation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gee.Optimiser
{
	public class OptimiserParticle : IProblemRepresentation<OptimiserParticle>
	{
		public int Variables { get; }
		public double[] Position { get; }
		public double[] Speed { get; }

		public OptimiserParticle()
		{
		}

		private OptimiserParticle(double[] position, double[] speed, int variables)
		{
			Position = position;
			Speed = speed;
			Variables = variables;
		}

		public OptimiserParticle(Random randomGenerator, int variables)
		{
			Variables = variables;
			Position = new double[variables];
			Speed = new double[variables];
			for (int i = 0; i < Variables; i++)
			{
				Position[i] = randomGenerator.NextDouble() * 2.0 - 1.0;
				Speed[i] = randomGenerator.NextDouble() * 2.0 - 1.0;
			}
		}

		public OptimiserParticle Clone()
		{
			return new OptimiserParticle(
				Position,
				Speed,
				Variables
			);
		}

		public double[] GetDistance(OptimiserParticle particle)
		{
			double[] list = new double[Variables];
			for (int i = Variables - 1; i >= 0; i--)
			{
				list[i] = particle.Position[i] - Position[i];
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
