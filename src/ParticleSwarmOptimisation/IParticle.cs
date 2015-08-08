namespace com.gee.ParticleSwarmOptimisation
{
	public interface IParticle
	{
		double X { get; }
		double XSpeed { get; }
		double Y { get; }
		double YSpeed { get; }
		double GetDistance(IParticle particle);

		IParticle Iterate(IEnvironment<IParticle> environment);
	}
}
