using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScenes(string cena) 
    {
        SceneManager.LoadScene(cena);
        GameController.gc.timeCount = 60;
        GameController.gc.lives = 3;
        GameController.gc.coins = 0;
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = true;
    }

    public void ButtonReturn(string cena)
    {
        SceneManager.LoadScene(cena);
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    }
    //public void ButtonStart(string cena)
    //{
    //    SceneManager.LoadScene(cena);
    //    GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    //}
    //public void ButtonReStart(string cena)
    //{
    //    SceneManager.LoadScene(cena);
    //    GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    //}
  
    public void Quit() 
    {
        Application.Quit();
    }
}
