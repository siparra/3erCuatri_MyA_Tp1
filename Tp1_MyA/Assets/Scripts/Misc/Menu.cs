using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(0);
        this.gameObject.SetActive(false);
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
