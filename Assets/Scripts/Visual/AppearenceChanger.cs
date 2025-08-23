using UnityEngine;

public class AppearenceChanger : MonoBehaviour
{
	public Sprite R1_1;
	public Sprite R1_2;//Root, Primary Phase 1, Secondary Phase 2

	public SpriteRenderer Root;

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
			Debug.Log("Change");
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
				}
				break;
		}
	}
}