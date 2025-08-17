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
		State.WaterStorage += State.WaterSupply * Time.deltaTime;
	}

	public void ConsumeNutrients()
	{
		State.NutrientStorage -= State.NutrientConsumption * Time.deltaTime;
	}

	public void AccumulateNutrients()
	{
		//Math.Min to not go into negative
		State.NutrientStorage += Math.Min(State.WaterStorage, State.SunSupply) * Time.deltaTime;
		State.WaterStorage -= Math.Min(State.WaterStorage, State.SunSupply) * Time.deltaTime;
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

	private void Update()
	{
		AccumulateNutrients();
		ConsumeNutrients();
		AccumulateWater();
	}

	private void FixedUpdate()
	{
		ApplyModificators(Time.fixedDeltaTime);

		WaterStorage.text = State.WaterStorage.ToString("F");
		NutrientStorage.text = State.NutrientStorage.ToString("F");
	}
}