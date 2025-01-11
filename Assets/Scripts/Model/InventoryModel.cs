using System;
using System.Collections.Generic;
using MVP;
using UnityEditorInternal;
public class InventoryModel: Model
{
    Dictionary<string, int> CountItems = new Dictionary<string, int>();

    public event Action InventoryChanged;

    public void OnInventoryChanged()
    {
        InventoryChanged?.Invoke();
    }

    public void Add(string name, int count)
    {
        if (CountItems.ContainsKey(name))
        {
            CountItems[name] += count;
        }
        else
        {
            CountItems.Add(name, count);
        }
        InventoryChanged?.Invoke();
    }
    public int Get(string name)
    {
        if (CountItems.TryGetValue(name, out int count))
        {
            return count;
        }

        return 0;

    }
    public bool Remove(string name, int count)
    {
        int countIngredient;
        if (!CountItems.TryGetValue(name, out countIngredient))
        {
            return false;
        }


        if (countIngredient < count)
        {
            return false;
        }

        CountItems[name] = countIngredient - count;

        if (countIngredient == count)
        {
            CountItems.Remove(name);
            InventoryChanged?.Invoke();
            return true;
        }
        
        InventoryChanged?.Invoke();
        return true;
        
    }

    public Dictionary<string, int> GetItems()
    {
        return CountItems;
    }
}
