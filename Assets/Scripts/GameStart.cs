using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStart: MonoBehaviour
    {
        private void Awake()
        {
            var inventoryModel = new InventoryModel();
            GameManager.Add(inventoryModel);
            GameManager.Add(Resources.Load<ItemDatabase>("ItemDatabase"));
            var ingredientManufactoreDB = Resources.Load<IngredientManufactoreDB>("IngredientManufactoreDB");
            GameManager.Add(ingredientManufactoreDB);
            GameManager.Add(Resources.Load<RecipeDB>("RecipeDB"));
            GameManager.Add(Resources.Load<PotionConfig>("PotionConfig"));
            IngredientsProcessor processor = new IngredientsProcessor(inventoryModel, ingredientManufactoreDB);
            GameManager.Add(processor);
        }
    }
}