using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UTJ.UnityCommandLineTools;

[System.Serializable]
public class Binary2TextExecWindow : EditorWindow
{
    static class Styles
    {
        public static GUIContent Src = new GUIContent("Open Binary","binary file");
        public static GUIContent Dest = new GUIContent("Save As","text file");
        public static GUIContent Option = new GUIContent("Option");
        public static GUIContent Detailed = new GUIContent("Detailed");
        public static GUIContent LargeBinaryHashOnly = new GUIContent("LargeBinaryHashOnly");
        public static GUIContent HexFloat = new GUIContent("HexFloat");
        public static readonly GUIContent SaveContents = new GUIContent((Texture2D)EditorGUIUtility.Load("d_OpenedFolder Icon"), "Set Save Location");

    }

    [SerializeField] string mBinaryFilePath = "";
    [SerializeField] string mTextFilePath = "";
    [SerializeField] bool mIsDetailed;
    [SerializeField] bool mIsLargeBinaryHashOnly;
    [SerializeField] bool mIsHexfloat;


    [MenuItem("Window/UnityCommanLineTools/Binary2Text")]
    static void Init()
    {
        var window = (Binary2TextExecWindow)EditorWindow.GetWindow(typeof(Binary2TextExecWindow));
        window.Show();
    }


    private void OnGUI()
    {

        EditorGUILayout.BeginHorizontal();
        {
            GUIContent content;
            Vector2 contentSize;
            
            contentSize = EditorStyles.label.CalcSize(Styles.SaveContents);
            if(GUILayout.Button(Styles.SaveContents, GUILayout.MaxWidth(contentSize.x + 10))){
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

        EditorGUILayout.BeginHorizontal();
        {
            GUIContent content;
            Vector2 contentSize;
            
            contentSize = EditorStyles.label.CalcSize(Styles.SaveContents);
            if (GUILayout.Button(Styles.SaveContents, GUILayout.MaxWidth(contentSize.x + 10)))
            {
                string defaultName = "";
                if(string.IsNullOrEmpty(mBinaryFilePath) == false)
                {
                    defaultName = System.IO.Path.GetFileNameWithoutExtension(mBinaryFilePath) + ".txt";
                }


                mTextFilePath = EditorUtility.SaveFilePanel(
                    "Save texture as PNG",
                    "",
                    defaultName,
                    "txt");
            }
            contentSize = EditorStyles.label.CalcSize(Styles.Src);
            EditorGUILayout.LabelField(Styles.Dest, GUILayout.MaxWidth(contentSize.x + 10));
            content = new GUIContent(mTextFilePath);
            contentSize = EditorStyles.label.CalcSize(content);
            EditorGUILayout.LabelField(new GUIContent(mTextFilePath), GUILayout.Width(contentSize.x + 10));         
            GUILayout.FlexibleSpace();
        }
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.LabelField(Styles.Option);
        using (new EditorGUI.IndentLevelScope())
        {
            mIsDetailed = EditorGUILayout.ToggleLeft(Styles.Detailed, mIsDetailed);
            mIsLargeBinaryHashOnly = EditorGUILayout.ToggleLeft(Styles.LargeBinaryHashOnly, mIsLargeBinaryHashOnly);
            mIsHexfloat = EditorGUILayout.ToggleLeft(Styles.HexFloat, mIsHexfloat);
        }

        EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty( mTextFilePath) || string.IsNullOrEmpty(mBinaryFilePath));
        {
            if (GUILayout.Button("Done"))
            {
                var bin2exec = new Binary2TextExec();
                
                string options = "";
                if (mIsDetailed)
                {
                    options += " -detailed";
                }
                if (mIsLargeBinaryHashOnly)
                {
                    options += " -largebinaryhashonly";
                }
                if (mIsHexfloat)
                {
                    options += " -hexfloat";
                }

                var result = bin2exec.Exec(mBinaryFilePath, mTextFilePath, options);
                EditorUtility.DisplayDialog(result == 0 ? "Success" : "Fail", bin2exec.output,"OK");
            }
        }
        EditorGUI.EndDisabledGroup();

    }


}
