using System.Collections.Generic;

using UnityEngine;

//class which contains all variables, representing current state of the game
//class will be certainly extended in future
[CreateAssetMenu]
public class GeneralState : ScriptableObject
{
	public bool Alive;
	//storage and supply of water
	//base is how much plant itself gives, and then it is multiplied by modificators
	public float BaseWaterSupply = 1f;
	public float WaterSupply;
	public float BaseWaterStorage = 10f;
	public float WaterStorage;
	public float WaterLevel;

	//same thing with sun
	public float BaseSunSupply = 1f;
	public float SunSupply;

	//same with nutrients
	public float BaseNutrientStorage = 10f;
	public float NutrientStorage;
	public float NutrientLevel;
	public float BaseNutrientConsumption = 1f;
	public float NutrientConsumption;

	//these are used for events, simulating disasters
	public float SunStrength;
	public float WindStrength;
	public float RainStrength;

	//these will be (probably) used for appearance purposes
	public int LeafCount;
	public int FlowerCount;
	public int LeafPrimaryPhase;
	public int LeafSecondaryPhase;
	public int StemPrimaryPhase;
	public int StemSecondaryPhase;
	public int RootPrimaryPhase;
	public int RootSecondaryPhase;

	//this should represent chance of getting disease from pollution
	public float Pollution;

	public List<Modificator> Modificators = new();

	public void SetInitial()
	{
		Alive = true;
		BaseWaterSupply = 1f;
		BaseWaterStorage = 10f;
		BaseSunSupply = 0.5f;

		BaseNutrientStorage = 10f;
		NutrientLevel = 5f;
		BaseNutrientConsumption = 0.1f;

	}
}

