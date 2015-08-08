using System;

namespace com.gee.ParticleSwarmOptimisation
{
	public abstract class Particle : IParticle
	{

		public double X { get; set; }

		public double XSpeed { get; set; }

		public double Y { get; set; }

		public double YSpeed { get; set; }

		public double GetDistance(IParticle particle)
		{
			return Math.Sqrt(Math.Pow(particle.X - X, 2) + Math.Pow(particle.Y - Y, 2));
		}

		public abstract IParticle Iterate(IEnvironment<IParticle> environment);
	}
}
