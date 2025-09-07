using System;

using TMPro;

using UnityEngine;

public class UpgradeShower : MonoBehaviour
{
	public TMP_Text Stem;
	public TMP_Text Root;
	public TMP_Text Leaf;
	public TMP_Text Flower;
	public TMP_Text Message;

	public UpgradeState upgradeState;
	public GeneralState generalState;

	public DateTime MessageBoxModified;
	public bool MessageBoxNotEmpty => Message.text != string.Empty;

	private void Start()
	{
		//firstly, show all possible upgrades of aspects
		ShowAvailableStem();
		ShowAvailableFlower();
		ShowAvailableRoot();
		ShowAvailableLeaf();
	}

	private void Update()
	{
		if(DateTime.Now - MessageBoxModified > TimeSpan.FromSeconds(3) && Message.text != "")
		{
			Debug.Log($"Message box from {MessageBoxModified} cleared at {DateTime.Now}");
			Message.text = string.Empty;
		}
		//when according key is pressed, upgrade aspect
		if(Input.GetKeyUp(KeyCode.S))
		{
			Debug.Log("S up");//for debug purposes
			UpgradeStem();
		}
		else if(Input.GetKeyUp(KeyCode.R))
		{
			Debug.Log("R up");//for debug purposes
			UpgradeRoot();
		}
		else if(Input.GetKeyUp(KeyCode.L))
		{
			Debug.Log("L up");//for debug purposes
			UpgradeLeaf();
		}
		else if(Input.GetKeyUp(KeyCode.F))
		{
			Debug.Log("F up");//for debug purposes
			UpgradeFlower();
		}
	}

	public void ShowAvailableStem()
	{
		//retrieve next available stem upgrade and show it on textbox
		Upgrade upg = upgradeState.Next(Aspect.Stem);
		if(upg is not null)
			Stem.text = $"{upg.Cost}n|{upg.Name} - {upg.Description}";
		else
			Stem.text = "No upgrades avaialable";
	}

	public void ShowAvailableRoot()
	{
		Upgrade upg = upgradeState.Next(Aspect.Root);
		if(upg is not null)
			Root.text = $"{upg.Cost}n|{upg.Name} - {upg.Description}";
		else
			Root.text = "No upgrades avaialable";
	}

	public void ShowAvailableLeaf()
	{
		Upgrade upg = upgradeState.Next(Aspect.Leaves);
		if(upg is not null)
			Leaf.text = $"{upg.Cost}n|{upg.Name} - {upg.Description}";
		else
			Leaf.text = "No upgrades avaialable";
	}

	public void ShowAvailableFlower()
	{
		Upgrade upg = upgradeState.Next(Aspect.Flowers);
		if(upg is not null)
			Flower.text = $"{upg.Cost}n|{upg.Name} - {upg.Description}";
		else
			Flower.text = "No upgrades avaialable";
	}

	public void ShowOutcome(bool outcome)
	{
		if(outcome)
		{
			Message.text = "Successful update";
			MessageBoxModified = DateTime.Now;
		}
		else
		{
			Message.text = "Can not upgrade";
			MessageBoxModified = DateTime.Now;
		}
	}

	public void UpgradeStem()
	{
		bool canUpgrade = upgradeState.UpgradeNext(generalState, Aspect.Stem);
		if(canUpgrade)
			ShowAvailableStem();
		ShowOutcome(canUpgrade);
	}

	public void UpgradeRoot()
	{
		bool canUpgrade = upgradeState.UpgradeNext(generalState, Aspect.Root);
		if(canUpgrade)
			ShowAvailableRoot();
		ShowOutcome(canUpgrade);
	}

	public void UpgradeLeaf()
	{
		bool canUpgrade = upgradeState.UpgradeNext(generalState, Aspect.Leaves);
		if(canUpgrade)
			ShowAvailableLeaf();
		ShowOutcome(canUpgrade);
	}

	public void UpgradeFlower()
	{
		bool canUpgrade = upgradeState.UpgradeNext(generalState, Aspect.Flowers);
		if(canUpgrade)
			ShowAvailableFlower();
		ShowOutcome(canUpgrade);
	}
}