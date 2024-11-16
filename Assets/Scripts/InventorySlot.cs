using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [SerializeField]private Image _icon;
    [SerializeField]private TMP_Text _itemName;
    private string _name;
    [SerializeField]private TMP_Text _itemCount;
    [SerializeField] private Button _button;

    // Sprite itemIcon, 
    public void SetSlot(string name, int count)
    {
        // icon.sprite = itemIcon;
        _itemName.text = name;
        _itemCount.text = count.ToString();
    }

    void Start()
    {

        _button.onClick.AddListener(OnSlotClicked);
    }

    private void OnSlotClicked()
    {
        Object.FindFirstObjectByType<ToolPresenter>().SelectItem(_name);
    }
}
