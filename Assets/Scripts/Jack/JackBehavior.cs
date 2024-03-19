using UnityEngine;

public class JackBehavior : MonoBehaviour
{
    public Transform queen;
    public float offsetFromQueen = 1.0f; // Dist�ncia lateral de Jack em rela��o � Queen
    public float minDistanceFromQueen = 3.0f; // Dist�ncia m�nima de Jack em rela��o � Queen

    void OnEnable()
    {
        PositionJackNextToQueen();
    }

    void PositionJackNextToQueen()
    {
        float side = Random.value < 0.5f ? -1.0f : 1.0f; // Determina aleatoriamente de qual lado da Queen Jack aparecer�
        Vector3 potentialPosition = new Vector3(queen.position.x + side * offsetFromQueen, queen.position.y, queen.position.z);

        // Verifica se a posi��o pretendida est� muito pr�xima da Queen e ajusta se necess�rio
        if (Mathf.Abs(potentialPosition.x - queen.position.x) < minDistanceFromQueen)
        {
            // Ajusta a posi��o do Jack para garantir o offset m�nimo
            if (side < 0) // Jack estava � esquerda da Queen, mova-o mais para a esquerda
            {
                potentialPosition.x = queen.position.x - minDistanceFromQueen;
            }
            else // Jack estava � direita da Queen, mova-o mais para a direita
            {
                potentialPosition.x = queen.position.x + minDistanceFromQueen;
            }
        }

        transform.position = potentialPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("King"))
        {
            Debug.Log("Game Over: Jack caught the King!");
            gameObject.SetActive(false); // Desativa Jack
        }
    }
}