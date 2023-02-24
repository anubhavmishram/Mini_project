using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();

    }

    void moveCamera(){
        float moveX = 0f;
        float moveY = 0f;
        float moveZ = 0f;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            moveZ = +1f;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            moveZ = -1f;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            moveX = -1f;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            moveX = +1f;
        }

        if(Input.GetKey(KeyCode.Q)){
            moveY = +1f;
        }
        
        if(Input.GetKey(KeyCode.E)){
            moveY = -1f;
        }

        Vector3 moveDirection = new Vector3(moveX, moveY,moveZ).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


    }
}
