using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    
    //Start the game and go to gameScene
    public void StartGame()
    {
        Debug.Log("Going to gameScene...");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    //Go from result screen to main menu
    public void ReturnToMainMenu()
    {
        Debug.Log("Going to main menu...");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
   
}
