using System.Collections.Generic;

//class representing upgrade, contains some base variables to represent changes such as number of leafs or water supply, and some share variables as well to represent some percentage upgrade, which should be added as modificators

public class Upgrade
{
	public List<(BaseVariable variable, float value)> BaseChanges;
	public List<(ShareVariable variable, float value)> ShareChanges;
	public float Cost;
	public string Codename;
	public string Name;
	public string Description;

	public List<string> RequiredUpgrades;
	public List<string> NotAllowedUpgrades;

	public Upgrade(float cost, string codename, string name, string description)
	{
		Cost = cost;
		Codename = codename;
		Name = name;
		Description = description;
		BaseChanges = new();
		ShareChanges = new();
		RequiredUpgrades = new();
		NotAllowedUpgrades = new();
	}

	public void AddChange(BaseVariable variable, float value) => BaseChanges.Add((variable, value));

	public void AddChange(ShareVariable variable, float value) => ShareChanges.Add((variable, value));
}