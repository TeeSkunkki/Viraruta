using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float CameraDistance;
    private Vector3 PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = new Vector3(FindObjectOfType<Player>().transform.position.x, FindObjectOfType<Player>().transform.position.y, FindObjectOfType<Player>().transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
    mainCamera.transform.position = new Vector3(myRigidbody.transform.position.x, 10f, myRigidbody.transform.position.z);
    }
}
