public partial class UpgradeState
{
	public void AddRoot()
	{
		AvailableRoot.Add(new(5, "st1", "Steam Upgrade", "Just better"));
		AvailableRoot[0].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[0].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[0].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot.Add(new(5, "st2", "Steam Upgrade", "Just better"));
		AvailableRoot[1].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[1].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[1].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot.Add(new(5, "st3", "Steam Upgrade", "Just better"));
		AvailableRoot[2].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[2].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[2].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot.Add(new(5, "st4", "Steam Upgrade", "Just better"));
		AvailableRoot[3].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[3].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[3].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot.Add(new(5, "stS", "Steam Super", "Much better"));
		AvailableRoot[4].AddChange(BaseVariable.BaseWaterSupply, 5);
		AvailableRoot[4].AddChange(BaseVariable.BaseWaterStorage, 10);
		AvailableRoot[4].AddChange(BaseVariable.BaseNutrientStorage, 10);
		AvailableRoot[4].AddChange(ShareVariable.WaterSupply, 0.2f);
	}
}