
// locations 
using UnityEngine;

public class Wasteland : Inhabitat
{
	public Wasteland()
	{
		Background = Resources.Load<Sprite>("Wasteland");
	}

	public override void SetVariables(GeneralState plantStats)
	{
		plantStats.WindStrength = 1.2f;
		plantStats.SunStrength = 1.5f;
		plantStats.RainStrength = 0.7f;
	}
}
