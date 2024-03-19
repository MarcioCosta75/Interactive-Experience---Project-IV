using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Velocidade de movimento do personagem
    public float minX = -5.0f; // Limite mínimo no eixo X
    public float maxX = 5.0f; // Limite máximo no eixo X

    void Update()
    {
        // Obtém o movimento horizontal (direita = 1, esquerda = -1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Movimenta o personagem apenas no eixo X
        Vector3 nextPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        // Restringe o próximo movimento aos limites definidos
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);

        // Aplica o movimento restrito
        transform.position = nextPosition;
    }
}