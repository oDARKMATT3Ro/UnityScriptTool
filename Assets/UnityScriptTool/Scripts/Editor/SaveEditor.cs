using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditorInternal;

[CustomEditor(typeof(Save))]
public class SaveEditor : Editor {

    private ReorderableList list;
    private Save saveScript;

    private void OnEnable() {
        saveScript = Selection.activeGameObject.GetComponent<Save>();
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("items"), true, true, true, true);
        list.onRemoveCallback += RemoveCallback;
        list.drawElementCallback += OnDrawCallback;
    }

    private void OnDisable() {
        if (list != null) {
            list.onRemoveCallback -= RemoveCallback;
            list.drawElementCallback -= OnDrawCallback;
        }
    }

    private void RemoveCallback(ReorderableList list) {
        if (EditorUtility.DisplayDialog("Warning!", "Are you sure you want to delete the item from the list?", "Proceed", "Cancel")) {
            ReorderableList.defaultBehaviours.DoRemoveButton(list);
        }
    }

    private void OnDrawCallback(Rect rect, int index, bool isActive, bool isFocused) {

        var item = list.serializedProperty.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, 75, EditorGUIUtility.singleLineHeight),
            item.FindPropertyRelative("name"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            new Rect(rect.x + 100, rect.y, 200, EditorGUIUtility.singleLineHeight),
            item.FindPropertyRelative("pos"),
            GUIContent.none
        );
    }

    public override void OnInspectorGUI() {

        // DrawDefaultInspector();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField(GetType().ToString(), EditorUIUtility.guiTitleStyle);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Insert text here to explain how to use this editor...", EditorUIUtility.guiMessageStyle);

        EditorGUILayout.Space();

        list.DoLayoutList();

        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Save")) {
            var saveText = saveScript.runSave();

            WriteData(saveText);
            Debug.Log("Save " + saveText);
        }

        if (GUILayout.Button("Load")) {

            saveScript.runLoad(ReadDataFromFile());
            Debug.Log("Load ");
        }

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }

    private void WriteData(string data) {

        var path = EditorUtility.SaveFilePanel("Save Data", "", "data.txt", "txt");

        using (FileStream fs = new FileStream(path, FileMode.Create)) {
            using (StreamWriter writer = new StreamWriter(fs)) {
                writer.Write(data);
            }

        }

        AssetDatabase.Refresh();


    }

    private string ReadDataFromFile() {

        var path = EditorUtility.OpenFilePanel("Load Data", "", "txt");

        var reader = new WWW("file:///" + path);
        while (!reader.isDone) {

        }

        return reader.text;
    }
}
