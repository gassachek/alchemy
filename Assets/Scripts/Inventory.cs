using System.Collections.Generic;
public class Inventory
{
    Dictionary<string, int> Materials = new Dictionary<string, int>();
    public void Add(string name, int count)
    {
        if (Materials.ContainsKey(name))
        {
            Materials[name] += count;
        }
        else
        {
            Materials.Add(name, count);
        }
    }
    public int Get(string name)
    {
        if (Materials.TryGetValue(name, out int count))
        {
            return count;
        }
        else
        {
            return 0;
        }
    }
    public bool Remove(string name, int count)
    {
        if (Materials.TryGetValue(name, out int countIngredient))
        {
            if (countIngredient > count)
            {
                Materials[name] = countIngredient - count;
                return true;
            }
            else if (countIngredient == count)
            {
                Materials.Remove(name);
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
