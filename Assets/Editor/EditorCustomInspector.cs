using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomInspectore))]
public class EditorCustomInspectore : Editor {
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();
        CustomInspectore customInspectore = (CustomInspectore)target;

        if(GUILayout.Button("+5 to Raw")) {
            customInspectore.AddRawMaterials();
            Debug.Log("sadsd");
        }

        if(GUILayout.Button("+5 to Ingredient")) {
            customInspectore.AddIngredientMaterials();
            Debug.Log("sadsd");
        }

        if(GUILayout.Button("+5 to Potion")) {
            customInspectore.AddPotionMaterials();
            Debug.Log("sadsd");
        }
        
    }

    
}

