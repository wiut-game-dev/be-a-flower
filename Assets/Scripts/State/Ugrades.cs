public partial class UpgradeState
{
	public void AddRoot()
	{
		AvailableRoot.Add(new(5, "st1", "Root Upgrade", "Just better"));
		AvailableRoot[0].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[0].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[0].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot[0].AddChange(BaseVariable.RootSecondaryPhase, 1);
		AvailableRoot.Add(new(5, "st2", "Root Upgrade", "Just better"));
		AvailableRoot[1].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[1].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[1].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot[1].AddChange(BaseVariable.RootSecondaryPhase, 1);
		AvailableRoot.Add(new(5, "st3", "Root Upgrade", "Just better"));
		AvailableRoot[2].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[2].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[2].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot[2].AddChange(BaseVariable.RootSecondaryPhase, 1);
		AvailableRoot.Add(new(5, "st4", "Root Upgrade", "Just better"));
		AvailableRoot[3].AddChange(BaseVariable.BaseWaterSupply, 2);
		AvailableRoot[3].AddChange(BaseVariable.BaseWaterStorage, 5);
		AvailableRoot[3].AddChange(BaseVariable.BaseNutrientStorage, 5);
		AvailableRoot[3].AddChange(BaseVariable.RootSecondaryPhase, 1);
	}
}