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
    private PotionConfig _potionConfig;
    
    [SerializeField] private ToggleGroup categoryToggleGroup;
    [SerializeField] private Toggle rawToggle;
    [SerializeField] private Toggle ingredientToggle;
    [SerializeField] private Toggle potionToggle;

    private ItemType _activetype;
    
    void Start()
    {
        _inventoryModel = GameManager.Get<InventoryModel>();
        _itemDatabase = GameManager.Get<ItemDatabase>();
        _potionConfig = GameManager.Get<PotionConfig>();
        
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
        // Создаём слоты для всех предметов из _itemDatabase
        foreach (var itemData in _itemDatabase.GetItemAll())
        {
            if (itemData != null)
            {
                CreateSlot(itemData.Name);
            }
        }

        // Создаём слоты для всех зелий из _potionConfig
        foreach (var potionData in _potionConfig.GetItemAll())
        {
            if (potionData != null)
            {
                CreateSlot(potionData.Name);
            }
        }
    }

    private void CreateSlot(string itemName)
    {
        var newItemContainer = Instantiate(ItemContainerPrefab, Content);
        var newSlot = Instantiate(InventoryIconPrefab, newItemContainer.transform);
        newSlot.SetSlot(itemName, _inventoryModel.Get(itemName));
        newItemContainer.name = $"Container_{itemName}";
        newItemContainer.gameObject.SetActive(false);
    }

    private void ShowSlots(ItemType type)
    {
        foreach (Transform child in Content)
        {
            GameObject itemContainer = child.gameObject;
            var slot = itemContainer.GetComponentInChildren<InventoryItem>();

            if (slot != null)
            {
                string itemName = slot.GetItemName().text;
                ItemData itemData = _itemDatabase.GetItemByName(itemName);
                PotionData potionData = _potionConfig.GetPotionByName(itemName);
                
                if (itemData != null && itemData.Type == type)
                {
                    itemContainer.SetActive(true);
                    slot.SetSlot(itemData.Name, _inventoryModel.Get(itemData.Name));
                }
                else if (potionData != null && type == ItemType.Potion)
                {
                    itemContainer.SetActive(true);
                    slot.SetSlot(potionData.Name, _inventoryModel.Get(potionData.Name));
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
