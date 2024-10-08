using UnityEngine;

[System.Serializable]
public class IngredientManufactoreItem
{
    [SerializeField] private string _raw;
    [SerializeField] private string _ingredient;
    [SerializeField] private Tool _toolType;
    [SerializeField] private int _count;

    public string Raw => _raw;
    public string Ingredient => _ingredient;
    public Tool ToolType => _toolType;
    public int Count => _count;
}

public enum Tool {
    Grater,
    Mortar
}
