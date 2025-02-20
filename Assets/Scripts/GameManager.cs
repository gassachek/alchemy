using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public InventoryModel InventoryModel { get; private set; }
    public ItemDatabase itemDatabase { get; private set; }
    public IngredientManufactoreDB ingredientManufactoreDB{ get; private set; }
    public RecipeDB recipeDB{ get; private set; }
    public PotionConfig potionConfig { get; private set; }
    
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        else
        {
	        Destroy(gameObject);
	    }
	
    }

    private void InitializeManager()
    {
        InventoryModel = new InventoryModel();
        itemDatabase = Resources.Load<ItemDatabase>("ItemDatabase");
        ingredientManufactoreDB = Resources.Load<IngredientManufactoreDB>("IngredientManufactoreDB");
        recipeDB = Resources.Load<RecipeDB>("RecipeDB");
        potionConfig = Resources.Load<PotionConfig>("PotionConfig");
    }

    public float GetScaleFactor()
    {
        return canvas.scaleFactor;
    }
}

