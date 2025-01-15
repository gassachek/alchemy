using UnityEngine;

[System.Serializable]
public class PotionData
{
    [SerializeField] private string _name;
    [SerializeField] private ItemType _type;
    [SerializeField] private string _description;
    [SerializeField] private RareType _rare;

    public string Name => _name;
    public ItemType Type => _type;
    public string Description => _description;
    public RareType Rare => _rare;
}
