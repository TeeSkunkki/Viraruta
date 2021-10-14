using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour{
    public float speed;
    public float maxBloom = 10.0f;
    public float minBloom;

    void Start(){
      minBloom = maxBloom * -1.0f;
      transform.Rotate(90.0f, 0.0f, Random.Range(minBloom, maxBloom), Space.Self);
    }

    // Update is called once per frame
    void Update(){
      transform.Translate(Vector3.up * speed * Time.deltaTime);

    }
}