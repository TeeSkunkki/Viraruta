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
    private string DialogAll;
    private string DialogTextTemp = "";
    private string DialogCharTemp = "";
    private int check = 0;
    private int nextline = 0;

    void Awake(){
        DialogLine("Assets/Dialog/Dialog.txt");
    }

    public void DialogLine(string Path)
    {
        
        //Read the text from directly from the .txt file
        StreamReader reader = new StreamReader(Path);
        DialogAll = reader.ReadToEnd().ToString();
        for(int i = 0; i < DialogAll.Length; i++)
        {
            if(Input.GetKeyDown("space")){
                Debug.Log(nextline);
                nextline = 0;
                Debug.Log(nextline);
            }
            Debug.Log("Waiting " + i);
            if(check == 0 && nextline == 0){
            if(DialogAll[i].ToString() == "<"){
                Char(i);
            }else if(DialogAll[i].ToString() == ">"){
                Text(i);
            }
            }
        }
        reader.Close();
    }

    private void Char(int i){
        //Editing character namebox
                int u = i + 1;
                while(DialogAll[u].ToString() != ">"){
                    DialogCharTemp += DialogAll[u].ToString();
                    u++;
                }
                DialogChar.text = DialogCharTemp;
                DialogCharTemp = "";
    }

    private void Text(int i){
        //Editing textbox
                int u = i;
                while(DialogAll[u].ToString() != "<"){
                    DialogTextTemp += DialogAll[u].ToString();
                    u++;
                    if(u == DialogAll.Length){
                        check = 1;
                        break;
                    }
                }
                nextline = 1;
                DialogText.text = DialogTextTemp;
                DialogTextTemp = "";
    }
}
