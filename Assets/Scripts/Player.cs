using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float jumpforce;
    public bool inFloor = true;
    public bool doubleJump;
    public bool triploJump;

    private GameController gcPlayer;

    public AudioSource audioS;
    public AudioClip[] Sounds;
    void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.coins = 0;
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    //Movimento do Player
    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMoviment); 
        // transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed,0,0); 
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if (horizontalMoviment > 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = false;
        }
        else if (horizontalMoviment < 0)
        {
            playerAnim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }

    //Pulo do Player
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (inFloor)
            {
                audioS.clip = Sounds[1];
                audioS.Play();
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = true;
            }
            else if (!inFloor && doubleJump) //segundo pulo
            {
                audioS.clip = Sounds[1];
                audioS.Play();
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, jumpforce * 1), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = false;
                triploJump = true;
            }
            else if (!inFloor && triploJump) //terceiro pulo
            {
                audioS.clip = Sounds[1];
                audioS.Play();
                rbPlayer.velocity = Vector2.zero;
                playerAnim.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = false;
                triploJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
            doubleJump = false;
            triploJump = false;
        }

        if (collision.gameObject.tag == "Platform")
        { 
            gameObject.transform.parent = collision.transform;    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
    }

    //Codigo das moeddas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioS.clip = Sounds[0];
        audioS.Play(); 
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            //gcPlayer.coins++;
            gcPlayer.SetCoins(1);
            GameController.gc.RefreshScreen();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            audioS.clip = Sounds[2];
            audioS.Play();
            rbPlayer.velocity = Vector2.zero;
            rbPlayer.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            collision.gameObject.GetComponent<Enemy>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(collision.gameObject, 1f);
        }
    }
}
