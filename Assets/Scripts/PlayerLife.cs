using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool alive = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameController.gc.RefreshScreen();
    }
    public void LoseLife()
    {
        if (alive)
        {
            GetComponent<Player>().audioS.clip = GetComponent<Player>().Sounds[3];
            GetComponent<Player>().audioS.Play();
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            GameController.gc.Setlives(-1);


            if (GameController.gc.lives >= 0)
            {
                Invoke("LoadScene", 1f);
            }
            else
            {
                Invoke("LoadGameOver", 1f);
                
            }
        }
    }
   public void LoadGameOver()
    {
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
        SceneManager.LoadScene("Game Over");
        GameController.gc.timeCount = 0;
        GameController.gc.lives = 0;
        GameController.gc.coins = 0;
        GameController.gc.RefreshScreen();
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Fase1");
        GameController.gc.timeCount = 60;
    }
}
