using System.Collections.Generic;
using MVP;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipePresenter : Presenter
{
    private List<string> recipe = new List<string>();
    private InventoryModel _inventoryModel = GameManager.Get<InventoryModel>();
    private RecipeDB _recipeDB = GameManager.Get<RecipeDB>();
    
    private bool _isActiveMap = true;

    public void GetRecipes()
    {
        foreach (var recipe in _recipeDB.GetItemAll())
        {
            if (recipe.Unlocked == true)
            {
                
            }
        }
    }

    public void ActivateMap(GameObject map)
    {
        _isActiveMap = !_isActiveMap;
        map.SetActive(_isActiveMap);
    }
}