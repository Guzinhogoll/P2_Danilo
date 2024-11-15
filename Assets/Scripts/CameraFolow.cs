using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;      // Limites horizontais
    public float minY, maxY;      // Limites verticais
    public float timeLerp;

    private void FixedUpdate()
    {
        // Ajusta a posi��o desejada da c�mera com base na posi��o do jogador e no offset de profundidade
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);

        // Suaviza o movimento da c�mera
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);

        // Clamping para manter a c�mera dentro dos limites definidos para x e y
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);

        // Atualiza a posi��o da c�mera com os valores limitados
        transform.position = new Vector3(clampedX, clampedY, newPosition.z);
    }
}
