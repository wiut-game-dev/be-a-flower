
using System.Collections.Generic;

using UnityEngine;

public class Wind : Event
{
	private Outcome GoodOut;
	private Outcome BadOut;
	private Outcome TerribleOut;
	private Outcome TerribleUniqueOut;

	public override Outcome GetOutcome(GeneralState state)
	{
		GoodOut = new Outcome()
		{
			Modificators = new List<Modificator>(),
			Penalties = new List<(BaseVariable variable, float value)>
			{
				(BaseVariable.LeafSecondaryPhase, -1)
			}
		};

		BadOut = new Outcome()
		{
			Modificators = new List<Modificator>(),
			Penalties = new List<(BaseVariable variable, float value)>
			{
				(BaseVariable.LeafSecondaryPhase, -state.LeafSecondaryPhase/2),
				(BaseVariable.StemSecondaryPhase, -state.StemSecondaryPhase/2)
			}
		};

		TerribleOut = new Outcome()
		{
			Kill = true
		};

		TerribleUniqueOut = new Outcome()
		{
			Kill = true
		};

		int terrUniqRange = 10, terrRange = 30, badRange = 90;

		int roll = Random.Range(0, 101);

		roll += (state.StemPrimaryPhase * 5 - 5 + state.StemSecondaryPhase - 1) * 1 +
			  (state.RootPrimaryPhase * 5 - 5 + state.RootSecondaryPhase - 1) * 1 +
			  (state.LeafPrimaryPhase * 5 - 5 + state.LeafSecondaryPhase - 1) * (-2);

		if(roll < terrUniqRange)
			return TerribleUniqueOut;
		if(roll < terrRange)
			return TerribleOut;
		if(roll < badRange)
			return BadOut;
		return GoodOut;
	}
}