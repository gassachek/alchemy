using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour 
{
    [SerializeField]private GameObject InventoryIconPrefab;
    [SerializeField]private Transform Content;
    private Dictionary<ItemType, List<InventorySlot>> _activeSlots = new Dictionary<ItemType, List<InventorySlot>>();

    private Inventory _inventory;
    private ItemDatabase _itemDatabase;
    
    [SerializeField] private ToggleGroup categoryToggleGroup;
    [SerializeField] private Toggle rawToggle;
    [SerializeField] private Toggle ingredientToggle;
    [SerializeField] private Toggle potionToggle;
    


    void Start()
    {
        _inventory = GameManager.Instance?.inventory;
        _itemDatabase = GameManager.Instance?.itemDatabase;
        
        Reboot();

        EventManager.InventoryChanged += OnInventoryChanged;
    }

    private void Reboot()
    {
        CreateItems();

        rawToggle?.onValueChanged.AddListener(isOn => { if (isOn) ShowSlots(ItemType.Raw); });
        ingredientToggle?.onValueChanged.AddListener(isOn => { if (isOn) ShowSlots(ItemType.Ingredient); });
        potionToggle?.onValueChanged.AddListener(isOn => { if (isOn) ShowSlots(ItemType.Potion); });
    }

    private void OnDestroy()
    {
        EventManager.InventoryChanged -= OnInventoryChanged;
    }

    public void CreateItems()
    {
        foreach(var itemData in _itemDatabase.GetItemAll())
        {
            if(itemData != null)
            {
                GameObject newSlot = Instantiate(InventoryIconPrefab, Content);
                InventorySlot inventorySlot= newSlot.GetComponent<InventorySlot>();
                inventorySlot.SetSlot(itemData.Name, _inventory.Get(itemData.Name));
                newSlot.SetActive(false);

                if(!_activeSlots.ContainsKey(itemData.Type))
                {
                    _activeSlots[itemData.Type] = new List<InventorySlot>();
                }
                _activeSlots[itemData.Type].Add(inventorySlot);
            }

        }
    }
    private void ShowSlots(ItemType type)
    {
        foreach (var slotList in _activeSlots.Values)
        {
            foreach(var slot in slotList)
            {
                slot.gameObject.SetActive(false);
            }
        }
        
        if(_activeSlots.ContainsKey(type))
        {
            foreach(var slot in _activeSlots[type])
            {
                slot.gameObject.SetActive(true);
            }
        }
    }

    private void OnInventoryChanged()
    {
        Debug.Log("Вызов метода OnInventoryChanged");
        foreach (var slotList in _activeSlots.Values)
        {
            foreach(var slot in slotList)
            {
                Destroy(slot.gameObject);
            }
        }
        _activeSlots.Clear();

        Reboot();
    }
}
