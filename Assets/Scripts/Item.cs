using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: ScriptableObject
{
    public ItemData ItemData {get; private set;}
    public int ItemCount {get; private set;}

    public void Initialize(ItemData item, int count)
    {
        ItemData = item;
        ItemCount = count;
    }

    public void AddItem(int count)
    {
        ItemCount += count;
    }

    public bool RemoveItem(int count)
    {
        if (ItemCount >= count)
        {
            ItemCount -= count;
            return true;
        }
        return false;
        
    }
}
