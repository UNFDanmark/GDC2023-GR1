using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    private float hMove;
    private float vMove;

    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxis("Horizontal_P2");
        vMove = Input.GetAxis("Vertical_P2");

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hMove * moveSpeed, rb.velocity.y, vMove * moveSpeed);
    }
}
