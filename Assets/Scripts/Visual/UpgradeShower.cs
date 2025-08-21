using TMPro;

using UnityEngine;

public class UpgradeShower : MonoBehaviour
{
	public TMP_Text Stem;
	public TMP_Text Message;

	public UpgradeState upgradeState;
	public GeneralState generalState;

	private void Start()
	{
		//firstly, show all possible upgrades of aspects
		ShowAvailableStem();
	}

	private void Update()
	{
		//when according key is pressed, upgrade aspect
		if(Input.GetKeyUp(KeyCode.S))
		{
			Debug.Log("S up");//for debug purposes
			UpgradeStem();
		}
	}

	public void ShowAvailableStem()
	{
		//retrieve next available stem upgrade and show it on textbox
		Upgrade upg = upgradeState.Next(Aspect.Stem);
		Stem.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
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
}