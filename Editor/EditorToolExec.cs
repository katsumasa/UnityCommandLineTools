using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // UnityEditorに含まれるコマンドラインツールを実行する為の基底Class
    // programed by Katsumasa.Kimura
    //</summary>
    public class EditorToolExec
    {
        // <value>
        // UnityEditorがインストールされているディレクトリへのパス
        // </value>
        protected string mEditorPath;

        // <value>
        // Toolsディレクトリへのパス
        // </value>
        protected string mToolsPath;

        // <value>
        // 実行ファイル名
        // </value>
        protected string mExecFname;

        // <value>
        // 実行ファイルへのフルパス
        // </value>
        protected string mExecFullPath;

        // <value>
        // 実行結果のOUTPUT
        // </value>
        private string mOutput;

        // <value>
        // 実行結果のOUTPUT
        // </value>
        public string output
        {
            get { return mOutput; }
        }

        // <summary>
        // コンストラクタ
        // <param>
        // mExecFname : 実行ファイル名
        // </param>
        // /summary>
        public EditorToolExec(string mExecFname)
        {
            mEditorPath = Path.GetDirectoryName(EditorApplication.applicationPath);            
            mToolsPath = Path.Combine(mEditorPath, @"Data/Tools");
            this.mExecFname = mExecFname;
            var files = Directory.GetFiles(mToolsPath, mExecFname, SearchOption.AllDirectories);
            mExecFullPath = files[0];
        }

        // <summary> 
        // コマンドラインツールを実行する
        // <param> 
        // arg : コマンドラインツールに渡す引数 
        // </param>
        // </summary>
        public int Exec(string arg)
        {
            int exitCode = -1;

            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = mExecFullPath;
                    process.StartInfo.Arguments = arg;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    mOutput = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    exitCode = process.ExitCode;
                    process.Close();
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
            return exitCode;
        }
    }
}
#endif