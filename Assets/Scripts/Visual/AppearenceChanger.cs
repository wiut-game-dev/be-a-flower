using UnityEngine;

public class AppearenceChanger : MonoBehaviour
{
	public SpriteRenderer Root;
	public SpriteRenderer Stem;

	public VisualState CurrentVisual;
	public VisualState PreviousVisual;

	public GeneralState GeneralState;

	private void FixedUpdate()
	{
		CurrentVisual = (VisualState)GeneralState;
		if(CurrentVisual != PreviousVisual)
		{
			PreviousVisual = CurrentVisual;
			ChangeRoot();
			ChangeStem();
			Debug.Log("Change");
		}
	}

	private void ChangeStem()
	{
		Sprite spr;
		string sdf = $"Stem/S{CurrentVisual.StemPrimaryPhase}_{CurrentVisual.StemSecondaryPhase}";
		spr=Resources.Load<Sprite>(sdf);
		Stem.sprite = spr;
	}

	private void ChangeRoot()
	{
		Sprite spr;
		string fileName = $"Root/R{CurrentVisual.RootPrimaryPhase}_{CurrentVisual.RootSecondaryPhase}";
		spr = Resources.Load<Sprite>(fileName);
		Root.sprite = spr;
	}
}