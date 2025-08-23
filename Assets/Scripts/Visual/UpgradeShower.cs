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
		Stem.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void ShowAvailableRoot()
	{
		Upgrade upg = upgradeState.Next(Aspect.Root);
		Root.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void ShowAvailableLeaf()
	{
		Upgrade upg = upgradeState.Next(Aspect.Leaves);
		Leaf.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void ShowAvailableFlower()
	{
		Upgrade upg = upgradeState.Next(Aspect.Flowers);
		Flower.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void UpgradeStem()
	{
		//try to upgrade stem
		if(upgradeState.UpgradeNext(generalState, Aspect.Stem))
		{
			//if yes, say so and update available upgrade
			ShowAvailableStem();
			Message.text = "Successful update";
		}
		else
		{
			//if no, say so
			Message.text = "Can not upgrade";
		}
	}

	public void UpgradeRoot()
	{
		//try to upgrade root
		if(upgradeState.UpgradeNext(generalState, Aspect.Root))
		{
			//if yes, say so and update available upgrade
			ShowAvailableRoot();
			Message.text = "Successful update";
		}
		else
		{
			//if no, say so
			Message.text = "Can not upgrade";
		}
	}

	public void UpgradeLeaf()
	{
		//try to upgrade leaf
		if(upgradeState.UpgradeNext(generalState, Aspect.Leaves))
		{
			//if yes, say so and update available upgrade
			ShowAvailableLeaf();
			Message.text = "Successful update";
		}
		else
		{
			//if no, say so
			Message.text = "Can not upgrade";
		}
	}

	public void UpgradeFlower()
	{
		//try to upgrade flower
		if(upgradeState.UpgradeNext(generalState, Aspect.Flowers))
		{
			//if yes, say so and update available upgrade
			ShowAvailableFlower();
			Message.text = "Successful update";
		}
		else
		{
			//if no, say so
			Message.text = "Can not upgrade";
		}
	}
}