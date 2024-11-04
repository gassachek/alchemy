using System.Collections.Generic;
using UnityEditorInternal;
public class Inventory
{
    Dictionary<string, int> CountItems = new Dictionary<string, int>();


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
            return true;
        }

        return true;
    }

    public Dictionary<string, int> GetItems()
    {
        return CountItems;
    }
}
