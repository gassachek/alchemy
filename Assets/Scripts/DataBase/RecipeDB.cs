using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeDB", menuName = "Recipe/ Recipe DB")]
public class RecipeDB: ScriptableObject
{
    [SerializeField] private List<RecipeData> _recipeList;

    public string GetBoiledPotion(List<string> ingredients)
    {
        foreach (var recipe in _recipeList)
        {
            if (recipe.Ingredients == ingredients)
            {
                recipe.Unlocked = true;
                return recipe.Potion;
            }
        }
        return "Зашакаленное зелье";
    }

    public List<RecipeData> GetItemAll()
    {
        return _recipeList;
    }
}

