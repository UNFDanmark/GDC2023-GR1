using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightCheckScript : MonoBehaviour
{
    private int lightAmount = 0;
    private int lightsOn;
    private Transform roomLight;

    [SerializeField] private List<GameObject> lights;

    // Start is called before the first frame update
    void Start()
    {
        // lights.førstelys.Getchild(0).
        
        foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
            // mere kan indsættes her?
        }
        
        roomLight = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn >= lightAmount)
        {
            Debug.Log("Lights on: " + lightsOn);
            Debug.Log("lightAmount : " + lightAmount);
            roomLight.gameObject.SetActive(true);
        }

        else if (lightsOn <= 0)
        {
            roomLight.gameObject.SetActive(false);
        }
    }

    //collider.bounds
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            lightAmount++;
        }

        if (other.CompareTag("Flame"))
        {
            lightsOn++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flame"))
        {
            lightsOn--;
        }
    }
}

