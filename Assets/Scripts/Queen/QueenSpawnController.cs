using UnityEngine;

public class QueenSpawnController : MonoBehaviour
{
    public GameObject queen;
    public Transform king;
    public float minOffsetFromKing = 5.0f;
    public float spawnAreaStartX = -10;
    public float spawnAreaEndX = 10;
    public float spawnHeightY = 0;
    public float changePositionTime = 5.0f;

    private float timer;

    private void Start()
    {
        timer = changePositionTime;
        RespawnQueen();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            RespawnQueen();
            timer = changePositionTime;
        }
    }

    public void RespawnQueen()
    {
        float randomX = GetRandomXWithOffsetAndSegment();
        float currentZ = transform.position.z;
        queen.transform.position = new Vector3(randomX, spawnHeightY, currentZ);
    }

    private float GetRandomXWithOffsetAndSegment()
    {
        float randomX;
        do
        {
            float randomSegmentChoice = Random.value;
            if (randomSegmentChoice < 0.4f)
            {
                randomX = Random.Range(spawnAreaStartX, spawnAreaStartX + (spawnAreaEndX - spawnAreaStartX) / 3);
            }
            else if (randomSegmentChoice < 0.6f)
            {
                randomX = Random.Range(spawnAreaStartX + (spawnAreaEndX - spawnAreaStartX) / 3, spawnAreaEndX - (spawnAreaEndX - spawnAreaStartX) / 3);
            }
            else
            {
                randomX = Random.Range(spawnAreaEndX - (spawnAreaEndX - spawnAreaStartX) / 3, spawnAreaEndX);
            }
        } while (Mathf.Abs(randomX - king.position.x) < minOffsetFromKing);

        return randomX;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 lineStart = new Vector3(spawnAreaStartX, spawnHeightY, transform.position.z);
        Vector3 lineEnd = new Vector3(spawnAreaEndX, spawnHeightY, transform.position.z);
        Gizmos.DrawLine(lineStart, lineEnd);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão foi com o King
        if (collision.gameObject.CompareTag("Queen"))
        {
            Debug.Log("Kiss detected!");
            // Faz o respawn da Queen imediatamente após um "kiss"
            RespawnQueen();
        }
    }
}