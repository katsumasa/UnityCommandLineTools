using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // コマンドラインツールを使用してDLLを作成する
    // Programed by Katsumasa.Kimura
    // </summary>
    public class McsExec : EditorToolExec
    {
        public McsExec() : base(
#if UNITY_EDITOR_WIN
            "mcs.bat"
#else
            "mcs"
#endif
            ) { }
        
        // <summary>
        // DLLを作成する
        // <param name ="isUseUnityEngineDll">UnityEngine.dllを含める</param>
        // <param name ="isUseUnityEditorDll">UnityEditor.dllを含める</param>
        // <param name = "isDebug>mbp情報を出力する</param>
        // <param name ="dllName">出力するDLLのファイル名</param>
        // <param name ="srcNames">C#のファイル名の配列</param>
        // <returns>実行結果 0:正常時 その他:異常時</returns>
        // </summary>
        public int Exec(
            bool isUseUnityEngineDll,
            bool isUseUnityEditorDll,
            bool isDebug,
            string dllName,
            string[] srcNames
            )
        {
            string args = "";

            if (isUseUnityEngineDll)
            {
                var path = "UnityEngine.dll";
                var files = Directory.GetFiles(mEditorPath, path,  SearchOption.AllDirectories);
                args += " -r:\"" + files[0] + "\"";
            }
            if (isUseUnityEditorDll)
            {
                var path ="UnityEditor.dll";
                var files = Directory.GetFiles(mEditorPath, path, SearchOption.AllDirectories);
                args += " -r:\"" + files[0] + "\"";
            }
            args += " -target:library -out:" + dllName;

            if (isDebug)
            {
                args += " -debug";
            }

            foreach(var srcName in srcNames)
            {
                args += " " + srcName;
            }

            return base.Exec(args);
        }

    }
}
#endif