using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UnityScriptTool))]
public class UnityScriptToolEditor : Editor {

        private bool visible;

        public override void OnInspectorGUI() {

            var script = target as UnityScriptTool;

        // DrawDefaultInspector();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField(GetType().ToString(), EditorUIUtility.guiTitleStyle);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Insert text here to explain how to use this editor...", EditorUIUtility.guiMessageStyle);

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical("box");

        EditorGUILayout.LabelField("Parameters", EditorUIUtility.guiTitleStyle);
        EditorGUILayout.Space();

        script.speed = EditorGUILayout.Slider("Speed", script.speed, 0, 100);

            script.target = EditorGUILayout.ObjectField("Target", script.target, typeof(Target), true) as Target;

        if (script.target == null) {
            EditorGUILayout.HelpBox("Error! No target game object selected.", MessageType.Error);
        }

        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical("box");
        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Options", EditorUIUtility.guiTitleStyle);
        visible = EditorGUILayout.Foldout(visible, "Options");

        if (visible) {
            EditorGUI.indentLevel++;
            var props = new[] { "startPos", "target", "dialog" };

            for (var i = 0; i < props.Length; i++) {
                var sProp = serializedObject.FindProperty(props[i]);
                var guiContent = new GUIContent();
                guiContent.text = sProp.displayName;
                EditorGUILayout.PropertyField(sProp, guiContent);
            }
            EditorGUI.indentLevel--;
        }
        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Debug Tools", EditorUIUtility.guiTitleStyle);
        if (GUILayout.Button("Open Script Tools Window")) {
            Debug.Log("Open Script Tools Window");
            EditorWindow.GetWindow(typeof(UnityScriptToolWindow));
        }
        if (GUILayout.Button("Debug")) {
            Debug.Log("Debug Test");
        }

        EditorGUILayout.EndVertical();


        }
    }
