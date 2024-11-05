using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [SerializeField]private Image _icon;
    [SerializeField]private TMP_Text _itemName;
    [SerializeField]private TMP_Text _itemCount;

    // Sprite itemIcon, 
    public void SetSlot(string name, int count)
    {
        // icon.sprite = itemIcon;
        _itemName.text = name;
        _itemCount.text = count.ToString();
    }
}
