
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
			},
			EventName="Strong wind",
			Kill=false,
			Message="Wind took one of your leaves."
		};

		BadOut = new Outcome()
		{
			Modificators = new List<Modificator>(),
			Penalties = new List<(BaseVariable variable, float value)>
			{
				(BaseVariable.LeafSecondaryPhase, -state.LeafSecondaryPhase/2),
				(BaseVariable.StemSecondaryPhase, -state.StemSecondaryPhase/2)
			},
			EventName="Strong wind",
			Kill=false,
			Message="You have lost a lot of your upper branches. Leaves and stem have been damaged."
		};

		TerribleOut = new Outcome()
		{
			Kill = true,
			EventName="Strong wind",
			Message="Wind has killed you."
		};

		TerribleUniqueOut = new Outcome()
		{
			Kill = true,
			EventName="Strong wind",
			Message="Wind has killed you, but in a terrible way."
		};

		int terrUniqRange = 10, terrRange = 30, badRange = 90;

		int roll = Random.Range(0, 101);

		roll += (state.StemPrimaryPhase * 5 - 5 + state.StemSecondaryPhase - 1) * 1 +
			  (state.RootPrimaryPhase * 5 - 5 + state.RootSecondaryPhase - 1) * 1 +
			  (state.LeafPrimaryPhase * 5 - 5 + state.LeafSecondaryPhase - 1) * (-2);

		roll = -1;

		if(roll < terrUniqRange)
			return TerribleUniqueOut;
		if(roll < terrRange)
			return TerribleOut;
		if(roll < badRange)
			return BadOut;
		return GoodOut;
	}
}