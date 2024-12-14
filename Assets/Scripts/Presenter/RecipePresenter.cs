using System.Collections.Generic;
using UnityEngine;

public class PrecipePresenter : MonoBehaviour
{
    private List<string> recipe = new List<string>();
    private Inventory _inventory = GameManager.Instance?.inventory;
    private RecipeDB _recipeDB = GameManager.Instance?.recipeDB;

    public void GetRecipes()
    {
        foreach (var recipe in _recipeDB.GetItemAll())
        {
            if (recipe.Unlocked == true)
            {
                
            }
        }
    }
}