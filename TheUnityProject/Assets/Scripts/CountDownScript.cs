using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private int startTime;
    [SerializeField] private int timeSeconds;
    [SerializeField] private int timeMinutes;

    public static bool gameEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeMinutes = startTime / 60;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            if (timeSeconds == 0)
            {
                if (timeMinutes == 0)
                {
                    gameEnded = true;
                    Debug.Log("Game has ended");
                    yield break;
                }
                
                timeSeconds = 60;
                timeMinutes--;
            }
 
            timeSeconds--;
            
            counter.text = timeMinutes.ToString("D2") + ":" + timeSeconds.ToString("D2");
            yield return new WaitForSeconds(1f);

        }
    }

}
