using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class InventoryItem
{
    Dictionary<string, int> Ingredients = new Dictionary<string, int>();

    public void Add(string name, int count)
    {
        if (Ingredients.ContainsKey(name))
        {
            Ingredients[name] += count;
        }
        else
        {
            Ingredients.Add(name, count);
        }
    }

    public int Get(string name)
    {
        if (Ingredients.TryGetValue(name, out int count))
        {
            return count;
        }
        else
        {
            throw new KeyNotFoundException($"Ингредиент '{name}' отсутсвует");
        }
    }

    public bool Remove(string name, int count)
    {
        if (Ingredients.TryGetValue(name, out int countIngredient))
        {
            if (countIngredient > count)
            {
                Ingredients[name] = countIngredient - count;
                return true;
            }
            else if (countIngredient == count)
            {
                Ingredients.Remove(name);
                return true;
            }
        }

        return false;
    }
}
