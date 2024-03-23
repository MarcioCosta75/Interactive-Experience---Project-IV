using UnityEngine;

public class JackBehavior : MonoBehaviour
{
    public Transform queen;
    public Transform king; // Certifique-se de que isso est� referenciado no Unity Inspector
    public GameObject gameOverPanel; // Refer�ncia ao painel de Game Over
    public float offsetFromQueen = 1.0f; // Dist�ncia lateral de Jack em rela��o � Queen
    public float minDistanceFromQueen = 3.0f; // Dist�ncia m�nima de Jack em rela��o � Queen
    public float minX = -6.2f; // Limite m�nimo no eixo X para o spawn do Jack
    public float maxX = 6.2f; // Limite m�ximo no eixo X para o spawn do Jack

    void OnEnable()
    {
        PositionJackNextToQueen();
    }

    void PositionJackNextToQueen()
    {
        // Calcula o ponto m�dio entre a Queen e o King
        float midpointX = (queen.position.x + king.position.x) / 2;
        float side = king.position.x < queen.position.x ? 1.0f : -1.0f;

        // Posiciona o Jack no meio do caminho entre a Queen e o King, mas dentro dos limites minX e maxX
        Vector3 potentialPosition = new Vector3(midpointX + side * offsetFromQueen, queen.position.y, queen.position.z);

        // Garante que o Jack n�o ultrapasse os limites estabelecidos e mantenha a dist�ncia m�nima da Queen
        potentialPosition.x = Mathf.Clamp(potentialPosition.x, Mathf.Max(minX, queen.position.x - minDistanceFromQueen), Mathf.Min(maxX, queen.position.x + minDistanceFromQueen));

        // Aplica a nova posi��o ao Jack
        transform.position = potentialPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("King"))
        {
            Debug.Log("Game Over: Jack caught the King!");
            Time.timeScale = 0; // Congela o jogo
            gameOverPanel.SetActive(true); // Ativa o painel de Game Over
            gameObject.SetActive(false); // Desativa Jack
        }
    }
}