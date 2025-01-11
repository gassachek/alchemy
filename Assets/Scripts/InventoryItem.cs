using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    [SerializeField]private Image _icon;
    [SerializeField]private TMP_Text _itemName;
    [SerializeField]private TMP_Text _itemCount;
    [SerializeField] private Button _button;
    

    // Sprite itemIcon, 
    public void SetSlot(string name, int count)
    {
        // icon.sprite = itemIcon;
        _itemName.text = name;
        _itemCount.text = count.ToString();
    }

    public TMP_Text GetItemName()
    {
        return _itemName;
    }
    void Start()
    {
        _button.onClick.AddListener(OnSlotClicked);
    }

    private void OnSlotClicked()
    {
        // ToolPresenter.SelectItem(_itemName.text);
        Object.FindFirstObjectByType<ToolPresenter>().SelectItem(_itemName.text);
    }
}
