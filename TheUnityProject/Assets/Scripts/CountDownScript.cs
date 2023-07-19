using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private int startTime;
    [SerializeField] private int timeSeconds;
    [SerializeField] private int timeMinutes;
    [SerializeField] private AudioSource normMusic;
    [SerializeField] private AudioSource speedMusic;

    public static bool gameEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeMinutes = startTime / 60;
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (gameEnded == true)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            if (timeSeconds == 0)
            {
                if (timeMinutes == 0)
                {
                    Debug.Log("Game has ended");
                    gameEnded = true;
                    yield break;
                }
                
                timeSeconds = 60;
                timeMinutes--;
            }
 
            timeSeconds--;
            
            counter.text = timeMinutes.ToString("D2") + ":" + timeSeconds.ToString("D2");
            yield return new WaitForSeconds(1f);

            if (timeMinutes == 0 && timeSeconds == 30)
            {
                //Play fast music
                normMusic.Pause();
                speedMusic.Play();
            }
            
        }
    }

}
