using UnityEngine;

public class JackSpawnController : MonoBehaviour
{
    public GameObject jack; // Refer�ncia ao GameObject do Jack
    public float minSpawnDelay = 5.0f; // Tempo m�nimo antes do Jack aparecer
    public float maxSpawnDelay = 10.0f; // Tempo m�ximo antes do Jack aparecer
    public float activeTime = 2.0f; // Quanto tempo o Jack fica ativo antes de desaparecer

    private float spawnTimer;
    private float activeTimer;
    private bool isJackActive = false;

    private void Start()
    {
        ResetSpawnTimer();
    }

    private void Update()
    {
        if (!isJackActive)
        {
            // Contagem regressiva para o spawn do Jack
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnJack();
            }
        }
        else
        {
            // Contagem regressiva para desativar o Jack
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0)
            {
                DespawnJack();
            }
        }
    }

    void SpawnJack()
    {
        jack.SetActive(true); // Ativa o GameObject do Jack
        isJackActive = true;
        activeTimer = activeTime; // Inicia a contagem regressiva para desativar o Jack
    }

    void DespawnJack()
    {
        jack.SetActive(false); // Desativa o GameObject do Jack
        isJackActive = false;
        ResetSpawnTimer(); // Reinicia o temporizador para o pr�ximo spawn
    }

    void ResetSpawnTimer()
    {
        spawnTimer = Random.Range(minSpawnDelay, maxSpawnDelay); // Define um tempo aleat�rio para o pr�ximo spawn
    }
}