using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField]private GameObject InventoryIconPrefab;
    [SerializeField]private Transform Content;
    private List<InventorySlot> _activeSlots = new List<InventorySlot>();

    private Inventory _inventory;
    private ItemDatabase _itemDatabase;

    void Start()
    {
        _inventory = GameManager.Instance.inventory;
        _itemDatabase = GameManager.Instance.itemDatabase;

        CreateItems(ItemType.Raw);
    }

    public void CreateItems(ItemType type)
    {
        ClearSlots();

        foreach(var itemData in _itemDatabase.GetItemAll())
        {
            if(itemData != null && itemData.Type == type)
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
        _activeSlots.Add(inventorySlot);
    }

    private void ClearSlots()
    {
        foreach (var slot in _activeSlots)
        {
            Destroy(slot.gameObject);
        }
        _activeSlots.Clear();
    }

    public void OnRawButton()
    {
        CreateItems(ItemType.Raw);
    }

    public void OnIngredientButton()
    {
        CreateItems(ItemType.Ingredient);
    }

    public void OnPotionButton()
    {
        CreateItems(ItemType.Potion);
    }
}
