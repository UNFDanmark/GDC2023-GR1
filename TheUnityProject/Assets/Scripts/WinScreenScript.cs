using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PointCounter.p1Win == true)
        {
            //If Barry wins, turn Gary's art off
            gameObject.SetActive(false);
        }
    }
}
