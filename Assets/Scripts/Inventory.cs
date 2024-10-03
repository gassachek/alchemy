using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Inventory
{
    Dictionary<string, Material> Materials = new Dictionary<string, Material>();
    public void Add(MaterialData materialData, int count)
    {
        string name = materialData.Name;
        if (Materials.ContainsKey(name))
        {
            Materials[name].AddMaterial(count);
        }
        else
        {
            Materials.Add(name, new Material(materialData, count));
        }
    }

    public int Get(string name)
    {
        if (Materials.TryGetValue(name, out Material material))
        {
            return material.MaterialCount;
        }
        else
        {
            throw new KeyNotFoundException($"Ингредиент '{name}' отсутсвует");
        }
    }

    public bool Remove(string name, int count)
    {
        if (Materials.TryGetValue(name, out Material material))
        {
            if(material.RemoveMaterial(count))
            {
                if (material.MaterialCount == 0)
                {
                    Materials.Remove(name);
                }
                return true;
            }
            else
            {
                throw new KeyNotFoundException("Недостаточно ингредиентов");
            }
        }
        return false;
    }
}

