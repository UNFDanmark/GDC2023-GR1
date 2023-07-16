using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightCheckScript : MonoBehaviour
{

    private int lightAmount;

    private int lightsOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn >= lightAmount)
        {
            //Bunnyroom
        }
        
        else if (lightsOn <= 0)
        {
            //Ghostroom
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
