namespace com.gee.PopulationOptimisation
{
	public interface IIteratorFactory<P> where P : IParticle<P>, new()
	{
		IIterator<P> GetIterator();
		IIteratorFactory<P> SubIterator { get; set; }
	}
}
