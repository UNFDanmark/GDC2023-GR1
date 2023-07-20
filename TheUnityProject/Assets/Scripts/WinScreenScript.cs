using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    [SerializeField] private AudioSource barryTheme;
    [SerializeField] private AudioSource garyTheme;

    // Start is called before the first frame update
    void Start()
    {
        if (PointCounter.p1Win == true)
        {
            //If Barry wins, turn Gary's art off and play music
            barryTheme.Play();
            gameObject.SetActive(false);
            
        }
        else
        {
            garyTheme.Play();
        }
    }
}
