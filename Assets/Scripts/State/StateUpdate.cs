using System;

using TMPro;

using UnityEngine;

public class StateUpdate : MonoBehaviour
{
	public GeneralState State;

	public TMP_Text WaterStorage;
	public TMP_Text NutrientStorage;

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
		State.NutrientLevel += Math.Min(State.WaterLevel, State.SunSupply) * Time.deltaTime;
		State.NutrientLevel = Math.Min(State.NutrientStorage, State.NutrientLevel);
		State.WaterLevel -= Math.Min(State.WaterLevel, State.SunSupply) * Time.deltaTime;
	}

	public void ApplyModificators(float timePassed)
	{
		float waterSupplyModifier = 1f, sunSupplyModifier = 1f, nutrientSupplyModifier = 1f;
		float waterStorageModifier = 1f, nutrientStorageModifier = 1f;
		foreach(var modificator in State.Modificators)//scan through all modificators
		{
			switch(modificator.Variable)//determine variable and add up all multipliers
			{
				case ShareVariable.WaterSupply:
					waterSupplyModifier += modificator.Value;
					break;
				case ShareVariable.SunSupply:
					sunSupplyModifier += modificator.Value;
					break;
				case ShareVariable.NutrientConsumption:
					nutrientSupplyModifier += modificator.Value;
					break;
				case ShareVariable.NutrientStorage:
					nutrientStorageModifier += modificator.Value;
					break;
				case ShareVariable.WaterStorage:
					waterStorageModifier += modificator.Value;
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
		State.WaterSupply = State.BaseWaterSupply * waterSupplyModifier;
		State.SunSupply = State.BaseSunSupply * sunSupplyModifier;
		State.NutrientConsumption = State.BaseNutrientConsumption * nutrientSupplyModifier;
		State.NutrientStorage = State.BaseNutrientStorage * nutrientStorageModifier;
		State.WaterStorage = State.BaseWaterStorage * waterStorageModifier;
	}

	public void CheckLiveness()
	{
		if(State.WaterLevel / State.WaterStorage < 0.1f)
		{
			State.Alive = false;
			State.DeathCause = "Dehydration";
		}
		if(State.NutrientLevel < 0.1f)
		{
			State.Alive = false;
			State.DeathCause = "Starvation";
		}
		if(!State.Alive)
			Destroy(gameObject);
	}

	private void Update()
	{
		AccumulateNutrients();
		ConsumeNutrients();
		AccumulateWater();
		CheckLiveness();
	}

	private void Start()
	{
		State.SetInitial();
	}

	private void FixedUpdate()
	{
		ApplyModificators(Time.fixedDeltaTime);

		WaterStorage.text = State.WaterLevel.ToString("F") + "w";
		NutrientStorage.text = State.NutrientLevel.ToString("F") + "n";
	}
}