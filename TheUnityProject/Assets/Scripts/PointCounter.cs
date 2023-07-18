using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private float points = 0;
    private float maxPoints = 0;
    private RoomLightCheckScript room;
    private int candle;
    
    [SerializeField] private List<Image> lightMeterComponents;
    private Image lightBar;
    private Image lightBarFX;
    private Image shadowBarFX;
    private float desiredLocation;

    [SerializeField] public float meterMoveSpeed;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            room = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<RoomLightCheckScript>();
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
            Debug.Log("Points: " + points);
        }
        
        //Make lightMeter move
        desiredLocation = points / maxPoints;
      //  lightBar.fillAmount = desiredLocation;
        lightBar.fillAmount = Mathf.Lerp(lightBar.fillAmount, desiredLocation, Time.deltaTime);

        /*
        for (int i = 0; i < (points/maxPoints) * 100; i++)
        {
            lightBar.fillAmount += (1/maxPoints) / meterMoveSpeed * Time.deltaTime;
            lightBarFX.fillAmount -= (1/maxPoints) / meterMoveSpeed * Time.deltaTime;
            //shadowBarFX.fillAmount -= (1/maxPoints) / meterMoveSpeed * Time.deltaTime;
        }*/

    }
}
