using Gee.PopulationOptimisation;
using System;

namespace Gee.Optimiser
{
	public class ParticleSelector : Selector<OptimiserParticle>
	{
		public override Func<OptimiserParticle, bool> Where { get; set; }

		public override Func<OptimiserParticle, double> OrderBy { get; set; }
	}
}
