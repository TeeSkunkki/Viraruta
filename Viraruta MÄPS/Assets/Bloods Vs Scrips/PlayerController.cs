using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private GameObject resetbutton;

    public float moveSpeed;
    private Rigidbody myRigidbody;
    public Rigidbody PlayerRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float DashDistance;
    private float X;
    private float Z;
    private float asda = 0.1f;

    private Camera mainCamera;

    public GunController theGun;

    private GameObject Kuolema;
    // Start is called before the first frame update
    void Start() {
      myRigidbody = GetComponent<Rigidbody>();
      PlayerRigidbody = myRigidbody;
      mainCamera = FindObjectOfType<Camera>();
      Kuolema = GameObject.Find("Kuolit");
      Kuolema.SetActive(false);
      resetbutton = GameObject.Find("ResetButton");
      resetbutton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
      moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
      moveVelocity = moveInput * moveSpeed;
     

      Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
      Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
      float rayLength;

      if(groundPlane.Raycast(cameraRay, out rayLength))
      {
        Vector3 pointToLook = cameraRay.GetPoint(rayLength);
        Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
      }

      if(Input.GetMouseButtonDown(0))
        theGun.isFiring = true;

      if(Input.GetMouseButtonUp(0))
        theGun.isFiring = false;

      if(Input.GetKeyDown(KeyCode.Space)){
        X = transform.position.x - cameraRay.GetPoint(rayLength).x;
        Z = transform.position.z - cameraRay.GetPoint(rayLength).z;
        if(X > DashDistance){
          X = DashDistance;
        }
        if(X < -DashDistance){
          X = -DashDistance;
        }
        if(X < asda && X > -asda){
          X = 0f;
        }
        if(Z > DashDistance){
          Z = DashDistance;
        }
        if(Z < -DashDistance){
          Z = -DashDistance;
        }
        if(Z < asda && Z > -asda){
          Z = 0f;
        }

        transform.position += new Vector3(-X, 0, -Z);
      }

    }

    void FixedUpdate ()
    {
      myRigidbody.velocity = moveVelocity;
    }

    private void OnTriggerEnter(Collider collider){
      if(collider.CompareTag("vihollinen")){
        //Kuolema.transform.position = new Vector3(0,0,0);
        Kuolema.SetActive(true);
        resetbutton.SetActive(true);
        this.gameObject.SetActive(false);
      }
    }
}
