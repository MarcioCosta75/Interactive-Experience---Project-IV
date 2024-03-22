using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necessário para usar TextMeshPro

public class GameTimerUI : MonoBehaviour
{
    public Image timerForegroundImage; // A imagem de foreground que representa o tempo restante
    public GameObject gameOverPanel; // O painel de Game Over para ativar quando o tempo acabar
    public TextMeshProUGUI gameOverKissCountText; // Texto no painel de Game Over para a contagem de beijos
    public float totalTime = 60f; // Total de tempo em segundos

    private float timeLeft;

    void Awake() // ou Start(), dependendo da sua preferência
    {
        // Assegura que o tempo no jogo está correndo normalmente ao iniciar/reiniciar a cena
        Time.timeScale = 1;
    }

    void Start()
    {
        timeLeft = totalTime;
        gameOverPanel.SetActive(false); // Garante que o painel de Game Over está desativado no início
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerForegroundImage.fillAmount = timeLeft / totalTime;
        }
        else
        {
            EndTimer();
        }
    }

    void EndTimer()
    {
        Debug.Log("Tempo Esgotado!");
        Time.timeScale = 0; // Congela o jogo
        gameOverKissCountText.text = "Total Kisses: " + KissCounter.instance.GetKissCount(); // Atualiza o texto com a contagem de beijos
        gameOverPanel.SetActive(true); // Ativa o painel de Game Over
    }
}