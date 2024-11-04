using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField]private GameObject InventoryIconPrefab;
    [SerializeField]private Transform Content;
    private List<InventorySlot> _activeSlot = new List<InventorySlot>();

    private Inventory _inventory;
    private ItemDatabase _itemDatabase;

    void Start()
    {
        _inventory = GameManager.Instance.inventory;
        _itemDatabase = GameManager.Instance.itemDatabase;

        CreateItems();
    }

    public void CreateItems()
    {
        foreach(var itemData in _itemDatabase.GetItemAll())
        {
            if(itemData != null)
            {
                CreateInventorySlot(itemData, _inventory.Get(itemData.Name));
            }
        }
    }

    public void CreateInventorySlot(ItemData itemData, int count)
    {
        GameObject newSlot = Instantiate(InventoryIconPrefab, Content);
        InventorySlot inventorySlot= newSlot.GetComponent<InventorySlot>();
        inventorySlot.SetSlot(itemData.Name, count);
    }
}
