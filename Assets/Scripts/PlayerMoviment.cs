using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Use float para velocidade (melhor para ajustes finos)
    public float speed = 50f; 
    
    private Rigidbody2D characterBody;
    private Vector2 inputMovement;

    // REMOVIDO: private Vector2 velocity; (Não precisamos disso)

    void Start()
    {
        // REMOVIDO: velocity = new Vector2... (Estava faltando ; e não é necessário)
        characterBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Captura as teclas
        inputMovement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }

    private void FixedUpdate()
    {
        // 2. Calcula o movimento
        // Aqui usamos 'speed' direto, que é mais simples e correto
        Vector2 delta = inputMovement * speed * Time.fixedDeltaTime;
        
        // 3. Aplica a física
        Vector2 novaPosicao = characterBody.position + delta;
        characterBody.MovePosition(novaPosicao);
    }
}