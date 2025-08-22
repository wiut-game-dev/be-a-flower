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

	public int stemUpgradesPerNode = 2; // how many upgrades must be unlocked per node

	public HashSet<string> Unlocked = new();

	public UpgradeState()
	{
		//initializing collections
		AvailableStem = new();
		AvailableLeaves = new();
		AvailableRoot = new();
		AvailableFlowers = new();
		AddStem();//calling method to add all stem upgrades
	}

	private void ApplyBaseChange(GeneralState state, (BaseVariable variable, float value) mod)
	{

		int emptyNodeIndex = state.Nodes.IndexOf(NodeType.Empty); //for list filling


		switch (mod.variable)
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
			case BaseVariable.NodeFillWithLeaf: // method for leaf filling
				if (emptyNodeIndex != -1) // -1 means no empty node was found
				{
					state.Nodes[emptyNodeIndex] = NodeType.Leaf;
				}
				break;
			case BaseVariable.NodeFillWithFlower: // method for flower filling
				if (emptyNodeIndex != -1)
				{
					state.Nodes[emptyNodeIndex] = NodeType.Flower;
				}
				break;

		}
	}

	private void ApplyShareChange(GeneralState state, (ShareVariable variable, float value) mod)
	{
		state.Modificators.Add(new(mod.variable, mod.value));
	}

	public Upgrade Next(Aspect aspect)
	{
		//retrieve next available upgrade, according to aspect
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
			//if collection is empty, return null
			return null;
		}
	}

	//makes life easier. just give state and pick aspect to upgrade
	public bool UpgradeNext(GeneralState state, Aspect aspect) => Upgrade(state, Next(aspect));

	private bool Upgrade(GeneralState state, Upgrade upg)
	{
		//check if upgrade is not null and can be bought, then apply it to state
		if(upg is null)
			return false;
		if(state.NutrientLevel < upg.Cost)
			return false;
		if(upg.RequiredUpgrades.Any(x => !Unlocked.Contains(x)))
			return false;
		if(upg.NotAllowedUpgrades.Any(x => Unlocked.Contains(x)))
			return false;
		if (upg.ConsumesNodeSlot && state.Nodes.Count == 0)
			return false; //no node slots available
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

		if (state.StemSecondaryPhase > 0 && state.StemSecondaryPhase % stemUpgradesPerNode == 0) //add empty node slot
		{
			state.Nodes.Add(NodeType.Empty);
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