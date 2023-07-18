using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private int points = 0;
    private int maxPoints = 0;
    private RoomLightCheckScript room;
    private int candle;
    
    [SerializeField] private List<Image> lightMeterComponents;
    private Image lightBar;
    private Image lightBarFX;
    private Image shadowBarFX;

    [SerializeField] public float meterMoveSpeed;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            room = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<RoomLightCheckScript>();
            
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
        lightBar.fillAmount -= 1.0f / meterMoveSpeed * Time.deltaTime;
        lightBarFX.fillAmount -= 1.0f / meterMoveSpeed * Time.deltaTime;
        shadowBarFX.fillAmount -= 1.0f / waitmeterMoveSpeedTime * Time.deltaTime;
    }
}
