using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // bin2textをUnityEditorから実行する為のClass
    // programed by Katsumasa.Kimura
    // </summary>
    public class Binary2TextExec : EditorToolExec
    {
        public Binary2TextExec() : base("binary2text*") { }

        // <summary>
        // bin2text filePath outPath options
        // /summary>
        public int Exec(string filePath,string outPath,string options)
        {
            var args = string.Format(@"""{0}"" ""{1}"" {2}", filePath, outPath, options);
            return Exec(args);
        }
    }
}
#endif
