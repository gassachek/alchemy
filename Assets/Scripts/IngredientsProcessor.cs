using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsProcessor
{
    private Inventory _inventory;
    private IngredientManufactoreDB _ingredientManufactoreDB;

    public IngredientsProcessor(Inventory inventory,  IngredientManufactoreDB ingredientManufactoreDB)
    {
        _inventory = inventory;
        _ingredientManufactoreDB = ingredientManufactoreDB;
    }

    public void Process(string raw, Tool toolType)
    {
        string ingr;
        bool Ingredient = _ingredientManufactoreDB.TryGetByIngredientManufactoreItem(raw, toolType, out ingr);

        if (!Ingredient)
        {
            Debug.LogWarning($"Невозможно применить {toolType} к {raw}");
            return;
        }

        if (_inventory.Get(raw) <= 0)
        {
            Debug.LogWarning($"Нет предмета {raw} в инвентаре!");
            return;
        }

        if (_inventory.Get(raw) > 0 && Ingredient)
        {
            _inventory.Remove(raw, 1);
            _inventory.Add(ingr, 1);
            Debug.Log($"{toolType} успешно применён к {raw}, создано {ingr}");
        }

    }
}
