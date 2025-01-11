using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField] private InventoryItem InventoryIconPrefab;
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject ItemContainerPrefab;

    private InventoryModel _inventoryModel;
    private ItemDatabase _itemDatabase;
    
    [SerializeField] private ToggleGroup categoryToggleGroup;
    [SerializeField] private Toggle rawToggle;
    [SerializeField] private Toggle ingredientToggle;
    [SerializeField] private Toggle potionToggle;

    private ItemType _activetype;
    
    void Start()
    {
        _inventoryModel = GameManager.Instance?.InventoryModel;
        _itemDatabase = GameManager.Instance?.itemDatabase;
        
        CreateItems();

        rawToggle.onValueChanged.AddListener(RawToggleChanged);
        ingredientToggle.onValueChanged.AddListener(IngredientToggleChanged);
        potionToggle.onValueChanged.AddListener(PotionToggleChanged);

        _inventoryModel.InventoryChanged += OnInventoryModelChanged;
    }

    private void RawToggleChanged(bool isOn)
    {
        OnToggleChanged(isOn, ItemType.Raw);
    }

    private void IngredientToggleChanged(bool isOn)
    {
        OnToggleChanged(isOn, ItemType.Ingredient);
    }

    private void PotionToggleChanged(bool isOn)
    {
        OnToggleChanged(isOn, ItemType.Potion);
    }

    private void OnToggleChanged(bool isOn, ItemType type)
    {
        if(isOn)
        {
            ShowSlots(type);
            _activetype = type;
        }
    }

    private void OnDestroy()
    {
        _inventoryModel.InventoryChanged -= OnInventoryModelChanged;
        rawToggle.onValueChanged.RemoveListener(RawToggleChanged);
        ingredientToggle.onValueChanged.RemoveListener(IngredientToggleChanged);
        potionToggle.onValueChanged.RemoveListener(PotionToggleChanged);
    }

    public void CreateItems()
    {
        foreach(var itemData in _itemDatabase.GetItemAll())
        {
            if(itemData != null)
            {
                var newItemContainer = Instantiate(ItemContainerPrefab, Content);
                var newSlot = Instantiate(InventoryIconPrefab, newItemContainer.transform);
                newSlot.SetSlot(itemData.Name, _inventoryModel.Get(itemData.Name));
                newItemContainer.name = $"Container_{itemData.Name}";
                newItemContainer.gameObject.SetActive(false);
            }
        }
    }

    private void ShowSlots(ItemType type)
    {
        foreach (Transform child in Content)
        {
            GameObject itemContainer = child.gameObject;

            // Получаем слот предмета внутри контейнера
            var slot = itemContainer.GetComponentInChildren<InventoryItem>();
            if (slot != null)
            {
                string itemName = slot.GetItemName().text;
                ItemData itemData = _itemDatabase.GetItemByName(itemName);
                
                if (itemData != null && itemData.Type == type)
                {
                    itemContainer.SetActive(true);
                    slot.SetSlot(itemData.Name, _inventoryModel.Get(itemData.Name));
                }
                else
                {
                    itemContainer.SetActive(false);
                }
            }
        }
    }

    private void OnInventoryModelChanged()
    {
        Debug.Log("Вызов метода OnInventoryChanged");
        ShowSlots(_activetype);
    }
}
