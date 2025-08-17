using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stats : MonoBehaviour
{
    public float waterSupply;
    public float waterStorage;
    public float sunlight;
    public float nutrients;
    public float nutrientConsumption;
    
    public List<float> modifiers = new List<float>();
    // я думал сделать начальное колво ресурсов, зависящее от локации. А ивенты и прокачка будут + или - это значение в этом же файле
    // и насчет листа модификаторов не очень понял
    
    private void ExtractWater()
    {
        waterStorage += waterSupply *  Time.deltaTime;
    }
    
    private void Photosynthesis()
    {
        waterStorage -= Math.Min(waterSupply, sunlight) * Time.deltaTime;
        nutrients += Math.Min(waterSupply, sunlight) *  Time.deltaTime;
        if (waterSupply == 0)
        {
            nutrients += sunlight *  Time.deltaTime;
            waterStorage -= sunlight * Time.deltaTime;
        }
    }

    private void PlantMaintenance()
    {
        nutrients -=  nutrientConsumption * Time.deltaTime;
    }
    
    // for display
    public TMP_Text waterText;
    public TMP_Text nutrientsText;
    
    private void Update()
    {
        ExtractWater();
        Photosynthesis();
        PlantMaintenance();
        
        waterText.text = waterStorage.ToString("F");
        nutrientsText.text = nutrients.ToString("F");
    }
}