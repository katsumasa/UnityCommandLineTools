using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // diffをUnityEditorから実行する為のClass
    // programed by Katsumasa.Kimura
    // </summary>
    public class DiffExec : EditorToolExec
    {
        // <summary>
        // コンストラクタ
        // </summary>
        public DiffExec() : base("diff*") { }

        // <summary>
        // diffを実行する
        // <param>
        // filePath1 : ファイルへのパス
        // filePath2 : ファイルへのパス
        // options : diffに渡すオプション
        // <returns>
        // 正常時 : 0
        // 異常時 : 1,2
        // </returns>
        // </summary>
        public int Exec(string filePath1,string filePath2,string options = null)
        {
            string args;
            if (string.IsNullOrEmpty(options))
            {
                args = string.Format(@"""{0}"" ""{1}", filePath1, filePath2);
            }
            else
            {
                args = string.Format(@"""{2}"" ""{0}"" {1}", filePath1, filePath2, options);
            }
            return Exec(args);
        }
    }
}
#endif