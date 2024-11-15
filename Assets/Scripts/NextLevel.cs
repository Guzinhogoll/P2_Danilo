using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool ultimaFase; // variavel para ultima fase

    public AudioClip finish; // variavel finalização da musica
    public AudioSource audioS; // variavel controle da musica
    void Start()
    {

    }

    //codigo de colisão com o player e de musica do player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.gc.textNextLevel.SetActive(true);
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            collision.GetComponent<Player>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Animator>().SetBool("Walk", false);
            collision.GetComponent<Animator>().Play("Play_Idle");
            GetComponent<AudioSource>().clip = finish;
            GetComponent<AudioSource>().Play();
            Invoke("NextScenes", 5f);
        }
    }
    void NextScenes() // metodo para carregar proxima fase 
    {
        if (ultimaFase) //codigo de ultima fase
        {
            SceneManager.LoadScene("Menu");
            GameController.gc.textNextLevel.SetActive(false);
            GameController.gc.timeCount = 0;
            GameController.gc.lives = 0;
            GameController.gc.coins = 0;
            GameController.gc.RefreshScreen();
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
        }
        else //codigo de próxima fase
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // codigo de carregar a proxima fase
            GameController.gc.textNextLevel.SetActive(false);
            GameController.gc.timeCount = 60f;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Play();
        }
    }
}