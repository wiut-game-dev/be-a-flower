//declares event, which must have method, giving us outcome of it by taking all necessary data from the state

public abstract class Event
{
	public abstract Modificator GetOutcome(GeneralState state);
}