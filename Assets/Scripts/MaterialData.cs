using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "Materials/ New Material")]
public class MaterialData: ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private MaterialType _type;
    [SerializeField] private FreshType _fresh;
    [SerializeField] private int _age;
    [SerializeField] private RareType _rare;

    public string Name => _name;
    public MaterialType Type => _type;
    public FreshType Fresh => _fresh;
    public int Age => _age;
    public RareType Rare => _rare;
}

public enum MaterialType {
    Ingredient,
    Raw
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
