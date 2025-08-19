using System;

using TMPro;

using UnityEngine;

public class StateUpdate : MonoBehaviour
{
	public GeneralState State;

	public TextMeshPro WaterStorage;
	public TextMeshPro NutrientStorage;

	public void AccumulateWater()
	{
		State.WaterLevel += State.WaterSupply * Time.deltaTime;
		State.WaterLevel = Math.Min(State.WaterStorage, State.WaterLevel);
	}

	public void ConsumeNutrients()
	{
		State.NutrientLevel -= State.NutrientConsumption * Time.deltaTime;
	}

	public void AccumulateNutrients()
	{
		//Math.Min to not go into negative
		State.NutrientLevel += Math.Min(State.WaterStorage, State.SunSupply) * Time.deltaTime;
		State.NutrientLevel = Math.Min(State.NutrientStorage, State.NutrientLevel);
		State.WaterLevel -= Math.Min(State.WaterStorage, State.SunSupply) * Time.deltaTime;
	}

	public void ApplyModificators(float timePassed)
	{
		float waterModifier = 1f, sunModifier = 1f, nutrientModifier = 1f;
		foreach(var modificator in State.Modificators)//scan through all modificators
		{
			switch(modificator.Variable)//determine variable and add up all multipliers
			{
				case ShareVariable.WaterSupply:
					waterModifier += modificator.Value;
					break;
				case ShareVariable.SunSupply:
					sunModifier += modificator.Value;
					break;
				case ShareVariable.NutrientConsumption:
					nutrientModifier += modificator.Value;
					break;
			}
			if(modificator.Duration is not null)//decrease duration
			{
				modificator.Duration -= timePassed;
				if(modificator.Duration <= 0)
				{
					State.Modificators.Remove(modificator);
				}
			}
		}
		//apply summed multipliers
		State.WaterSupply = State.BaseWaterSupply * waterModifier;
		State.SunSupply = State.BaseSunSupply * sunModifier;
		State.NutrientConsumption = State.BaseNutrientConsumption * nutrientModifier;
	}

	public void CheckWater()
	{
		if(State.WaterLevel / State.WaterStorage < 0.1f)
			State.Alive = false;
	}

	private void Update()
	{
		AccumulateNutrients();
		ConsumeNutrients();
		AccumulateWater();
		CheckWater();
	}

	private void FixedUpdate()
	{
		ApplyModificators(Time.fixedDeltaTime);

		WaterStorage.text = State.WaterStorage.ToString("F");
		NutrientStorage.text = State.NutrientStorage.ToString("F");
	}
}