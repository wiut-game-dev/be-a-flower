using System.Collections.Generic;
using UnityEngine;

public class location : MonoBehaviour
{
    public stats plantStats;
    List<Environment> environments = new List<Environment>();
    
    private Environment PickLocation()
    {
        var index = Random.Range(0, environments.Count);
        return environments[index];
    }
    
    private void Start()
    {
        environments.Add(new Wasteland());
        environments.Add(new City());
        var newLocation = PickLocation();
        newLocation.SetVariables(plantStats);
    }
}



// locations 
public class Wasteland : Environment
{
    public override void SetVariables(stats plantStats)
    {
        plantStats.waterSupply = 1f;
        plantStats.sunlight = 1f;;
    }
}

public class City : Environment
{
    public override void SetVariables(stats plantStats)
    {
        plantStats.waterSupply = 0.5f;
        plantStats.sunlight = 0.5f;
    }
}

public abstract class Environment
{
    public abstract void SetVariables(stats plantStats);
}