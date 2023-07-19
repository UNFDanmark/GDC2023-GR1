using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomLightCheckScript : MonoBehaviour
{
    public int lightAmount = 0;
    public int lightsOnInTotal = 0;

    private Transform roomLight;
    private Transform roomNeutral;

    [SerializeField] private List<GameObject> lights;
    private Transform flame;

    public CandleScript candles;

    // Start is called before the first frame update
    void Awake()
    {
        lightAmount = lights.Count;
        
        //Must have start value
        candles = lights[0].GetComponent<CandleScript>();
        
        roomLight = gameObject.transform.GetChild(0);
        roomNeutral = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lightAmount; i++)
        {
            candles = lights[i].GetComponent<CandleScript>();
            if (candles.previousLightState != candles.currentLightState)
            { 
                lightsOnInTotal += candles.currentLightState;
                candles.previousLightState = candles.currentLightState;
            }
            
        }
        
        //Change roomlight depending on lightstate
        if (lightsOnInTotal >= lightAmount)
        {
            Debug.Log("LightRoom");
            roomLight.gameObject.SetActive(true);
            roomNeutral.gameObject.SetActive(false);
        }

        if (lightsOnInTotal > 0 && lightsOnInTotal < lightAmount)
        {
            Debug.Log("NeutralRoom");
            roomLight.gameObject.SetActive(false);
            roomNeutral.gameObject.SetActive(true);
        }
        
        if (lightsOnInTotal <= 0)
        {
            Debug.Log("DarkRoom");
            roomNeutral.gameObject.SetActive(false);
        }
    }
}

