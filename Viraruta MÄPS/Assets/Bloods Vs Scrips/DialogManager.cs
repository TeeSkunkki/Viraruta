using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI DialogText;
    public TextMeshProUGUI DialogChar;
    private string PlayerName = "SHELL";
    private string Path = "Assets/Dialog.txt";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string Path = "Assets/Dialog.txt";
        string DialogAll;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(Path);
        DialogAll = reader.ReadToEnd().ToString();
        for(int i = 0; i <= DialogAll.Length; i++)
        {
            if(DialogAll[i].ToString() == "<"){
                Dia
            }
        }
        reader.Close();
    }
}
