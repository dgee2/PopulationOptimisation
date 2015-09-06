using com.gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimiser
{
	public class ParticleSelector : Selector<OptimiserParticle>
	{
		public override Func<OptimiserParticle, bool> Where { get; set; }

		public override Func<OptimiserParticle, double> OrderBy { get; set; }
	}
}
