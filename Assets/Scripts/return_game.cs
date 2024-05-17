using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class return_game : MonoBehaviour
{
   public void returnToMenu()
    {
        SceneManager.LoadScene ("Menu");

    }
    public void returnTgame()
    {
        SceneManager.LoadScene("Game");

    }
}
