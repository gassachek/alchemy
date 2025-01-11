using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsProcessor
{
    private InventoryModel _inventoryModel;
    private IngredientManufactoreDB _ingredientManufactoreDB;

    public IngredientsProcessor(InventoryModel inventoryModel,  IngredientManufactoreDB ingredientManufactoreDB)
    {
        _inventoryModel = inventoryModel;
        _ingredientManufactoreDB = ingredientManufactoreDB;
    }

    public void Process(string raw, Tool toolType)
    {
        string ingr;
        bool Ingredient = _ingredientManufactoreDB.TryGetByIngredientManufactoreItem(raw, toolType, out ingr);

        Debug.Log($"Количество {raw} в инветаре {_inventoryModel.Get(raw)}, {Ingredient}");

        if (!Ingredient)
        {
            Debug.LogWarning($"Невозможно применить {toolType} к {raw}");
            return;
        }

        if (_inventoryModel.Get(raw) <= 0)
        {
            Debug.LogWarning($"Нет предмета {raw} в инвентаре!");
            return;
        }

        if (_inventoryModel.Get(raw) > 0 && Ingredient)
        {
            _inventoryModel.Remove(raw, 1);
            _inventoryModel.Add(ingr, 1);
            Debug.Log($"{toolType} успешно применён к {raw}, создано {ingr}");
        }

        
    }
}
