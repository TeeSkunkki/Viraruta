using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    //public DialogManager TestableScript;


    [MenuItem("Tools/TestFunction")]
    DialogManager TestableScript;
    static void TestFunction(){
      //TestableScript.FunctionName
        TestableScript.DialogLine("Assets/Dialog.txt");
    }

}
