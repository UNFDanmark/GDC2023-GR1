using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource theme;
    [SerializeField] private AudioSource startSfx;
    
    //Start the game and go to gameScene
    public void StartGame()
    {
        theme.Pause();
        startSfx.Play();
        StartCoroutine(Enumerator());
    }
    
    //Go from result screen to main menu
    public void ReturnToMainMenu()
    {
        Debug.Log("Going to main menu...");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private IEnumerator Enumerator()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Going to gameScene...");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
