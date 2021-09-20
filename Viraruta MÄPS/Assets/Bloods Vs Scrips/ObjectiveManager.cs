using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI Objective;
    public string ActualObjective = "KILL THEM ALL";
    private string TempObjective1 = "";
    private string TempObjective2 = "";
    private string ScrambleList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!#¤%&/()=?@£$€{[]} ";
    private float ObjectiveLength;
    private float ScrambleLength;
    private int ScrambleNumber;
    private int ObjectiveNumber;

    // Start is called before the first frame update
    void Start(){

        ObjectiveLength = ActualObjective.Length;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ObjectiveScramble());
    }

        IEnumerator ObjectiveScramble(){
            yield return new WaitForSeconds(5);
            Scrambling();
        }

    void Scrambling(){
        Objective.color = new Color(255, 0, 0, 255);
        if(ActualObjective != TempObjective2){
            while(ObjectiveLength > TempObjective1.Length + ScrambleLength){
                ScrambleNumber = Random.Range(0, 55);
                TempObjective1 += ScrambleList[ScrambleNumber];
                ScrambleLength++;
            }
            if(TempObjective1[TempObjective2.Length] == ActualObjective[TempObjective2.Length]){
                TempObjective2 += TempObjective1[TempObjective2.Length];
            }
            Objective.text = TempObjective1;
            TempObjective1 = "";
            TempObjective1 = TempObjective2;
            ScrambleLength = 0;
            ObjectiveNumber = 0;
        }
    }
}
