using System.Collections.Generic;
using UnityEngine;

public class PresenterBoiler: MonoBehaviour
{
    List<string> recipe  = new List<string>();
    private Inventory _inventory = GameManager.Instance?.inventory;
    private ModelRecipe _modelRecipe = GameManager.Instance?.modelRecipe;

    public void Add(string name)
    {
        if (!recipe.Contains(name))
        {
            recipe.Add(name);
            _inventory.Remove(name, 1);
        }
        else
        {
            Debug.Log($"Элемент {name} уже есть в котле");
        }
    }
    
    public void Boiling(List<string> recipe)
    {
        string Potion = _modelRecipe.GetBoiledPotion(recipe);
        _inventory.Add(Potion, 1);
        recipe.Clear();
    }
}
