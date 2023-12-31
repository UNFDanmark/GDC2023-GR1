using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CandleScript : MonoBehaviour
{
    [SerializeField] private Animator p1Animations;
    [SerializeField] private Animator p2Animations;
    
    private bool player1IsNear;
    private bool player2IsNear;
    private Transform flame;

    public int currentLightState;

    //previousLightState starts different from all possible states
    public int previousLightState = 2;

    // Update is called once per frame

    private void Start()
    {
        currentLightState = 0;

        p1Animations = FindObjectOfType<CallCoroutine>().GetComponent<Animator>();
            
        flame = gameObject.transform.GetChild(0).gameObject.transform.Find("Flame");

        if (flame.gameObject.activeSelf == true)
        {
            previousLightState = currentLightState;
            currentLightState = 1;
        }
    }

    void Update()
    {
        if (player1IsNear && Input.GetKeyDown(KeyCode.LeftControl) && currentLightState != 1 &&
            CountDownScript.gameEnded == false)
        {
            p1Animations.SetBool("IsDoneWithLights", false);
            p1Animations.SetBool("IsTurningLightOn", true);
            
            
            flame.gameObject.SetActive(true);
            currentLightState = 1;
        }
        else if (player2IsNear && Input.GetKeyDown(KeyCode.RightControl) && currentLightState == 1 &&
                 CountDownScript.gameEnded == false)

        {
            p2Animations.SetBool("IsTurningCandleOff", true);
            
            flame.gameObject.SetActive(false);
            currentLightState = -1;
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