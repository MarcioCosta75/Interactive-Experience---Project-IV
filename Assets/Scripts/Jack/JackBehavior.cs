using UnityEngine;

public class JackBehavior : MonoBehaviour
{
    public Transform queen;
    public float offsetFromQueen = 1.0f; // Distância lateral de Jack em relação à Queen
    public float minDistanceFromQueen = 3.0f; // Distância mínima de Jack em relação à Queen

    void OnEnable()
    {
        PositionJackNextToQueen();
    }

    void PositionJackNextToQueen()
    {
        float side = Random.value < 0.5f ? -1.0f : 1.0f; // Determina aleatoriamente de qual lado da Queen Jack aparecerá
        Vector3 potentialPosition = new Vector3(queen.position.x + side * offsetFromQueen, queen.position.y, queen.position.z);

        // Verifica se a posição pretendida está muito próxima da Queen e ajusta se necessário
        if (Mathf.Abs(potentialPosition.x - queen.position.x) < minDistanceFromQueen)
        {
            // Ajusta a posição do Jack para garantir o offset mínimo
            if (side < 0) // Jack estava à esquerda da Queen, mova-o mais para a esquerda
            {
                potentialPosition.x = queen.position.x - minDistanceFromQueen;
            }
            else // Jack estava à direita da Queen, mova-o mais para a direita
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