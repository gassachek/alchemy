using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    void Start()
    {
        Inventory inventory= new Inventory();

        inventory.Add("grass", 5);
        inventory.Add("eyes", 2);
        inventory.Add("flower", 1);

        Debug.Log(inventory.Get("grass"));
        Debug.Log(inventory.Get("flower"));

        inventory.Remove("eyes", 1);
        inventory.Remove("flower", 1);
        Debug.Log(inventory.Get("eyes"));
        Debug.Log(inventory.Get("flower"));

        inventory.Remove("grass", 6);
        
    }

    void Update()
    {
        
    }
}

public class Inventory
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
            else
            {
                throw new KeyNotFoundException("Ошибка");
            }
        }

        return false;
    }
}
