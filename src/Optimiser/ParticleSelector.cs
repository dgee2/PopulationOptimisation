using Gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gee.Optimiser
{
	public class ParticleSelector : Selector<OptimiserParticle>
	{
		public override Func<OptimiserParticle, bool> Where { get; set; }

		public override Func<OptimiserParticle, double> OrderBy { get; set; }
	}
}
