using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public static event Action InventoryChanged;

    public static void OnInventoryChanged()
    {
        InventoryChanged?.Invoke();
    }
}
