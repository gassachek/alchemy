// using UnityEngine;

// public class Test : MonoBehaviour
// {
//     public MaterialDatabase materialDatabase;
//     private Inventory inventory;
//     void Start()
//     {
//         inventory= new Inventory();
//         MaterialData grass = materialDatabase.GetMaterialByName("grass");
//         MaterialData eyes = materialDatabase.GetMaterialByName("eyes");
//         MaterialData flowers = materialDatabase.GetMaterialByName("flowers");

//         inventory.Add(grass, 5);
//         inventory.Add(eyes, 2);
//         inventory.Add(flowers, 1);

//         Debug.Log(inventory.Get("grass"));
//         Debug.Log(inventory.Get("eyes"));

//         inventory.Remove("eyes", 1);
//         inventory.Remove("flowers", 1);
//         Debug.Log(inventory.Get("eyes"));
//         // Debug.Log(inventory.Get("flowers"));

//         inventory.Remove("grass", 6);
        
//     }
// }