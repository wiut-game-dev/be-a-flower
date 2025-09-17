
using System.Collections.Generic;

public class Outcome
{
	public bool Kill = false;
	public List<Modificator> Modificators;
	public List<(BaseVariable variable, float value)> Penalties;
}