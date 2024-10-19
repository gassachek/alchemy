using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    public GameObject InventoryIconPrefab;
    public Transform Content;
    private List<InventorySlot> activeSlot = new List<InventorySlot>();

    private Inventory inventory;
    private ItemDatabase itemDatabase;

    void Start()
    {
        inventory = new Inventory();
        itemDatabase = Resources.Load<ItemDatabase>("ItemDatabase");
    }

    public void ShowItems(ItemType type)
    {
        foreach(var item in inventory.GetItems())
        {
            ItemData itemData = itemDatabase.GetItemByName(item.Key);
            if(itemData != null & itemData.Type == type)
            {
                CreateIventorySlot(itemData, item.Value);
            }
        }
    }

    public void CreateIventorySlot(ItemData itemData, int count)
    {
        GameObject newSlot = Instantiate(InventoryIconPrefab, Content);

    }
}
