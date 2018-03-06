using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorUIUtility {

    public static GUIStyle guiTitleStyle {
        get {
            var guiTitleStyle = new GUIStyle(GUI.skin.label);
            guiTitleStyle.normal.textColor = Color.white;
            guiTitleStyle.fontSize = 12;
            guiTitleStyle.fixedHeight = 25;

            return guiTitleStyle;
        }
    }

    public static GUIStyle guiMessageStyle {
        get {
            var messageStyle = new GUIStyle(GUI.skin.label);
            messageStyle.wordWrap = true;

            return messageStyle;
        }
    }
}
