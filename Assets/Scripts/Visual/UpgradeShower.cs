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
		ShowAvailableStem();
	}

	private void Update()
	{
		if(Input.GetKeyUp(KeyCode.S))
		{
			Debug.Log("S up");
			BuyStem();
		}
	}

	public void ShowAvailableStem()
	{
		Upgrade upg = upgradeState.Next(Aspect.Stem);
		Stem.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void BuyStem()
	{
		if(upgradeState.UpgradeNext(generalState, Aspect.Stem))
		{
			ShowAvailableStem();
			Message.text = "Successful update";
		}
		else
		{
			Message.text = "Can not upgrade";
		}
	}
}