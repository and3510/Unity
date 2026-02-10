using UnityEngine;

public class ProdutoDrag : MonoBehaviour
{
    private bool estaArrastando = false;
    private bool estaEmCimaDaSacola = false; // Nova variável de controle
    private Vector3 offset;
    private Vector3 posicaoOriginal;
    private int sortingOrderOriginal;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingOrderOriginal = spriteRenderer.sortingOrder;
    }

    void OnMouseDown()
    {
        estaArrastando = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Efeito visual de pegar
        transform.localScale = transform.localScale * 1.2f; 
        spriteRenderer.sortingOrder = 100;
        
        // Desliga o movimento da esteira se tiver o script
        if(GetComponent<MoverNaEsteira>() != null)
            GetComponent<MoverNaEsteira>().enabled = false;
    }

    void OnMouseDrag()
    {
        if (estaArrastando)
        {
            Vector3 novaPosicao = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(novaPosicao.x, novaPosicao.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        estaArrastando = false;
        transform.localScale = transform.localScale / 1.2f;
        spriteRenderer.sortingOrder = sortingOrderOriginal;

        // O GRANDE MOMENTO: Soltou na sacola?
        if (estaEmCimaDaSacola)
        {
            VenderProduto();
        }
        else
        {
            // Opcional: Se soltou fora, religa a esteira
            if(GetComponent<MoverNaEsteira>() != null)
                GetComponent<MoverNaEsteira>().enabled = true;
        }
    }

    void VenderProduto()
    {
        Debug.Log("$$$ VENDIDO! +10 Reais $$$");
        // Aqui depois colocaremos o som de dinheiro
        
        // Destrói o objeto (ele foi pra sacola)
        Destroy(gameObject);
    }

    // --- DETECTORES DE COLISÃO ---
    
    // Entrou na área da sacola?
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sacola"))
        {
            estaEmCimaDaSacola = true;
            spriteRenderer.color = Color.green; // Feedback visual (opcional)
        }
    }

    // Saiu da área da sacola?
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Sacola"))
        {
            estaEmCimaDaSacola = false;
            spriteRenderer.color = Color.white; // Volta a cor normal
        }
    }
}