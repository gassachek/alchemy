using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialDatabase", menuName = "Materials/Material Database")]
public class MaterialDatabase : ScriptableObject
{
    [SerializeField] private List<MaterialData> _materials;

    public MaterialData GetMaterialByName(string name)
    {
        foreach (var material in _materials)
        {
            if (material.Name == name)
            {
                return material;
            }
        }
        return null;
    }
}
