using TMPro;

using UnityEngine;

public class EndStatsShower : MonoBehaviour
{
	public TMP_Text Textbox;
	public GeneralState State;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		string text = Textbox.text;
		text += $"\nCause of death:{State.DeathCause}\n";
		text += "Stats:\n";
		text += $"Root level - {State.RootPrimaryPhase}:{State.RootSecondaryPhase}\n";
		text += $"Stem level - {State.StemPrimaryPhase}:{State.StemSecondaryPhase}\n";
		text += $"Leaf level - {State.LeafPrimaryPhase}:{State.LeafSecondaryPhase}\n";
		text += $"Nutrient level - {State.NutrientLevel}/{State.NutrientStorage}\n";
		text += $"Water level - {State.WaterLevel}/{State.WaterStorage}\n";
		Textbox.text = text;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
