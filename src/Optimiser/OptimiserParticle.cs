using com.gee.ParticleSwarmOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optimiser
{
	public class OptimiserParticle : Particle<OptimiserParticle>, IComparable<OptimiserParticle>
	{
		public static Random RandomGenerator;
		static double slowdownFactor = .9;
		static double accelerationFactor = .5;
		public static Func<IList<double>, double> Function;
		public static int Variables;

		public OptimiserParticle()
		{
			Position = new List<double>(Variables);
			Speed = new List<double>(Variables);
			for (int i = 0; i < Variables; i++)
			{
				Position.Add(RandomGenerator.NextDouble() * 2.0 - 1.0);
				Speed.Add(RandomGenerator.NextDouble() * 2.0 - 1.0);
			}
		}

		public override IEnumerable<OptimiserParticle> Iterate(ISwarm<OptimiserParticle> swarm)
		{
			OptimiserParticle particle = new OptimiserParticle();
			particle.Position = Position.ToList();
			particle.Speed = Speed.ToList();
			for (int i = Variables - 1; i >= 0; i--)
			{
				particle.Speed[i] *= slowdownFactor;
			}
			particle.AccelerateTowards(swarm.Particles.Max());
			particle.IteratePosition();
			yield return particle;
		}

		private void AccelerateTowards(OptimiserParticle particle)
		{
			IList<double> distance = GetDistance(particle).ToList();
			for (int i = Speed.Count - 1; i >= 0; i--)
			{
				Speed[i] += distance[i] * accelerationFactor;
			}
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
