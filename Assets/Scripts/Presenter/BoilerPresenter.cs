using System.Collections.Generic;
using MVP;
using UnityEngine;

public class BoilerPresenter: Presenter
{
    private List<string> recipe  = new List<string>();
    private InventoryModel _inventoryModel = GameManager.Get<InventoryModel>();
    private RecipeDB _recipeDB = GameManager.Get<RecipeDB>();

    public void Add(string name)
    {
        if (!recipe.Contains(name))
        {
            recipe.Add(name);
            _inventoryModel.Remove(name, 1);
            Debug.Log($"Элемент {name} добавлен в котел");
        }
        else
        {
            Debug.Log($"Элемент {name} уже есть в котле");
        }
    }
    
    public void Boiling()
    {
        if (recipe != null)
        {
            string Potion = _recipeDB.GetBoiledPotion(recipe);
            _inventoryModel.Add(Potion, 1);
            recipe.Clear();
        }
        else
        {
            Debug.LogError("В котле нет ингредиентов");
        }
    }
}
