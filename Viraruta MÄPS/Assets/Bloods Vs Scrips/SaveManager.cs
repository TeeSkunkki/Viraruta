using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    public Button SaveButton;
    public Button LoadButton;
    private string SavePath;

void Start(){
    SavePath = Application.persistentDataPath + "/Save.json";
}

    void OnEnable(){
        SaveButton.onClick.AddListener(delegate { Save(); });
        LoadButton.onClick.AddListener(delegate { Load(); });
    }

    void Save(){

    }

    void Load(){

    }

}
