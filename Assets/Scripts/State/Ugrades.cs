public partial class UpgradeState
{
    public void AddRoot()
    {
        AvailableRoot.Add(new(5, "st1", "Root Upgrade", "Just better"));
        AvailableRoot[0].AddChange(BaseVariable.BaseWaterSupply, 2);
        AvailableRoot[0].AddChange(BaseVariable.BaseNutrientStorage, 5);
        AvailableRoot[0].AddChange(BaseVariable.RootSecondaryPhase, 1);
        AvailableRoot.Add(new(5, "st2", "Root Upgrade", "Just better"));
        AvailableRoot[1].AddChange(BaseVariable.BaseWaterSupply, 2);
        AvailableRoot[1].AddChange(BaseVariable.BaseNutrientStorage, 5);
        AvailableRoot[1].AddChange(BaseVariable.RootSecondaryPhase, 1);
        AvailableRoot.Add(new(5, "st3", "Root Upgrade", "Just better"));
        AvailableRoot[2].AddChange(BaseVariable.BaseWaterSupply, 2);
        AvailableRoot[2].AddChange(BaseVariable.BaseNutrientStorage, 5);
        AvailableRoot[2].AddChange(BaseVariable.RootSecondaryPhase, 1);
        AvailableRoot.Add(new(5, "st4", "Root Upgrade", "Just better"));
        AvailableRoot[3].AddChange(BaseVariable.BaseWaterSupply, 2);
        AvailableRoot[3].AddChange(BaseVariable.BaseNutrientStorage, 5);
        AvailableRoot[3].AddChange(BaseVariable.RootSecondaryPhase, 1);
    }

    public void AddStem() //i have made a mistake and water stores in stem and leaves (actually it does not even stored, but for simplification process it does stores)
    {
        AvailableStem.Add(new(5, "sm1", "Stem Upgrade", "Just better"));
        AvailableStem[0].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[0].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[0].AddChange(BaseVariable.StemSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sm2", "Stem Upgrade", "Just better"));
        AvailableStem[1].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[1].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[1].AddChange(BaseVariable.StemSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sm3", "Stem Upgrade", "Just better"));
        AvailableStem[2].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[2].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[2].AddChange(BaseVariable.StemSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sm4", "Stem Upgrade", "Just better"));
        AvailableStem[3].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[3].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[3].AddChange(BaseVariable.StemSecondaryPhase, 1);
    }

    public void AddLeaves() //leaves also store water, so i add water storage here as well
    {
        AvailableStem.Add(new(5, "sl1", "Leaf Upgrade", "Just better"));
        AvailableStem[0].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[0].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[0].AddChange(BaseVariable.LeafSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sl2", "Leaf Upgrade", "Just better"));
        AvailableStem[1].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[1].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[1].AddChange(BaseVariable.LeafSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sl3", "Leaf Upgrade", "Just better"));
        AvailableStem[2].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[2].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[2].AddChange(BaseVariable.LeafSecondaryPhase, 1);

        AvailableStem.Add(new(5, "sl4", "Leaf Upgrade", "Just better"));
        AvailableStem[3].AddChange(BaseVariable.BaseSunSupply, 0.5f);
        AvailableRoot[3].AddChange(BaseVariable.BaseWaterStorage, 5);
        AvailableStem[3].AddChange(BaseVariable.LeafSecondaryPhase, 1);
    }
}