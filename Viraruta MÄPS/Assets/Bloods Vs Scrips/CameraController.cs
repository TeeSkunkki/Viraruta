using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float CameraDistance;
    private Player Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    mainCamera.transform.position = new Vector3(Player.transform.position.x, 10f, Player.transform.position.z);
    }
}
