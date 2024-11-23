using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeData
{
    [SerializeField] private List<string> _ingredients;
    [SerializeField] private string _potion;
    
    public List<string> Ingredients => _ingredients;
    public string Potion => _potion;
}
