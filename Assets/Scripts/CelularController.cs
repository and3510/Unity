using UnityEngine;

public class CelularController : MonoBehaviour
{
    [Header("Configurações")]
    public float velocidade = 10f; // Quão rápido o celular sobe
    public float alturaParaSubir = 4f; // Quanto ele sobe no eixo Y

    private Vector3 posicaoEscondido;
    private Vector3 posicaoMostrando;

    void Start()
    {
        // Salva onde o celular está agora como a posição "Guardado no Bolso"
        posicaoEscondido = transform.position;

        // Calcula onde ele vai ficar quando subir (Posição atual + X metros pra cima)
        posicaoMostrando = new Vector3(transform.position.x, transform.position.y + alturaParaSubir, transform.position.z);
    }

    void Update()
    {
        // Se segurar ESPAÇO ou CLIQUE DO MOUSE
        if (Input.GetKey(KeyCode.Space))
        {
            SubirCelular();
        }
        else
        {
            DescerCelular();
        }
    }

    void SubirCelular()
    {
        // Move suavemente da posição atual -> para cima
        transform.position = Vector3.Lerp(transform.position, posicaoMostrando, Time.deltaTime * velocidade);
    }

    void DescerCelular()
    {
        // Move suavemente da posição atual -> para baixo (esconderijo)
        transform.position = Vector3.Lerp(transform.position, posicaoEscondido, Time.deltaTime * velocidade);
    }
}