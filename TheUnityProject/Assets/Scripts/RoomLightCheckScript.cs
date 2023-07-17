using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomLightCheckScript : MonoBehaviour
{
    private int lightAmount = 0;
    private int lightsOn;
    private Transform roomLight;
    private Transform roomNeutral;

    [SerializeField] private List<GameObject> lights;
    private Transform flame;
    
    // Start is called before the first frame update
    void Start()
    {
        lightAmount = lights.Count;
        
        Debug.Log(lightAmount);
        
        roomLight = gameObject.transform.GetChild(0);
        roomNeutral = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        lightsOn = 0;
        for (int i = 0; i < lightAmount; i++)
        {
            flame = lights[i].gameObject.transform.GetChild(0).gameObject.transform.Find("Flame");
            Debug.Log("test");
            if (flame.gameObject.activeSelf == true)
            {
                lightsOn++;
            }
            else
            {
                lightsOn--;
            }
        }
        
        if (lightsOn >= lightAmount)
        {
     
            roomLight.gameObject.SetActive(true);
            roomNeutral.gameObject.SetActive(false);
        }

        else if (lightsOn <= lightAmount)
        {
            roomLight.gameObject.SetActive(false);
            roomNeutral.gameObject.SetActive(true);
        }
    }
}

