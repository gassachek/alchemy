using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Item/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<ItemData> _items;

    public ItemData GetItemByName(string name)
    {
        foreach (var item in _items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }
        return null;
    }

    public List<ItemData> GetItemAll()
    {
        return _items;
    }
}
