using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public DialogManager DialogManager;
    public PlayerController PlayerController;
    public string[] lines;

    private void OnTriggerEnter(Collider collider){
      if(collider.CompareTag("Player")){
          PlayerController.CanMove = 0.0f;
          DialogManager.instance.ShowDialog(lines, true);
          gameObject.SetActive(false);
      }
    }
}