using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class CustomInspectore: MonoBehaviour
{
    private Inventory _inventory;
    private ItemDatabase _itemDatabase;
    void Start()
    {
        _inventory = GameManager.Instance?.inventory;
        _itemDatabase = GameManager.Instance?.itemDatabase;
    }

    public void AddMaterials(ItemType type)
    {
        foreach (var itemData in _itemDatabase.GetItemAll())
        {
            if (itemData != null && itemData.Type == type)
            {
                int countItems = _inventory.Get(itemData.Name); 
                _inventory.Add(itemData.Name, countItems + 5);
            }
        }
        EventManager.OnInventoryChanged();
    }
}