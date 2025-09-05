using System.Collections.Generic;

using UnityEngine;

public class LocationPick : MonoBehaviour
{
	public SpriteRenderer Background;
	public GeneralState plantStats;
	List<Inhabitat> environments = new List<Inhabitat>();

	private Inhabitat PickLocation()
	{
		var index = Random.Range(0, environments.Count);
		return environments[index];
	}

	private void ApplyLocation(Inhabitat inh)
	{
		inh.SetVariables(plantStats);
		Background.sprite = inh.Background;
	}

	private void Start()
	{
		environments.Add(new Wasteland());
		environments.Add(new City());
		var newLocation = PickLocation();
		ApplyLocation(newLocation);
	}
}
