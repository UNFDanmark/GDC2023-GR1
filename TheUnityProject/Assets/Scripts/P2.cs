using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    private float hMove;
    private float vMove;

    [SerializeField] private float normMoveSpeed = 1f;
    [SerializeField] private float wallMoveSpeed = 0.5f;

    private Rigidbody rb;
    [SerializeField] private Animator animations;

    private bool inWall = false;
    private int inWalls = 0;
    
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
            hMove = Input.GetAxis("Horizontal_P2");
            vMove = Input.GetAxis("Vertical_P2");
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
            transform.forward = movementDirection;
        }

        if (hMove != 0 || vMove != 0)
        {
            animations.SetBool("IsWalking", true);
        }
        else
        {
            animations.SetBool("IsWalking", false);
        }
    }
    
    private void FixedUpdate()
    {
        if (inWall)
        {
            rb.velocity = new Vector3(hMove * wallMoveSpeed, rb.velocity.y, vMove * wallMoveSpeed);
            
        }
        else
        {
            rb.velocity = new Vector3(hMove * normMoveSpeed, rb.velocity.y, vMove * normMoveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallSlow"))
        {
            animations.SetBool("IsHittingWall", true);
            
            if (hMove != 0 && vMove != 0)
            {
                animations.SetBool("IsHittingWall", false);
                animations.SetBool("IsInWall", true);
            }
            inWall = true;
            inWalls++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WallSlow") && inWall)
        {
            animations.SetBool("IsInWall", false);
            animations.SetBool("IsLeavingWall", true);
            
            inWalls--;
            if (inWalls < 1)
            {
                inWall = false;
            }
        }
    }
}
