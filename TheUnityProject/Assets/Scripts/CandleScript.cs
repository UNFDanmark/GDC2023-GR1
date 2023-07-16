using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    private bool player1IsNear;
    private bool player2IsNear;
    private Transform flame;

    // Update is called once per frame

    private void Start()
    {
        flame = gameObject.transform.GetChild(0).gameObject.transform.Find("Flame");

    }

    void Update()
    {
        if (player1IsNear && Input.GetKeyDown(KeyCode.E))
        {
            flame.gameObject.SetActive(true);
            
        }
        else if (player2IsNear && Input.GetKeyDown(KeyCode.RightControl))
        {
            flame.gameObject.SetActive(false);
         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            player1IsNear = true;
        }
        else if (other.CompareTag("P2"))
        {
            player2IsNear = true; 
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            player1IsNear = false;
        }
        else if (other.CompareTag("P2"))
        {
            player2IsNear = false;
        }
    }
}
