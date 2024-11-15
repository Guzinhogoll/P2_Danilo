using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Plataform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool platformLeft1, platformUp1, platformUp2, platformUp3, platformUp4, platformDown1, platformRight1, 
        platformRight2, platformRight3, platformRight4;
    public bool moveRight = true, moveUp = true;
    private float startX;  // Posição inicial da plataforma
    void Start()
    {
        // Salva a posição inicial em X para calcular a distância de 23 unidades
        startX = transform.position.x;
    }

    void Update()
    {
        if (platformLeft1)
        {
            if (transform.position.x > -5)
            {
                moveRight = false;
            }
            else if (transform.position.x < -8)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }

        if (platformUp1)
        {
            if (transform.position.y > 3)
            {
                moveUp = false;
            }
            else if (transform.position.y < -1.64f)
            {
                moveUp = true;
            }
            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }

        if (platformUp2)
        {
            if (transform.position.y >= -2.44f)
            {
                moveUp = false;  // Muda para movimento descendente ao atingir o topo
            }
            else if (transform.position.y <= -4.19f)
            {
                moveUp = true;   // Muda para movimento ascendente ao atingir o ponto inicial
            }

            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }

        if (platformUp3)
        {
            if (transform.position.y >= 1.09f)
            {
                moveUp = false;  // Muda para movimento descendente ao atingir o topo
            }
            else if (transform.position.y <= -2.55f)
            {
                moveUp = true;   // Muda para movimento ascendente ao atingir o ponto inicial
            }

            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }

        if (platformUp4)
        {
            if (transform.position.y >= 5.34f)
            {
                moveUp = false;  // Muda para movimento descendente ao atingir o topo
            }
            else if (transform.position.y <= -4.19f)
            {
                moveUp = true;   // Muda para movimento ascendente ao atingir o ponto inicial
            }

            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }

        if (platformDown1)
        {
            // Limites do movimento vertical para platformDown1
            if (transform.position.y <= -4.19f)  // Ponto mais baixo
            {
                moveUp = true;  // Muda para movimento ascendente ao atingir o limite inferior
            }
            else if (transform.position.y >= 5.34f)  // Ponto mais alto
            {
                moveUp = false;   // Muda para movimento descendente ao atingir o limite superior
            }

            // Executa o movimento para cima ou para baixo
            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }

        if (platformRight1)
        {
            if (transform.position.y > 3)
            {
                moveUp = false;
            }
            else if (transform.position.y < -1.64f)
            {
                moveUp = true;
            }
            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }

        if (platformRight2)
        {
            // Calcula a distância percorrida em relação à posição inicial
            float distance = transform.position.x - startX;

            // Limites para o movimento horizontal baseado na distância de 23 unidades
            if (distance >= 10.5f)
            {
                moveRight = false;
            }
            else if (distance <= 0)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
        }

        if (platformRight3)
        {
            // Calcula a distância percorrida em relação à posição inicial
            float distance = transform.position.x - startX;

            
            if (distance >= 3f)
            {
                moveRight = false;
            }
            else if (distance <= 0)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
        }

        if (platformRight4)
        {
            // Calcula a distância percorrida em relação à posição inicial
            float distance = transform.position.x - startX;


            if (distance >= 4f)
            {
                moveRight = false;
            }
            else if (distance <= 0)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
        }
    }
}
