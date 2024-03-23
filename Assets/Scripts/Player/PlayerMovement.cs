using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Animator animator;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    private bool isFacingLeft = false; // Para controlar a direção atual do King

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0) // Movendo para a esquerda
        {
            HandleMovement(-1);
            if (!isFacingLeft)
            {
                animator.SetBool("IsMovingLeft", true);
                animator.SetBool("IsMovingRight", false);
                RotateKing(-90); // Vira o King para a esquerda
                isFacingLeft = true;
            }
            else
            {
                animator.SetBool("IsRunning", true);
            }
        }
        else if (horizontalInput > 0) // Movendo para a direita
        {
            HandleMovement(1);
            if (isFacingLeft)
            {
                animator.SetBool("IsMovingRight", true);
                animator.SetBool("IsMovingLeft", false);
                RotateKing(90); // Vira o King para a direita
                isFacingLeft = false;
            }
            else
            {
                animator.SetBool("IsRunning", true);
            }
        }
        else // Nenhum input horizontal
        {
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
            animator.SetBool("IsRunning", false);
        }
    }

    private void HandleMovement(float direction)
    {
        // Movimenta o jogador
        Vector3 nextPosition = transform.position + new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        transform.position = nextPosition;
    }

    private void RotateKing(float yRotation)
    {
        // Aplica rotação no eixo Y
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}