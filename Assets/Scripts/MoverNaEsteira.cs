using UnityEngine;

public class MoverNaEsteira : MonoBehaviour
{
    public float velocidade = 2f;
    private bool estaSendoSegurado = false;

    void Update()
    {
        // Se NÃO estiver sendo segurado pelo mouse, ele anda para a direita
        if (!estaSendoSegurado)
        {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }

    // Esses métodos são chamados automaticamente quando o mouse interage
    void OnMouseDown()
    {
        estaSendoSegurado = true; // Parar de andar na esteira
    }

    void OnMouseUp()
    {
        estaSendoSegurado = false; // (Opcional) Voltar a andar se soltar
    }
}