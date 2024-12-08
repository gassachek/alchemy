using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientManufactoreDB", menuName = "Manufactoring/ IngredientManufactore")]
public class IngredientManufactoreDB: ScriptableObject
{
    [SerializeField] private List<IngredientManufactoreItem> _manufactoring;

    public bool TryGetByIngredientManufactoreItem(string id, Tool toolType, out string ingr)
    {
        foreach (var item in _manufactoring)
        {
            if(item.Raw == id && item.ToolType == toolType)
            {
                ingr = item.Ingredient;
                return true;
            }
        }
        ingr = null;
        return false;
    }
}
