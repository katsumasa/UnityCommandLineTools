using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR
namespace UTJ.UnityCommandLineTools
{
    // <summary>
    // pdb2mdbをUnityEditorから実行する為のClass
    // programed by Katsumasa.Kimura
    // </summary>
    public class Pdb2mdbExec : EditorToolExec
    {
        public Pdb2mdbExec() : base("pdb2mdb*") { }
        
    }
}
#endif