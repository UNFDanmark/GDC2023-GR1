using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P1 : MonoBehaviour
{
    private float hMove;
    private float vMove;

    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody rb;
    [SerializeField] private Animator animations;
    
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDownScript.gameEnded == false)
        {
            if (animations.GetBool("IsDoneWithLights") == true)
            {
                hMove = Input.GetAxis("Horizontal_P1");
                vMove = Input.GetAxis("Vertical_P1");
            }
            else
            {
                hMove = 0;
                vMove = 0;
            }
            
        }
        else
        {
            hMove = 0;
            vMove = 0;
        }
        
        Vector3 movementDirection = new Vector3(hMove, 0, vMove);
        movementDirection.Normalize();
        
        if (movementDirection != Vector3.zero)
        {
            animations.SetBool("IsWalking", true);
            transform.forward = movementDirection;
        }
        else
        {
            animations.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hMove * moveSpeed, rb.velocity.y, vMove * moveSpeed);
    }
}
