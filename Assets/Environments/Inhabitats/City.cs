public class City : Inhabitat
{
	public override void SetVariables(GeneralState plantStats)
	{
		plantStats.Modificators.Add(new(ShareVariable.WaterSupply, -0.5f));
		plantStats.Modificators.Add(new(ShareVariable.SunSupply, -0.5f));
		plantStats.SunStrength = 0.5f;
		plantStats.WindStrength = 0.7f;
		plantStats.RainStrength = 1.2f;
	}
}
