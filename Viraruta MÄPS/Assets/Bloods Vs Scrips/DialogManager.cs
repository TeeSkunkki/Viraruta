using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public PlayerController PlayerController;
    public GameObject dialogBox;
    public GameObject nameBox;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public float typingSpeed = 0.05f;
    private string[] dialogLines;
    private int currentLine = 0;
    private bool justStarted;
    private bool isCoroutingRunning;
    void Start()
    {
        if (instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !isCoroutingRunning && justStarted){
            currentLine++;
            if (currentLine >= dialogLines.Length){
                StopDialog();
            } else {
                CheckIfName();
                StartCoroutine(AutoType(dialogLines, currentLine));
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson){
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogBox.SetActive(true);
        StartCoroutine(AutoType(dialogLines, currentLine));
        justStarted = true;
        nameBox.SetActive(isPerson);
    }

    private void CheckIfName(){
        if (dialogLines[currentLine].StartsWith("n-")){
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

    public void StopDialog(){
        dialogBox.SetActive(false);
        PlayerController.CanMove = 1.0f;
    }

    IEnumerator AutoType(string[] newLines, int _currentLine){
        dialogText.text = "";
        isCoroutingRunning = true;
        justStarted = false;
        foreach (char letter in newLines[_currentLine].ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isCoroutingRunning = false;
        justStarted = true;
    }
}
