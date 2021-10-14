using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UTJ.UnityCommandLineTools;

[System.Serializable]
public class WebExtractExecWindow : EditorWindow
{
    static class Styles
    {
        public static GUIContent Src = new GUIContent("Open Binary", "binary file");
        public static readonly GUIContent SaveContents = new GUIContent((Texture2D)EditorGUIUtility.Load("d_OpenedFolder Icon"), "Set Save Location");
    }

    [SerializeField] string mBinaryFilePath = "";
    [MenuItem("Window/UTJ/UnityCommanLineTools/WebExtractExec")]
    static void Init()
    {
        var window = (WebExtractExecWindow)EditorWindow.GetWindow(typeof(WebExtractExecWindow));
        window.Show();
    }

    private void OnGUI()
    {

        EditorGUILayout.BeginHorizontal();
        {
            GUIContent content;
            Vector2 contentSize;

            contentSize = EditorStyles.label.CalcSize(Styles.SaveContents);
            if (GUILayout.Button(Styles.SaveContents, GUILayout.MaxWidth(contentSize.x + 10)))
            {
                mBinaryFilePath = EditorUtility.OpenFilePanel("Select binary file", "", "");
            }
            contentSize = EditorStyles.label.CalcSize(Styles.Src);
            EditorGUILayout.LabelField(Styles.Src, GUILayout.MaxWidth(contentSize.x + 10));
            content = new GUIContent(mBinaryFilePath);
            contentSize = EditorStyles.label.CalcSize(content);
            EditorGUILayout.LabelField(new GUIContent(mBinaryFilePath), GUILayout.Width(contentSize.x + 10));
            GUILayout.FlexibleSpace();
        }
        EditorGUILayout.EndHorizontal();



        EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty(mBinaryFilePath));
        {
            if (GUILayout.Button("Done"))
            {
                var bin2exec = new WebExtractExec();
                var result = bin2exec.Exec(mBinaryFilePath);
                EditorUtility.DisplayDialog(result == 0 ? "Success" : "Fail", bin2exec.output, "OK");
            }
        }
        EditorGUI.EndDisabledGroup();

    }


}
