using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
 
[CustomEditor(typeof(NearConnector))]
[CanEditMultipleObjects]
public class Unity_Near_Plugin : Editor
{
    SerializedProperty soulRarityProp;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        soulRarityProp = serializedObject.FindProperty ("soulRarity");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update ();
        DrawDefaultInspector();

        if(GUILayout.Button("Developer Wallet connected"))
        {
            //Connect executions from core script
        }

        GUILayout.Label ("NFT mint GameObject");

        EditorGUILayout.IntSlider(soulRarityProp, 0, 100, new GUIContent ("SoulRarity"));

        if(GUILayout.Button("Deeploy NFT game Object Script"))
        {
            //Connect executions from core script
        }
    }
}
