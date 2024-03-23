using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Animator animator;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    private bool isTurning = false; // Para rastrear se está no meio de uma virada

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0) // Movendo para a esquerda
        {
            HandleMovement(-1);
            if (!animator.GetBool("IsMovingLeft"))
            {
                RotateCharacter(-90);
                animator.SetBool("IsMovingLeft", true);
                animator.SetBool("IsMovingRight", false);
                animator.SetBool("IsRunning", false);
                isTurning = true;
            }
            else if (isTurning)
            {
                animator.SetBool("IsRunning", true);
            }
        }
        else if (horizontalInput > 0) // Movendo para a direita
        {
            HandleMovement(1);
            if (!animator.GetBool("IsMovingRight"))
            {
                RotateCharacter(90);
                animator.SetBool("IsMovingRight", true);
                animator.SetBool("IsMovingLeft", false);
                animator.SetBool("IsRunning", false);
                isTurning = true;
            }
            else if (isTurning)
            {
                animator.SetBool("IsRunning", true);
            }
        }
        else // Nenhum input horizontal
        {
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
            animator.SetBool("IsRunning", false);
            isTurning = false;
        }

        // Reseta o estado de virada se já está correndo
        if (animator.GetBool("IsRunning"))
        {
            isTurning = false;
        }
    }

    private void HandleMovement(float direction)
    {
        Vector3 nextPosition = transform.position + new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        transform.position = nextPosition;
    }

    private void RotateCharacter(float yRotation)
    {
        // Rotação no eixo Y para virar o personagem
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}