using com.gee.PopulationOptimisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimiser
{
	public class ParticleSelector : ISelector<OptimiserParticle>
	{
		public Func<IEnumerable<double>, double> Function { get; set; }
        public IEnumerable<OptimiserParticle> SelectParticles(IEnumerable<OptimiserParticle> population)
		{
			return population.OrderBy(particle => particle.Quality);
		}
	}
}
