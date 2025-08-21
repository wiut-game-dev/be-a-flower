using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;


[CreateAssetMenu]
public partial class UpgradeState : ScriptableObject
{
	public List<Upgrade> AvailableStem;
	public List<Upgrade> AvailableLeaves;
	public List<Upgrade> AvailableRoot;
	public List<Upgrade> AvailableFlowers;

	public HashSet<string> Unlocked = new();

	public UpgradeState()
	{
		AvailableStem = new();
		AvailableLeaves = new();
		AvailableRoot = new();
		AvailableFlowers = new();
		AddStem();
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
		}
	}

	private void ApplyShareChange(GeneralState state, (ShareVariable variable, float value) mod)
	{
		state.Modificators.Add(new(mod.variable, mod.value));
	}

	public Upgrade Next(Aspect aspect)
	{
		try
		{
			return aspect switch
			{
				Aspect.Stem => AvailableStem[0],
				Aspect.Leaves => AvailableLeaves[0],
				Aspect.Root => AvailableRoot[0],
				Aspect.Flowers => AvailableFlowers[0],
				_ => null
			};
		}
		catch(ArgumentOutOfRangeException)
		{
			return null;
		}
	}

	public bool UpgradeNext(GeneralState state, Aspect aspect) => Upgrade(state, Next(aspect));

	private bool Upgrade(GeneralState state, Upgrade upg)
	{
		if(upg is null)
			return false;
		if(state.NutrientLevel < upg.Cost)
			return false;
		if(upg.RequiredUpgrades.Any(x => !Unlocked.Contains(x)))
			return false;
		if(upg.NotAllowedUpgrades.Any(x => Unlocked.Contains(x)))
			return false;
		state.NutrientLevel -= upg.Cost;
		Unlocked.Add(upg.Codename);
		AvailableStem.Remove(upg);
		foreach(var mod in upg.BaseChanges)
		{
			ApplyBaseChange(state, mod);
		}
		foreach(var mod in upg.ShareChanges)
		{
			ApplyShareChange(state, mod);
		}
		return true;
	}
}

public enum Aspect
{
	Stem,
	Leaves,
	Root,
	Flowers
}