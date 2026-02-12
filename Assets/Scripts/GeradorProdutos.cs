using UnityEngine;

public class GeradorProdutos : MonoBehaviour
{
    public GameObject produtoModelo; // Aqui vai o seu Prefab do Arroz
    public float tempoEntreProdutos = 50f; // A cada 3 segundos nasce um

    private float cronometro;

    void Update()
    {
        cronometro += Time.deltaTime;

        // Se passou o tempo...
        if (cronometro >= tempoEntreProdutos)
        {
            GerarProduto();
            cronometro = 0; // Reseta o relógio
        }
    }

    void GerarProduto()
    {
        // Cria uma cópia do prefab na posição deste gerador
        Instantiate(produtoModelo, transform.position, Quaternion.identity);
    }
}