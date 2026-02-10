using UnityEngine;

public class LeitorCaixa : MonoBehaviour
{
    // OnTriggerEnter2D é chamado automaticamente quando algo ENTRA na área do sensor
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou tem a etiqueta "Produto"
        if (other.CompareTag("Produto"))
        {
            RegistrarProduto(other.gameObject);
        }
    }

    void RegistrarProduto(GameObject produto)
    {
        // Aqui depois vamos colocar o som de "BIP" e somar o dinheiro
        Debug.Log("BIP! Registrei o item: " + produto.name);

        // Opcional: Mudar a cor do produto pra verde para mostrar que já passou
        produto.GetComponent<SpriteRenderer>().color = Color.green;
    }
}