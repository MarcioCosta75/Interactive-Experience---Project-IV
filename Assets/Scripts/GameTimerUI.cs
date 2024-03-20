using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    public Image timerForegroundImage; // A imagem de foreground que representa o tempo restante
    public float totalTime = 60f; // Total de tempo em segundos

    private float timeLeft;

    void Start()
    {
        timeLeft = totalTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay(timeLeft / totalTime);
        }
        else
        {
            Debug.Log("Tempo Esgotado!");
            // Adicione aqui o que deve acontecer quando o tempo acaba
            // Por exemplo, mostrar um painel de Game Over
        }
    }

    void UpdateTimerDisplay(float timeRatio)
    {
        // Assume que a imagem está configurada para preencher horizontalmente.
        // Ajusta a largura da imagem de foreground com base na razão do tempo restante.
        timerForegroundImage.fillAmount = timeRatio;
    }
}