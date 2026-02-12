
using UnityEngine;

public class CameraPanXY : MonoBehaviour
{
    [Header("Limites Horizontais")]
    public float limitX = 8.5f; // Esquerda e Direita continuam iguais

    [Header("Limites Verticais (Diferentes)")]
    public float limitUp = 2.0f;   // Pode subir BASTANTE (ver o teto)
    public float limitDown = 0.5f; // Pode descer POUCO (trava antes de ver o chão vazio)

    [Header("Suavização")]
    [Range(1f, 20f)]
    public float smoothSpeed = 5.0f;

    void Update()
    {
        // 1. Pega porcentagem do mouse (0.0 a 1.0)
        float mouseXPct = Mathf.Clamp01(Input.mousePosition.x / Screen.width);
        float mouseYPct = Mathf.Clamp01(Input.mousePosition.y / Screen.height);

        // 2. Centraliza (-0.5 a 0.5)
        mouseXPct -= 0.5f;
        mouseYPct -= 0.5f;

        // 3. Calcula o Alvo X (Simétrico)
        float targetX = mouseXPct * 2 * limitX;

        // 4. Calcula o Alvo Y (ASSIMÉTRICO)
        float targetY = 0;

        // Se o mouse está na metade de CIMA (positivo)
        if (mouseYPct > 0)
        {
            targetY = mouseYPct * 2 * limitUp; // Usa o limite grande
        }
        // Se o mouse está na metade de BAIXO (negativo)
        else
        {
            targetY = mouseYPct * 2 * limitDown; // Usa o limite pequeno
        }

        // 5. Aplica o movimento suave
        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}