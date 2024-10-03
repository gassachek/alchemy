using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material
{
    public MaterialData MaterialData {get; private set;}
    public int MaterialCount {get; private set;}

    public Material(MaterialData material, int count)
    {
        MaterialData = material;
        MaterialCount = count;
    }

    public void AddMaterial(int count)
    {
        MaterialCount += count;
    }

    public bool RemoveMaterial(int count)
    {
        if (MaterialCount >= count)
        {
            MaterialCount -= count;
            return true;
        }
        return false;
        
    }
}
