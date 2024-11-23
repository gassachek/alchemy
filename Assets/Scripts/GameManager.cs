using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Inventory inventory { get; private set; }
    public ItemDatabase itemDatabase { get; private set; }
    public IngredientManufactoreDB ingredientManufactoreDB{ get; private set; }
    public ModelRecipe modelRecipe{ get; private set; }

    private void Awake()
    {
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
        inventory = new Inventory();
        itemDatabase = Resources.Load<ItemDatabase>("ItemDatabase");
        ingredientManufactoreDB = Resources.Load<IngredientManufactoreDB>("IngredientManufactoreDB");
        modelRecipe = Resources.Load<ModelRecipe>("ModelRecipe");
    }
}

