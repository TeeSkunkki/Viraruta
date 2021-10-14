using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")){
            animator.SetBool("Running", true);
        }

        else if (Input.GetKey("a")){
            animator.SetBool("Running", true);
        }

         else if (Input.GetKey("s")){
            animator.SetBool("Running", true);
        }

         else if (Input.GetKey("d")){
            animator.SetBool("Running", true);
        }

        else{
            animator.SetBool("Running", false);
        }


    }
}
