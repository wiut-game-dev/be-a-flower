using UnityEngine;

public class AppearenceChanger : MonoBehaviour
{
	public Sprite R1_1;
	public Sprite R1_2;//Root, Primary Phase 1, Secondary Phase 2
	public Sprite R1_3;
	public Sprite R1_4;
	public Sprite R1_5;

	public Sprite S1_1;
	public Sprite S1_2;
	public Sprite S1_3;
	public Sprite S1_4;
	public Sprite S1_5;

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
		switch(CurrentVisual.StemPrimaryPhase)
		{
			case 1:
				switch(CurrentVisual.StemSecondaryPhase)
				{
					case 1:
						Stem.sprite = S1_1;
						break;
					case 2:
						Stem.sprite = S1_2;
						break;
					case 3:
						Stem.sprite = S1_3;
						break;
					case 4:
						Stem.sprite = S1_4;
						break;
					case 5:
						Stem.sprite = S1_5;
						break;
				}
				break;
		}
	}

	private void ChangeRoot()
	{
		switch(CurrentVisual.RootPrimaryPhase)
		{
			case 1:
				switch(CurrentVisual.RootSecondaryPhase)
				{
					case 1:
						Root.sprite = R1_1;
						break;
					case 2:
						Root.sprite = R1_2;
						break;
					case 3:
						Root.sprite = R1_3;
						break;
					case 4:
						Root.sprite = R1_4;
						break;
					case 5:
						Root.sprite = R1_5;
						break;
				}
				break;
		}
	}
}