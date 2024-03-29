using UnityEngine;
using TMPro; // Necess�rio para usar TextMeshPro

public class KissCounter : MonoBehaviour
{
    public static KissCounter instance; // Fazendo o script acess�vel globalmente
    public TextMeshProUGUI kissCountText; // Refer�ncia ao componente de texto que mostra a contagem
    private int kissCount = 0; // Contador de kisses

    void Awake()
    {
        // Configura��o do Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void IncrementKissCount()
    {
        kissCount++; // Incrementa o contador de kisses
        kissCountText.text = "Kisses: " + kissCount; // Atualiza o texto na UI
    }

    // M�todo para acessar a contagem de beijos
    public int GetKissCount()
    {
        return kissCount;
    }
}