using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightCheckScript : MonoBehaviour
{
    private int lightAmount;
    private int lightsOn;
    private Transform roomLight;

    // Start is called before the first frame update
    void Start()
    {
        roomLight = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn >= lightAmount)
        {
            roomLight.gameObject.SetActive(true);
        }

        else if (lightsOn <= 0)
        {
            roomLight.gameObject.SetActive(false);
        }
    }

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