using System.Collections.Generic;
public class Inventory
{
    Dictionary<string, int> Items = new Dictionary<string, int>();
    public void Add(string name, int count)
    {
        if (Items.ContainsKey(name))
        {
            Items[name] += count;
        }
        else
        {
            Items.Add(name, count);
        }
    }
    public int Get(string name)
    {
        if (Items.TryGetValue(name, out int count))
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
        if (Items.TryGetValue(name, out int countIngredient))
        {
            if (countIngredient > count)
            {
                Items[name] = countIngredient - count;
                return true;
            }
            else if (countIngredient == count)
            {
                Items.Remove(name);
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Dictionary<string, int> GetItems()
    {
        return Items;
    }
}
