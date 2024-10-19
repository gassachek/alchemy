using UnityEngine;

[System.Serializable]
public class ItemData
{
    [SerializeField] private string _name;
    [SerializeField] private ItemType _type;
    [SerializeField] private FreshType _fresh;
    [SerializeField] private int _age;
    [SerializeField] private RareType _rare;

    public string Name => _name;
    public ItemType Type => _type;
    public FreshType Fresh => _fresh;
    public int Age => _age;
    public RareType Rare => _rare;
}

public enum ItemType {
    Ingredient,
    Raw,
    Potion
}

public enum FreshType {
    Rotten,
    Normal,
    New
}

public enum RareType {
    Simple,
    Rare,
    Uniquely
}
