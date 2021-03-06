﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.gee.ParticleSwarmOptimisation
{
	public abstract class Particle<P> : IParticle<P> where P : Particle<P>
	{
		public IList<double> Position { get; set; }
		public IList<double> Speed { get; set; }

		public IEnumerable<double> GetDistance(P particle)
		{
			for (int i = 0; i < Position.Count; i++)
			{
				yield return particle.Position[i] - Position[i];
			}
		}

		public double GetCrowDistance(P particle) {
			double res = 0;
			foreach (var item in GetDistance(particle))
			{
				res += item *item;
			}
			return Math.Sqrt(res);
		}

		protected void IteratePosition()
		{
			for (int i = Position.Count - 1; i >= 0; i--)
			{
				Position[i] += Speed[i];
			}
		}

		public abstract IEnumerable<P> Iterate(ISwarm<P> swarm);
	}
}
