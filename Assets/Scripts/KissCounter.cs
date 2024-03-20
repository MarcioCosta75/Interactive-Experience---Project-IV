using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KissCounter : MonoBehaviour
{
    public static KissCounter instance; // Fazendo o script acessível globalmente
    public TextMeshProUGUI kissCountText; // Referência ao componente de texto que mostra a contagem
    private int kissCount = 0; // Contador de kisses

    void Awake()
    {
        // Configuração do Singleton
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
}