using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemData MaterialData {get; private set;}
    public int MaterialCount {get; private set;}

    public Item(ItemData material, int count)
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
