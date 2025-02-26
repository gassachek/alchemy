using System.Collections.Generic;
using MVP;
using UnityEngine;

public class BoilerPresenter: Presenter
{
    private static List<string> recipe = new List<string>();
    private InventoryModel _inventoryModel = GameManager.Get<InventoryModel>();
    private RecipeDB _recipeDB = GameManager.Get<RecipeDB>();

    public void Add(string name)
    {
        if (!recipe.Contains(name))
        {
            recipe.Add(name);
            _inventoryModel.Remove(name, 1);
            Debug.Log($"Элемент {name} добавлен в котел");
            Debug.Log($"Ингредиентов в котле: {recipe.Count} ");
        }
        else
        {
            Debug.Log($"Элемент {name} уже есть в котле");
        }
    }
    
    public void Boiling()
    {
        if (recipe.Count < 2)
        {
            Debug.LogError("Недостаточно ингредиентов для варки!");
            return;
        }

        Debug.Log($"{recipe[0]} {recipe[1]}");

        string potion = _recipeDB.GetBoiledPotion(new List<string>(recipe));
        Debug.Log($"Попытка сварить зелье {potion}");

        if (!string.IsNullOrEmpty(potion))
        {
            _inventoryModel.Add(potion, 1);
            Debug.Log("Вы сварили зелье!");
        }
        else
        {
            Debug.LogError("Рецепт не найден!");
        }

        recipe.Clear();
    }

}
