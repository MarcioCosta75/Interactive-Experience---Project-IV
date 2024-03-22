using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Animator animator;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    private float lastHorizontalInput = 0f; // Armazena o último input horizontal

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            if (horizontalInput != lastHorizontalInput)
            {
                // Se o input mudou desde o último frame, gerencie a rotação
                Rotate(horizontalInput);
            }
            Move(horizontalInput);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        lastHorizontalInput = horizontalInput; // Atualiza o último input para comparação no próximo frame
    }

    private void Rotate(float horizontalInput)
    {
        // Define a rotação baseada na direção do input
        transform.rotation = Quaternion.Euler(0, horizontalInput < 0 ? -90 : 90, 0);
        // Se o input é para a esquerda, ative a animação de virar para a esquerda, senão, desative-a
        animator.SetBool("IsMovingLeft", horizontalInput < 0);
    }

    private void Move(float horizontalInput)
    {
        Vector3 nextPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        transform.position = nextPosition;

        // Só ativa a animação de corrida se estiver movendo
        if (Mathf.Abs(horizontalInput) > 0)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}