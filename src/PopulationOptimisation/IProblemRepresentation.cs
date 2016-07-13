namespace Gee.PopulationOptimisation
{
	public interface IProblemRepresentation<P> where P : IProblemRepresentation<P>, new()
	{
		P Clone();
	}
}
