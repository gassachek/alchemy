using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [SerializeField]private Image icon;
    [SerializeField]private TMP_Text itemName;
    [SerializeField]private TMP_Text itemCount;

    // Sprite itemIcon, 
    public void SetSlot(string name, int count)
    {
        // icon.sprite = itemIcon;
        itemName.text = name;
        itemCount.text = count.ToString();
    }
}
