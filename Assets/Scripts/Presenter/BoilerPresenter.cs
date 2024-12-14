using System.Collections.Generic;
using UnityEngine;

public class BoilerPresenter: MonoBehaviour
{
    private List<string> recipe  = new List<string>();
    private Inventory _inventory = GameManager.Instance?.inventory;
    private RecipeDB _recipeDB = GameManager.Instance?.recipeDB;

    public void Add(string name)
    {
        if (!recipe.Contains(name))
        {
            recipe.Add(name);
            _inventory.Remove(name, 1);
            Debug.Log($"Элемент {name} добавлен в котел");
        }
        else
        {
            Debug.Log($"Элемент {name} уже есть в котле");
        }
    }
    
    public void Boiling()
    {
        if (recipe == null)
        {
            string Potion = _recipeDB.GetBoiledPotion(recipe);
            _inventory.Add(Potion, 1);
            recipe.Clear();
        }
        else
        {
            Debug.LogError("В котле нет ингредиентов");
        }
    }
}
