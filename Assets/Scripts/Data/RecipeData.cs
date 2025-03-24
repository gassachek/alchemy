using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeData
{
    [SerializeField] private List<string> _ingredients;
    [SerializeField] private string _potion;
    [SerializeField] private bool _unlocked;
    
    public List<string> Ingredients => _ingredients;
    public string Potion => _potion;
    public bool Unlocked => _unlocked;
}
