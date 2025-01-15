using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionConfig", menuName = "Potion/Potion Config")]
public class PotionConfig : ScriptableObject
{
    [SerializeField] private List<PotionData> _potions;

    public PotionData GetPotionByName(string name)
    {
        foreach (var potion in _potions)
        {
            if (potion.Name == name)
            {
                return potion;
            }
        }
        return null;
    }

    public List<PotionData> GetItemAll()
    {
        return _potions;
    }
}