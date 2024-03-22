using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Animator animator;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    private float lastHorizontalInput = 0f; // Armazena o �ltimo input horizontal

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            if (horizontalInput != lastHorizontalInput)
            {
                // Se o input mudou desde o �ltimo frame, gerencie a rota��o
                Rotate(horizontalInput);
            }
            Move(horizontalInput);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        lastHorizontalInput = horizontalInput; // Atualiza o �ltimo input para compara��o no pr�ximo frame
    }

    private void Rotate(float horizontalInput)
    {
        // Define a rota��o baseada na dire��o do input
        transform.rotation = Quaternion.Euler(0, horizontalInput < 0 ? -90 : 90, 0);
        // Se o input � para a esquerda, ative a anima��o de virar para a esquerda, sen�o, desative-a
        animator.SetBool("IsMovingLeft", horizontalInput < 0);
    }

    private void Move(float horizontalInput)
    {
        Vector3 nextPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX);
        transform.position = nextPosition;

        // S� ativa a anima��o de corrida se estiver movendo
        if (Mathf.Abs(horizontalInput) > 0)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}