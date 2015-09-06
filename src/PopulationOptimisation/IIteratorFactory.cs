namespace com.gee.PopulationOptimisation
{
	public interface IIteratorFactory<P> where P : IProblemRepresentation<P>, new()
	{
		IIterator<P> GetIterator();
		IIteratorFactory<P> SubIterator { get; set; }
	}
}
