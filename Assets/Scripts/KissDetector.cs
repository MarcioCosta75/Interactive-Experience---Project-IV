using UnityEngine;

public class KissDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colis�o foi com a Queen
        if (collision.gameObject.CompareTag("Queen"))
        {
            Debug.Log("Kiss detected!");

            // Incrementa a contagem de kisses
            if (KissCounter.instance != null)
            {
                KissCounter.instance.IncrementKissCount();
            }
            else
            {
                Debug.LogError("N�o foi poss�vel encontrar uma inst�ncia de KissCounter.");
            }

            // Chama o m�todo RespawnQueen do script QueenSpawnController, que est� anexado � Queen
            QueenSpawnController queenController = collision.gameObject.GetComponent<QueenSpawnController>();
            if (queenController != null)
            {
                queenController.RespawnQueen(); // Faz o respawn da Queen
            }
            else
            {
                Debug.LogError("N�o foi poss�vel encontrar o script QueenSpawnController na Queen.");
            }
        }
    }
}