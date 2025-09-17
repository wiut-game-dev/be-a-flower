using System.Collections.Generic;

using UnityEngine;

public class EventPick : MonoBehaviour
{
	public float minDelay = 10f;
	public float maxDelay = 50f;
	public float delay;
	public float timer;

	public GeneralState state;

	public List<Event> events;

	private void SetDelay()
	{
		delay = Random.Range(minDelay, maxDelay);
	}

	private void Start()
	{
		SetDelay();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if(timer >= delay)
		{
			timer = 0;
			Event ev = events[Random.Range(0, events.Count)];
			Outcome outcome = ev.GetOutcome(state);
			if(outcome.Kill)
				state.Alive = false;
			else
			{
				state.Modificators.AddRange(outcome.Modificators);
				foreach(var pen in outcome.Penalties)
				{
					ApplyBaseChange(state, pen);
				}
			}
			SetDelay();
		}
	}

	private void ApplyBaseChange(GeneralState state, (BaseVariable variable, float value) mod)
	{
		switch(mod.variable)
		{
			case BaseVariable.BaseNutrientConsumption:
				state.BaseNutrientConsumption += mod.value;
				break;
			case BaseVariable.BaseWaterSupply:
				state.BaseWaterSupply += mod.value;
				break;
			case BaseVariable.BaseSunSupply:
				state.BaseSunSupply += mod.value;
				break;
			case BaseVariable.BaseWaterStorage:
				state.BaseWaterStorage += mod.value;
				break;
			case BaseVariable.BaseNutrientStorage:
				state.BaseNutrientStorage += mod.value;
				break;
			case BaseVariable.FlowerCount:
				state.FlowerCount += (int)mod.value;
				break;
			case BaseVariable.LeafCount:
				state.LeafCount += (int)mod.value;
				break;
			case BaseVariable.LeafPrimaryPhase:
				state.LeafPrimaryPhase += (int)mod.value;
				break;
			case BaseVariable.LeafSecondaryPhase:
				state.LeafSecondaryPhase += (int)mod.value;
				break;
			case BaseVariable.RootPrimaryPhase:
				state.RootPrimaryPhase += (int)mod.value;
				break;
			case BaseVariable.RootSecondaryPhase:
				state.RootSecondaryPhase += (int)mod.value;
				break;
			case BaseVariable.StemPrimaryPhase:
				state.StemPrimaryPhase += (int)mod.value;
				break;
			case BaseVariable.StemSecondaryPhase:
				state.StemSecondaryPhase += (int)mod.value;
				break;
			case BaseVariable.WaterLevel:
				state.WaterLevel += (int)mod.value;
				break;
			case BaseVariable.NutrientLevel:
				state.NutrientLevel += (int)mod.value;
				break;
		}
	}
}
