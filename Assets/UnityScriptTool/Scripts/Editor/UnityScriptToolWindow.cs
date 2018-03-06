using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityScriptToolWindow : EditorWindow {

    private GameObject currentSelection;

    [MenuItem("Window/UnityScriptToolWindow")]
    static void Init() {
        var window = (UnityScriptToolWindow)GetWindow(typeof(UnityScriptToolWindow));

        var content = new GUIContent();
        content.text = "Script Tool";

        var icon = new Texture2D(16, 16);
        content.image = icon;

        window.titleContent = content;
    }

    private void OnFocus() {
        Debug.Log("On Focus");
        currentSelection = Selection.activeGameObject;
    }

    private void LostFocus() {
        Debug.Log("Lost Focus");
    }

    private void OnGUI() {

        if (currentSelection != null) {

            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Currently selected GameObject: ");
            EditorGUILayout.LabelField(currentSelection.name);
            currentSelection.transform.position = EditorGUILayout.Vector3Field("at position", currentSelection.transform.position);

            EditorGUILayout.EndVertical();
        } else {

            EditorGUILayout.LabelField("First select a GameObject then click inside this window.");
        }

        DropAreaGUI();

    }

    private void DropAreaGUI() {

        var e = Event.current.type;

        if (e == EventType.DragUpdated) {
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
        } else if (e == EventType.DragPerform) {
            DragAndDrop.AcceptDrag();

            foreach (Object draggedObject in DragAndDrop.objectReferences) {
                if (draggedObject is GameObject) {
                    Debug.Log(draggedObject.name);
                }
            }
        }
    }


}
