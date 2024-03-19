using UnityEngine;

public class KissDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão foi com a Queen
        if (collision.gameObject.CompareTag("Queen"))
        {
            Debug.Log("Kiss detected!");
            // Chama o método RespawnQueen do script QueenSpawnController, que está anexado à Queen
            QueenSpawnController queenController = collision.gameObject.GetComponent<QueenSpawnController>();
            if (queenController != null)
            {
                queenController.RespawnQueen(); // Faz o respawn da Queen
            }
            else
            {
                Debug.LogError("Não foi possível encontrar o script QueenSpawnController na Queen.");
            }
        }
    }
}