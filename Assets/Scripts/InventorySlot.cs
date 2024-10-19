using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshPro itemName;
    public TextMeshPro itemCount;

    public void SetSlot(Sprite itemIcon, string name, int count)
    {
        icon.sprite = itemIcon;
        itemName.text = name;
        itemCount.text = count.ToString();
    }
}
