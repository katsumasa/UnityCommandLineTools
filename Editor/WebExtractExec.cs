using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // bin2textをUnityEditorから実行する為のClass
    // programed by Katsumasa.Kimura
    // </summary>
    public class WebExtractExec : EditorToolExec
    {
        public WebExtractExec() : base("WebExtract*") { }     
    }
}
#endif