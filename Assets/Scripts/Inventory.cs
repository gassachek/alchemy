using System.Collections.Generic;
public class Inventory
{
    Dictionary<string, int> Item = new Dictionary<string, int>();
    public void Add(string name, int count)
    {
        if (Item.ContainsKey(name))
        {
            Item[name] += count;
        }
        else
        {
            Item.Add(name, count);
        }
    }
    public int Get(string name)
    {
        if (Item.TryGetValue(name, out int count))
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
        if (Item.TryGetValue(name, out int countIngredient))
        {
            if (countIngredient > count)
            {
                Item[name] = countIngredient - count;
                return true;
            }
            else if (countIngredient == count)
            {
                Item.Remove(name);
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
