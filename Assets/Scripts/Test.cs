using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Inventory inventory= new Inventory();

        inventory.Add("grass", 5);
        inventory.Add("eyes", 2);
        inventory.Add("flower", 1);

        Debug.Log(inventory.Get("grass"));
        Debug.Log(inventory.Get("flower"));

        inventory.Remove("eyes", 1);
        inventory.Remove("flower", 1);
        Debug.Log(inventory.Get("eyes"));
        Debug.Log(inventory.Get("flower"));

        inventory.Remove("grass", 6);
        
    }

    void Update()
    {
        
    }
}