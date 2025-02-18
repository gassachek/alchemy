using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class CustomInspectore: MonoBehaviour
{
    private InventoryModel _inventoryModel;
    private ItemDatabase _itemDatabase;
    void Start()
    {
        _inventoryModel = GameManager.Get<InventoryModel>();
        _itemDatabase = GameManager.Get<ItemDatabase>();
    }

    public void AddMaterials(ItemType type)
    {
        foreach (var itemData in _itemDatabase.GetItemAll())
        {
            if (itemData != null && itemData.Type == type)
            {
                int countItems = _inventoryModel.Get(itemData.Name); 
                _inventoryModel.Add(itemData.Name, countItems + 5);
            }
        }

    }
}