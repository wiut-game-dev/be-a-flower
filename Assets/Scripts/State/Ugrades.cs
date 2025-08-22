public partial class UpgradeState
{
	public void AddStem()
	{
		AvailableStem.Add(new(5, "st1", "Steam Upgrade", "Just better", false));
		AvailableStem[0].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableStem[0].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableStem[0].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableStem.Add(new(5, "st2", "Steam Upgrade", "Just better", false));
		AvailableStem[1].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableStem[1].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableStem[1].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableStem.Add(new(5, "st3", "Steam Upgrade", "Just better", false));
		AvailableStem[2].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableStem[2].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableStem[2].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableStem.Add(new(5, "st4", "Steam Upgrade", "Just better", false));

		AvailableStem[3].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableStem[3].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableStem[3].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableStem.Add(new(5, "stS", "Steam Super", "Much better", false));
		AvailableStem[4].AddChange(BaseVariable.BaseWaterSupply, 5);
		AvailableStem[4].AddChange(BaseVariable.BaseWaterStorage, 10);
		AvailableStem[4].AddChange(BaseVariable.BaseNutrientStorage, 10);
		AvailableStem[4].AddChange(ShareVariable.WaterSupply, 0.2f);
	}
}