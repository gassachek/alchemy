using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomInspectore))]
public class EditorCustomInspectore : Editor {
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();
        CustomInspectore customInspectore = (CustomInspectore)target;

        if(GUILayout.Button("+5 to Raw")) {
            customInspectore.AddMaterials(ItemType.Raw);
            Debug.Log("sadsd");
        }

        if(GUILayout.Button("+5 to Ingredient")) {
            customInspectore.AddMaterials(ItemType.Ingredient);
            Debug.Log("sadsd");
        }

        if(GUILayout.Button("+5 to Potion")) {
            customInspectore.AddMaterials(ItemType.Potion);
            Debug.Log("sadsd");
        }
        
    }

    
}

