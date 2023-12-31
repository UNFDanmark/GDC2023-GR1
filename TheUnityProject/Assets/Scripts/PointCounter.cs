using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private float points = 0;
    private float maxPoints = 0;
    public static bool p1Win;
    private RoomLightCheckScript room;
    private int candle;

    [SerializeField] private List<Image> lightMeterComponents;
    private Image lightBar;
    private Image lightBarFX;
    private Image shadowBarFX;
    private float desiredLocation;

    [SerializeField] private float barAnimationSpeed = 0.5f;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            room = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0)
                .GetComponent<RoomLightCheckScript>();
            maxPoints += room.lightAmount;
        }

        lightBar = lightMeterComponents[0];
        lightBarFX = lightMeterComponents[1];
        shadowBarFX = lightMeterComponents[2];
    }

    // Update is called once per frame
    void Update()
    {
        points = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            room = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<RoomLightCheckScript>();
            candle = room.lightsOnInTotal;
            points += candle;
        }

        //Make lightMeter move
        desiredLocation = points / maxPoints;

        float blend = MathF.Pow(0.5f, Time.deltaTime * barAnimationSpeed);
        lightBar.fillAmount = Mathf.Lerp(lightBar.fillAmount, desiredLocation, blend);
        lightBarFX.fillAmount = Mathf.Lerp(lightBarFX.fillAmount, desiredLocation, blend);
        shadowBarFX.fillAmount = Mathf.Lerp(shadowBarFX.fillAmount, 1 - desiredLocation, blend);

        //Check which player is in the lead
        if (points > maxPoints/2)
        {
            p1Win = true;
        }
        else
        {
            p1Win = false;
        }

        if (p1Win == true && CountDownScript.gameEnded == true)
        {
            //P1 win screen
        }
        else if (p1Win == false && CountDownScript.gameEnded == true)
        {
            //P2 win screen
        }
        
        
    }
}